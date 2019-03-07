using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;
using React.Json.AppServices.Interfaces;
using React.Json.AppServices.Commands.Template;
using React.Json.AppServices.ViewModels;
using FluentValidator;

namespace React.Json.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors("Cors")]
    public class TemplateController : BaseController
    {
        private readonly ITemplateAppService _TemplateAppService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TemplateAppService"></param>
        public TemplateController(ITemplateAppService TemplateAppService)
        {
            _TemplateAppService = TemplateAppService;
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("v1/Template/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = _TemplateAppService.GetById(id);

                return await Response(result, null);
            }
            catch (Exception ex)
            {
                return await Response(null, new List<Notification> { new Notification("Template", ex.Message) });
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        //[HttpGet, Route("v1/Template")]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
        //        var result = _TemplateAppService.GetAll();

        //        return await Response(result, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Response(null, new List<Notification> { new Notification("Template", ex.Message) });
        //    }
        //}

        /// <summary>
        /// </summary>
        /// <returns></returns>
        //[HttpGet, Route("v1/Template/grid")]
        //public async Task<IActionResult> GetAllGrid()
        //{
        //    try
        //    {
        //        var result = _TemplateAppService.GetAllGrid();

        //        return await Response(result, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Response(null, new List<Notification> { new Notification("Template", ex.Message) });
        //    }
        //}

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        //[HttpPost, Route("v1/Template")]
        //public async Task<IActionResult> Post([FromBody]InsertTemplateCommand command)
        //{
        //    if (command == null)
        //        return await Response(null, new List<Notification> { new Notification("Template", "Template inválido") });

        //    try
        //    {
        //        var contract = new TemplateContract(command);

        //        if (contract.Contract.Invalid)
        //        {
        //            Logger.Warning("Permissão: Template, incluir com erros", JsonConvert.SerializeObject(command), JsonConvert.SerializeObject(contract.Contract.Notifications));
        //            return await Response(command, contract.Contract.Notifications);
        //        }

        //        var result = _TemplateAppService.Insert(command);

        //        return await Response(result, contract.Contract.Notifications);
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Response(null, new List<Notification> { new Notification("Template", ex.Message) });
        //    }
        //}

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        //[HttpPut, Route("v1/Template")]
        //public async Task<IActionResult> Put([FromBody]UpdateTemplateCommand command)
        //{
        //    try
        //    {
        //        if (command == null)
        //            return await Response(null, new List<Notification> { new Notification("Template", "Template inválido") });

        //        var contract = new TemplateContract(command);

        //        if (contract.Contract.Invalid)
        //        {
        //            return await Response(command, contract.Contract.Notifications);
        //        }

        //        var result = _TemplateAppService.Update(command);

        //        return await Response(result, contract.Contract.Notifications);
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Response(null, new List<Notification> { new Notification("Template", ex.Message) });
        //    }
        //}


        ///// <summary>
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpDelete, Route("v1/Template/{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        var contract = new TemplateContract(id);

        //        if (contract.Contract.Invalid)
        //        {
        //            return await Response(id, contract.Contract.Notifications);
        //        }

        //        var result = _TemplateAppService.Delete(id);

        //        return await Response(result, contract.Contract.Notifications);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error("Permissão: Template, excluir", ex, JsonConvert.SerializeObject(id));
        //        return await Response(null, new List<Notification> { new Notification("Template", ex.Message) });
        //    }
        //}
    }
}
