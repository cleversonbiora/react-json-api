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
using System.Text.RegularExpressions;

namespace React.Json.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors("Cors")]
    public class PageController : BaseController
    {
        private readonly IPageAppService _PageAppService;
        private readonly ITemplateAppService _TemplateAppService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageAppService"></param>
        public PageController(IPageAppService PageAppService, ITemplateAppService TemplateAppService)
        {
            _PageAppService = PageAppService;
            _TemplateAppService = TemplateAppService;
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("v1/Page/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var layout = "";
                using (StreamReader sr = new StreamReader(Path.GetFullPath("Views/Home/Index.json")))
                {
                    layout = sr.ReadToEnd();
                }
                var regex = new Regex(@"{\s*\""template""\s*:\s*[0-9]\s*}");
                var regexId = new Regex(@"[0-9]+");
                var matches = regex.Matches(layout);
                foreach (var match in matches)
                {
                    var ids = regexId.Matches(match.ToString()).FirstOrDefault();
                    if(Int32.TryParse(ids.Value.FirstOrDefault().ToString(),  out int templateId))
                    {
                        TemplateViewModel temp = _TemplateAppService.GetById(templateId);
                        if(temp != null)
                        {
                            layout = layout.Replace(match.ToString(), JsonConvert.SerializeObject(temp.Json));
                        }
                    }
                }
                dynamic a = JsonConvert.DeserializeObject(layout);
                return await Response(a, null);
            }
            catch (Exception ex)
            {
                return await Response(null, new List<Notification> { new Notification("Page", ex.Message) });
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        //[HttpGet, Route("v1/Page")]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
        //        var result = _PageAppService.GetAll();

        //        return await Response(result, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Response(null, new List<Notification> { new Notification("Page", ex.Message) });
        //    }
        //}

        /// <summary>
        /// </summary>
        /// <returns></returns>
        //[HttpGet, Route("v1/Page/grid")]
        //public async Task<IActionResult> GetAllGrid()
        //{
        //    try
        //    {
        //        var result = _PageAppService.GetAllGrid();

        //        return await Response(result, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Response(null, new List<Notification> { new Notification("Page", ex.Message) });
        //    }
        //}

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        //[HttpPost, Route("v1/Page")]
        //public async Task<IActionResult> Post([FromBody]InsertPageCommand command)
        //{
        //    if (command == null)
        //        return await Response(null, new List<Notification> { new Notification("Page", "Page inválido") });

        //    try
        //    {
        //        var contract = new PageContract(command);

        //        if (contract.Contract.Invalid)
        //        {
        //            Logger.Warning("Permissão: Page, incluir com erros", JsonConvert.SerializeObject(command), JsonConvert.SerializeObject(contract.Contract.Notifications));
        //            return await Response(command, contract.Contract.Notifications);
        //        }

        //        var result = _PageAppService.Insert(command);

        //        return await Response(result, contract.Contract.Notifications);
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Response(null, new List<Notification> { new Notification("Page", ex.Message) });
        //    }
        //}

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        //[HttpPut, Route("v1/Page")]
        //public async Task<IActionResult> Put([FromBody]UpdatePageCommand command)
        //{
        //    try
        //    {
        //        if (command == null)
        //            return await Response(null, new List<Notification> { new Notification("Page", "Page inválido") });

        //        var contract = new PageContract(command);

        //        if (contract.Contract.Invalid)
        //        {
        //            return await Response(command, contract.Contract.Notifications);
        //        }

        //        var result = _PageAppService.Update(command);

        //        return await Response(result, contract.Contract.Notifications);
        //    }
        //    catch (Exception ex)
        //    {
        //        return await Response(null, new List<Notification> { new Notification("Page", ex.Message) });
        //    }
        //}


        ///// <summary>
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpDelete, Route("v1/Page/{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        var contract = new PageContract(id);

        //        if (contract.Contract.Invalid)
        //        {
        //            return await Response(id, contract.Contract.Notifications);
        //        }

        //        var result = _PageAppService.Delete(id);

        //        return await Response(result, contract.Contract.Notifications);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error("Permissão: Page, excluir", ex, JsonConvert.SerializeObject(id));
        //        return await Response(null, new List<Notification> { new Notification("Page", ex.Message) });
        //    }
        //}
    }
}
