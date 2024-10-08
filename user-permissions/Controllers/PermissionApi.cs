/*
 * user-permissions
 *
 * Получение роли и доступов, настройка ролей пользователей в админке
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using IO.Swagger.Attributes;
using IO.Swagger.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using user_permissions;

namespace IO.Swagger.Controllers
{
    [ApiController]
    public class PermissionApiController : ControllerBase
    {
        public PermissionApiController(DataContext dbContext)
        {
            this.context = dbContext;
        }

        private readonly DataContext context;

        private string? GetJWT()
        {
            var authHeader = Request.Headers["Authorization"];
            if (authHeader.Count == 0)
            {
                return null;
            }
            var jwt = authHeader[0];
            if (jwt == null || !jwt.StartsWith("Bearer "))
            {
                return null;
            }
            return jwt.Substring("Bearer ".Length);
        }

        [EnableCors("APIPolicy")]
        [HttpGet]
        [Route("/permissions")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerOperation("GetUserPermissions")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserPermissions), description: "Successful operation")]
        [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Bad Request")]
        [SwaggerResponse(statusCode: 500, type: typeof(Error), description: "Internal Server Error")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public /*virtual*/ IActionResult GetUserPermissions()
        {
            var jwt = GetJWT();
            if (jwt == null)
            {
                return BadRequest();
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwt) as JwtSecurityToken;
            if (jsonToken == null)
            {
                return BadRequest();
            }

            var login = jsonToken.Payload
                .Where(pl => pl.Key == "login")
                .Select(pl => pl.Value)
                .FirstOrDefault();
            if (login == null)
            {
                return BadRequest();
            }

            var userRole = context.UserRoles
                .Where(ur => ur.UserLogin == login)
                .FirstOrDefault();
            if (userRole == null)
            {
                return NotFound();
            }

            var permission = context.Permissions
                .Where(p => p.UserRole == userRole._UserRole)
                .FirstOrDefault();
            if (permission == null)
            {
                return NotFound();
            }

            return new ObjectResult(permission);
        }
    }
}
