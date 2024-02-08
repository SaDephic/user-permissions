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
using Npgsql;
using user_permissions.Models;

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class PermissionApiController : ControllerBase
    {
        /// <summary>
        /// Получение доступов пользователя по информации, содержащейся в bearer token
        /// </summary>
        /// <remarks>Получение доступов пользователя по информации, содержащейся в bearer token</remarks>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="0">unexpected error</response>
        [HttpGet]
        [Route("/permissions")]
        [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerOperation("GetUserPermissions")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserPermissions), description: "Successful operation")]
        [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Bad Request")]
        [SwaggerResponse(statusCode: 500, type: typeof(Error), description: "Internal Server Error")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]

        public IActionResult GetUserPermissions() {

          /*  using (var conn = new NpgsqlConnection())
            {
                testQuery = "select 'HITHERE' as firstval, 'HOTHERE' as secondval;";
                var results = DataContext.Database.SqlQuery<List<string>>(testQuery);
            }*/
                // получить из базы данные ...
                return new ObjectResult(JsonConvert.DeserializeObject<UserPermissions>("{\n  \"permissions\" : [ \"permissions\", \"permissions\" ],\n  \"userRole\" : \"userRole\"\n}"));
        }
        /*public virtual IActionResult GetUserPermissions()
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(UserPermissions));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500, default(Error));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Error));
            string exampleJson = null;
            exampleJson = "{\n  \"permissions\" : [ \"permissions\", \"permissions\" ],\n  \"userRole\" : \"userRole\"\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<UserPermissions>(exampleJson)
                        : default(UserPermissions);            //TODO: Change the data returned
            return new ObjectResult(example);
        }*/
    }
}
