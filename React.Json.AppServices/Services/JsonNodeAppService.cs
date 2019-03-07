using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using React.Json.AppServices.Commands.Template;
using React.Json.Domain.Models;
using React.Json.Domain.Interfaces;
using React.Json.AppServices.ViewModels;
using React.Json.AppServices.Interfaces;

namespace React.Json.AppServices.Services
{
    public class JsonNodeAppService : IJsonNodeAppService
    {
        private readonly IMapper _mapper;
        private readonly IJsonNodeService _jsonNodeService;
        private readonly IJsonAttributeService _jsonAttributeService;

        public JsonNodeAppService(IMapper mapper, IJsonNodeService jsonNodeService, IJsonAttributeService jsonAttributeService)
        {
            _mapper = mapper;
            _jsonNodeService = jsonNodeService;
            _jsonAttributeService = jsonAttributeService;
        }

        public JsonNodeViewModel GetById(int id)
        {
            var attributes = _jsonAttributeService.GetAttributes(id);

            JsonNodeViewModel viewModel = new JsonNodeViewModel(attributes);

            return viewModel;
        }


        //     public int Insert(InsertTemplateCommand command)
        //     {
        //         var template = _mapper.Map<Template>(command);

        //         int id = _templateService.Insert(template);

        //return id;
        //     }

        //     public bool Update(UpdateTemplateCommand command)
        //     {
        //         Template model = _mapper.Map<Template>(command);

        //         _templateService.Update(model);

        //         return true;
        //     }
        //public List<TemplateViewModel> GetAll()
        //{
        //    var lstModel = _templateService.GetAll();

        //    List<TemplateViewModel> lstViewModel = _mapper.Map<List<TemplateViewModel>>(lstModel);

        //    return lstViewModel;
        //}

        //public List<TemplateViewModel> GetAllGrid()
        //{
        //    var lstModel = _templateService.GetAllGrid();

        //    List<TemplateViewModel> lstViewModel = _mapper.Map<List<TemplateViewModel>>(lstModel);

        //    return lstViewModel;
        //}

        //public bool Delete(int id)
        //{       
        //    _templateService.Delete(id);

        //    return true;
        //}
    }
}
