using Microsoft.AspNetCore.Mvc;

namespace user_permissions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class permissionController : ControllerBase
    {
        private readonly ILogger<permissionController> _logger;

        public permissionController(ILogger<permissionController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Getpermisstions")]
        public IEnumerable<Permission> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Permission {}).ToArray();
        }
    }
}
