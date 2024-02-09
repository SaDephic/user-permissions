using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using user_permissions.Constant;
using user_permissions.Helpers;
using user_permissions.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace user_permissions.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public PermissionController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        
        }
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionViewModel>>> GetArticles()
        {
            return await _roleManager.ro.ToListAsync();
        }*/

    }
}
