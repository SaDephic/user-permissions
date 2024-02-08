/*
 * user-permissions
 *
 * Получение роли и доступов, настройка ролей пользователей в админке
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;
using IO.Swagger.Security;
using Microsoft.AspNetCore.Authorization;
using IO.Swagger.Models;

namespace IO.Swagger.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class UserApiController : ControllerBase
    {
        /// <summary>
        /// Назначение роли сотруднику
        /// </summary>
        /// <remarks>Назначение роли сотруднику (для админки)</remarks>
        /// <param name="body">Назначить роль пользователю</param>
        /// <response code="201">successfull operation</response>
        /// <response code="400">Bad Request</response>
        /// <response code="0">unexpected error</response>
        [HttpPost]
        [Route("/usersRoles")]
        [ValidateModelState]
        [SwaggerOperation("AssignUserRole")]
        [SwaggerResponse(statusCode: 201, type: typeof(UserRole), description: "successfull operation")]
        [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Bad Request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public virtual IActionResult AssignUserRole([FromBody] UserRole body)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(UserRole));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Error));
            string exampleJson = null;
            exampleJson = "{\n  \"userLogin\" : \"userLogin\",\n  \"id\" : \"id\",\n  \"userRole\" : \"userRole\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<UserRole>(exampleJson)
            : default(UserRole);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Удаление роли сотрудника
        /// </summary>
        /// <remarks>Удаление роли сотрудника (для админки)</remarks>
        /// <param name="id">Идентификатор записи</param>
        /// <response code="204">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not found</response>
        /// <response code="0">unexpected error</response>
        [HttpDelete]
        [Route("/usersRoles/{id}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteUserRole")]
        [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Bad Request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public virtual IActionResult DeleteUserRole([FromRoute][Required] string id)
        {
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Error));

            throw new NotImplementedException();
        }

        /// <summary>
        /// Получение списка сотрудников и их ролей
        /// </summary>
        /// <remarks>Получение списка сотрудников с ролями (для админки)</remarks>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request</response>
        /// <response code="0">unexpected error</response>
        [HttpGet]
        [Route("/usersRoles")]
        [ValidateModelState]
        [SwaggerOperation("GetUsersRoles")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<UsersRoleList>), description: "Successful operation")]
        [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Bad Request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public List<UsersRoleList> GetUserRoles()
        {
            return new List<UsersRoleList>();
        }
        /*public virtual IActionResult GetUsersRoles()
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<UsersRoleList>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Error));
            string exampleJson = null;
            exampleJson = "[ {\n  \"data\" : [ {\n    \"userLogin\" : \"userLogin\",\n    \"id\" : \"id\",\n    \"userRole\" : \"userRole\"\n  }, {\n    \"userLogin\" : \"userLogin\",\n    \"id\" : \"id\",\n    \"userRole\" : \"userRole\"\n  } ]\n}, {\n  \"data\" : [ {\n    \"userLogin\" : \"userLogin\",\n    \"id\" : \"id\",\n    \"userRole\" : \"userRole\"\n  }, {\n    \"userLogin\" : \"userLogin\",\n    \"id\" : \"id\",\n    \"userRole\" : \"userRole\"\n  } ]\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<UsersRoleList>>(exampleJson)
            : default(List<UsersRoleList>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }*/

        /// <summary>
        /// Изменение роли сотрудника
        /// </summary>
        /// <remarks>Изменение роли сотрудника (для админки)</remarks>
        /// <param name="body">Изменить роль сотрудника</param>
        /// <param name="id">Идентификатор записи</param>
        /// <response code="200">successfull operation</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not found</response>
        /// <response code="0">unexpected error</response>
        [HttpPut]
        [Route("/usersRoles/{id}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateUserRole")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserRole), description: "successfull operation")]
        [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Bad Request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public virtual IActionResult UpdateUserRole([FromBody]UserRole body, [FromRoute][Required]string id)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(UserRole));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Error));
            string exampleJson = null;
            exampleJson = "{\n  \"userLogin\" : \"userLogin\",\n  \"id\" : \"id\",\n  \"userRole\" : \"userRole\"\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<UserRole>(exampleJson)
                        : default(UserRole);            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
