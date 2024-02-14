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
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using user_permissions;

namespace IO.Swagger.Controllers
{
    [ApiController]
    public class UserApiController : ControllerBase
    {
        public UserApiController(DataContext dbContext)
        {
            this.сontext = dbContext;
        }

        private readonly DataContext сontext;

        [EnableCors("APIPolicy")]
        [HttpGet]
        [Route("/usersRoles")]
        [ValidateModelState]
        [SwaggerOperation("GetUsersRoles")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<UsersRoleList>), description: "Successful operation")]
        [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Bad Request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        //[Authorize(Roles = "SUPERUSER")]
        public /*virtual*/ IActionResult GetUsersRoles()
        {
            var userRoles = new UsersRoleList
            {
                Data = сontext.UserRoles.Select(ur => ur).ToList()
            };

            if (userRoles == null)
                return NotFound();

            return StatusCode(200, new ObjectResult(userRoles));
        }

        [EnableCors("APIPolicy")]
        [HttpPost]
        [Route("/usersRoles")]
        [ValidateModelState]
        [SwaggerOperation("AssignUserRole")]
        [SwaggerResponse(statusCode: 201, type: typeof(UserRole), description: "successfull operation")]
        [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Bad Request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        //[Authorize(Roles = "SUPERUSER")]
        public /*virtual*/ IActionResult AssignUserRole([FromBody]UserRole body)
        {
            if (ModelState.IsValid)
            {
                var exisingRole = сontext.UserRoles
                .Where(ur => ur.Id == body.Id)
                .FirstOrDefault();

                if (exisingRole != null)
                {
                    return StatusCode(400, default(Error));
                }

                сontext.UserRoles.Add(body);
                сontext.SaveChanges();

            }
            return StatusCode(201, body);
        }

        [EnableCors("APIPolicy")]
        [HttpDelete]
        [Route("/usersRoles/{id}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteUserRole")]
        [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Bad Request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        //[Authorize(Roles = "SUPERUSER")]
        public /*virtual*/ IActionResult DeleteUserRole([FromRoute][Required]string id)
        {
            var exisingRole = сontext.UserRoles.Where(ur => ur.Id == id).FirstOrDefault();
            if (exisingRole == null)
            {
                return StatusCode(404, default(Error));
            }

            сontext.UserRoles.Remove(exisingRole);
            сontext.SaveChanges();

            return StatusCode(204, default(Error));            
        }

        [EnableCors("APIPolicy")]
        [HttpPut]
        [Route("/usersRoles/{id}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateUserRole")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserRole), description: "successfull operation")]
        [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Bad Request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        //[Authorize(Roles = "SUPERUSER")]
        public /*virtual*/ IActionResult UpdateUserRole([FromBody]UserRole body, [FromRoute][Required]string id)
        {
            var userRole = сontext.UserRoles
                .Where(ur => ur.Id == id)
                .FirstOrDefault();

            if (userRole == null)
            {
                return StatusCode(400, body);
            }

            userRole._UserRole = body._UserRole;
            userRole.UserLogin = body.UserLogin;

            сontext.UserRoles.Update(userRole);
            сontext.SaveChanges();

            return StatusCode(200, userRole);
        }
    }
}
