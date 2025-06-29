﻿using System.Threading.Tasks;
using Volo.Abp.Account;
using Volo.Abp.Application.Services;

namespace MohaProject.Volo.Abp.Account;

public interface ICustomAccountAppService : IAccountAppService, IApplicationService
{
    Task<bool> DeleteAsync();
}
