using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LayoutService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppLinksController : ControllerBase
    {
        private readonly IAppLinkRepository appLinksRepository;

        public AppLinksController(IAppLinkRepository appLinksRepository)
        {
            this.appLinksRepository = appLinksRepository;
        }

        // GET: api/AppLinks
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var appLinks = await appLinksRepository.GetAllWithSubLinksAsync();
            return Ok(appLinks);
        }
    }
}
