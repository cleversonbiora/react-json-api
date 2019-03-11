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
using React.Json.AppServices.Commands.Page;
using Newtonsoft.Json.Linq;
using System.Dynamic;

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
        [HttpPost, Route("v1/Page")]
        public async Task<IActionResult> GetPage([FromBody]GetPageCommand command)
        {
            try
            {
                string viewPath = "Views/";
                string title = "Home";
                try
                {
                    if(String.IsNullOrWhiteSpace(command.PathName) || command.PathName.Equals("/"))
                    {
                        viewPath = "Views/Home/Index";
                    }
                    else if(command.PathName.Split('/', StringSplitOptions.RemoveEmptyEntries).Count() == 1)
                    {
                        viewPath = $"Views/{command.PathName.Replace("/","")}/Index";
                    }
                    else
                    {
                        var parts = command.PathName.Split('/', StringSplitOptions.RemoveEmptyEntries);
                        viewPath = $"Views/{parts[0]}/{parts[1]}";
                    }
                }
                catch (Exception)
                {
                    viewPath = "Views/Home/Index";
                }
                var page = LoadView(viewPath);
                dynamic jsonPage = JsonConvert.DeserializeObject<dynamic>(page);
                var id = jsonPage.layout;
                var name = jsonPage.content;
                if(!String.IsNullOrWhiteSpace((string)jsonPage.title))
                {
                    title = jsonPage.title;
                }
                if(!String.IsNullOrWhiteSpace((string)jsonPage.layout))
                {
                    page = LoadView((string)jsonPage.layout);
                    if (jsonPage.content != null)
                    {
                        var regexView = new Regex(@"{\s*\""content\""\s*:\s*[\w-_""./]{1,}\s*\""\s*}");
                        var matchesViews = regexView.Matches(page);
                        foreach (var match in matchesViews)
                        {
                            page = page.Replace(match.ToString(), JsonConvert.SerializeObject(jsonPage.content));
                        }
                    }
                }
                else if(!String.IsNullOrWhiteSpace(jsonPage.content))
                {
                    page = JsonConvert.SerializeObject(jsonPage.content);
                }
                else if (!String.IsNullOrWhiteSpace(jsonPage.type))
                {
                    page = JsonConvert.SerializeObject(jsonPage);
                }
                else
                {
                    return await Response(null, new List<Notification> { new Notification("Page", "Página Mal Formatada") });
                }
                page = LoadViews(page);
                page = LoadTemplates(page);
                dynamic a = JsonConvert.DeserializeObject(page);
                return await Response(new { title = title, body = a}, null);
            }
            catch (Exception ex)
            {
                return await Response(null, new List<Notification> { new Notification("Page", ex.Message) });
            }
        }

        private string LoadTemplates(string layout)
        {
            var regex = new Regex(@"{\s*\""template""\s*:\s*[0-9]\s*}");
            var regexId = new Regex(@"[0-9]+");
            var matches = regex.Matches(layout);
            foreach (var match in matches)
            {
                try
                {
                    var ids = regexId.Matches(match.ToString()).FirstOrDefault();
                    if (int.TryParse(ids.Value.FirstOrDefault().ToString(), out int templateId))
                    {
                        TemplateViewModel temp = _TemplateAppService.GetById(templateId);
                        if (temp != null)
                        {
                            layout = layout.Replace(match.ToString(), JsonConvert.SerializeObject(temp.Json));
                        }
                    }
                }
                catch (Exception ex)
                {
                }

            }

            return layout;
        }

        private static string LoadViews(string layout)
        {
            var regexView = new Regex(@"{\s*\""view\""\s*:\s*[\w-_""./]{1,}\s*\""\s*}");
            var matchesViews = regexView.Matches(layout);
            foreach (var match in matchesViews)
            {
                try
                {
                    dynamic jsonView = JsonConvert.DeserializeObject<dynamic>(match.ToString());
                    string path = jsonView.view;
                    string view = LoadView(path);
                    if (view != "")
                    {
                        layout = layout.Replace(match.ToString(), view);
                    }
                }
                catch (Exception)
                {
                }
            }

            return layout;
        }

        private static string LoadView(string path)
        {
            try
            {
                var ext = Path.GetExtension(path);
                if (String.IsNullOrEmpty(ext))
                    path = $"{path}.json";
                if (path.StartsWith("/"))
                    path = path.Substring(1);
                var view = "";
                using (StreamReader sr = new StreamReader(Path.GetFullPath(path)))
                {
                    view = sr.ReadToEnd();
                }
                return view;
            }
            catch (Exception)
            {
                return "{ \"type\": \"div\", \"value\": \"View Not Found\" }";
            }

        }
    }
}
