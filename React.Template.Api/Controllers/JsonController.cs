using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using React.Json.AppServices.Interfaces;
using React.Json.AppServices.Commands.Json;
using Newtonsoft.Json;
using FluentValidator;

/*------------------------------------------*
 * https://fluentvalidation.net/
*-------------------------------------------*/

namespace React.Json.Api.Controllers
{
    [EnableCors("Cors")]
    public class JsonController : BaseController
    {
        private readonly IJsonAppService _appService;

        public JsonController(IJsonAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// Cadastrar um Turno
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/Json")]
        public async Task<IActionResult> PostAsync([FromBody]InserirJsonCommand command)
        {
            var customerContract = new JsonCommandContract(command);

            if (!customerContract.Contract.Valid)
            {
                return await Response(command, customerContract.Contract.Notifications);
            }
            else
            {
                _appService.Create(command);
                return await Response("", null);
            }
        }
    }
}
