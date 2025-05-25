using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MohaProject.Volo.Abp.Account.Dto;
using RestSharp;
using Volo.Abp.Account;
using Volo.Abp.Account.Emailing;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.Identity;
using Volo.Abp.UI.Navigation.Urls;

namespace MohaProject.Volo.Abp.Account;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(AccountAppService), typeof(CustomAccountAppService), typeof(IAccountAppService), typeof(ICustomAccountAppService))]
public class CustomAccountAppService : AccountAppService, ICustomAccountAppService, ITransientDependency
{
    private readonly IAppUrlProvider _appUrlProvider;
    private readonly IAccountEmailer _accountEmailer;
    private readonly IEmailSender _emailSender;
    public CustomAccountAppService(IdentityUserManager userManager, IIdentityRoleRepository roleRepository, IAccountEmailer accountEmailer, IdentitySecurityLogManager identitySecurityLogManager, IOptions<IdentityOptions> identityOptions, IAppUrlProvider appUrlProvider, IEmailSender emailSender) : base(userManager, roleRepository, accountEmailer, identitySecurityLogManager, identityOptions)
    {
        _appUrlProvider = appUrlProvider;
        _accountEmailer = accountEmailer;
        _emailSender = emailSender;
    }

    public virtual async Task<object> PostLoginAsync(LoginDto input)
    {
        input.EmailAddress = input.EmailAddress.Trim();
        input.Password = input.Password.Trim();

        var existingUser = await UserManager.FindByEmailAsync(input.EmailAddress);

        var uri = new System.Uri($"{await _appUrlProvider.GetUrlAsync("MVC")}/connect/token");
        var client = new RestClient(new RestClientOptions(uri));
        var request = new RestRequest(uri, Method.Post);
        request.AddParameter("grant_type", "password");
        request.AddParameter("client_id", "MohaProject_WebPublic");
        request.AddParameter("scope", "MohaProject offline_access");
        request.AddParameter("username", input.EmailAddress);
        request.AddParameter("password", input.Password);

        var response = await client.ExecuteAsync<object>(request);

        return response.Data;
    }

    public override async Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto input)
    {
        input.Email = input.Email.Trim();

        var user = await GetUserByEmailAsync(input.Email);

        var random = new Random();

        var code = new string(Enumerable.Repeat("0123456789", 5).Select(s => s[random.Next(s.Length)]).ToArray());

        var resetToken = await UserManager.GeneratePasswordResetTokenAsync(user);

        user.ExtraProperties["resetCode"] = code;
        user.ExtraProperties["resetToken"] = resetToken;
        
        await UserManager.UpdateAsync(user);                                             

        await _emailSender.SendAsync(user.Email, "Reset Pasword", code);
    }

    public async Task<bool> VerifyResetPasswordAsync(VerifyResetPasswordInput input)
    {
        var user = await GetUserByEmailAsync(input.Email);

        if (Convert.ToString(user.ExtraProperties.GetValueOrDefault("resetCode")) == input.Code)
            return await base.VerifyPasswordResetTokenAsync(new VerifyPasswordResetTokenInput() 
            { 
                UserId = user.Id, 
                ResetToken = Convert.ToString(user.ExtraProperties.GetValueOrDefault("resetToken")) 
            });

        return false;
    }

    public async Task<bool> DoResetPasswordAsync(ResetPasswordInput input)
    {
        var user = await GetUserByEmailAsync(input.Email);

        await base.ResetPasswordAsync(new ResetPasswordDto()
        {
            UserId = user.Id,
            Password = input.NewPassword,
            ResetToken = Convert.ToString(user.ExtraProperties.GetValueOrDefault("resetToken"))
        });

        return true;
    }
}                      
