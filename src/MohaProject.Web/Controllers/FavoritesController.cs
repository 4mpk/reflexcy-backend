using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MohaProject.DataForms;
using MohaProject.Favorites;
using SelectPdf;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace MohaProject.Web.Controllers;

[Authorize]
[Route("/Favorites")]
public class FavoritesController : AbpController
{
    private readonly IRepository<Favorite, Guid> _FavoriteRepository;

    public FavoritesController(IRepository<Favorite, Guid> favoriteRepository)
    {
        _FavoriteRepository = favoriteRepository;
    }

    /// <summary>
    /// we chack inside the method  if CurrentUser.IsAuthenticated so must be related to him 
    /// else 
    /// do not care,  due to calls from dashboard
    /// </summary>
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var query = await _FavoriteRepository.GetQueryableAsync();

        var favorites = await query
            .AsNoTracking()
            .Where(e => e.UserId == CurrentUser.GetId())
            .ToListAsync();

        return Ok(favorites);
    }

    [HttpPost("MakeFavorite")]
    public async Task<IActionResult> MakeFavoriteAsync(int templateId)
    {
        if (templateId == 0)
            return RedirectToAction("GetAll");

        var item = await _FavoriteRepository
            .FindAsync(e => e.TemplateId == templateId && e.UserId == CurrentUser.GetId());

        if (item == null)
        {
            var favorite = new Favorite()
            {
                UserId = CurrentUser.GetId(),
                TemplateId = templateId
            };

            await _FavoriteRepository.InsertAsync(favorite);
        }
        else
        {
            await _FavoriteRepository.DeleteAsync(item);
        }

        return Ok();
    }
}