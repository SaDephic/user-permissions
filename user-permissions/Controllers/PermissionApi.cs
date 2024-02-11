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
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using NuGet.Protocol;

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("/permissions")]
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

        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerOperation("GetUserPermissions")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserPermissions), description: "Successful operation")]
        [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Bad Request")]
        [SwaggerResponse(statusCode: 500, type: typeof(Error), description: "Internal Server Error")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]

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
        [RequireHttps]
        [HttpGet]
        public ObjectResult GetUserPermissions()
        {
            /*UserPermissions u1 = new() { UserRole = "EMPLOYEE" };//, Permissions = { "1", "2", "3" } };
            UserPermissions u2 = new() { UserRole = "MANAGER" };//, Permissions = { "1", "2", "3" } };
            UserPermissions u3 = new() { UserRole = "HRPARTNER" };//, Permissions = { "1", "2", "3" } };
            UserPermissions u4 = new() { UserRole = "HRDEV" };//, Permissions = { "1", "2", "3" } };*/
            UserPermissions u5 = new() { UserRole = "SUPERUSER" };//, Permissions = { "1", "2", "3" } };
            /*List<UserPermissions> list = new List<UserPermissions>();
            list.Add(u1);
            list.Add(u2);
            list.Add(u3);
            list.Add(u4);
            list.Add(u5);*/
            return new ObjectResult(u5.ToJson());
        }
        /*public IActionResult GetUserPermissions(){
            List<UserPermissions> empList = new ()
            {
                new () {UserRole = "EMPLOYEE", Permissions = {"1","2","3"} },
                new () {UserRole = "MANAGER", Permissions = {"1","2","3"} },
                new () {UserRole = "HRPARTNER", Permissions = {"1","2","3"} },
                new () {UserRole = "HRDEV", Permissions = {"1","2","3"} },
                new () {UserRole = "SUTERUSER", Permissions = {"1","2","3"} }
            };
            return Ok();
        }*/
    }
}
