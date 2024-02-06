using Microsoft.AspNetCore.Mvc;

namespace user_permissions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class userRoleController : ControllerBase
    {
        [HttpGet(Name = "GetuserRoles")]
        public IEnumerable<User> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new User {
                userLogin = Random.Shared.Next(-20, 55).ToString(),
                userRole = Random.Shared.Next(-20, 55).ToString(),
                id = Random.Shared.Next(-20, 55).ToString()
            }).ToArray();
        }

        [HttpPost(Name = "PostuserRoles")]
        public IEnumerable<User> Post()
        {
            return Enumerable.Range(1, 5).Select(index => new User { }).ToArray();
        }

        [HttpPut(Name = "PutuserRoles")]
        public IEnumerable<User> Put()
        {
            return Enumerable.Range(1, 5).Select(index => new User { }).ToArray();
        }

        [HttpDelete(Name = "GetuserRoles")]
        public IEnumerable<User> Delete()
        {
            return Enumerable.Range(1, 5).Select(index => new User { }).ToArray();
        }
    }
}
