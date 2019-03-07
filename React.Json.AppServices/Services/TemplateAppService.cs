using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using React.Json.AppServices.Commands.Template;
using React.Json.Domain.Models;
using React.Json.Domain.Interfaces;
using React.Json.AppServices.ViewModels;
using React.Json.AppServices.Interfaces;
using System.Dynamic;
using React.Json.CrossCutting.Extensions;
using React.Json.CrossCutting.Enums;

namespace React.Json.AppServices.Services
{
    public class TemplateAppService : ITemplateAppService
    {
        private readonly IMapper _mapper;
        private readonly ITemplateService _templateService;
        private readonly IJsonAttributeService _jsonAttributeService;
        private readonly IJsonNodeService _jsonNodeService;

        public TemplateAppService(IMapper mapper, ITemplateService templateService, IJsonAttributeService jsonAttributeService, IJsonNodeService jsonNodeService)
        {
            _mapper = mapper;
            _templateService = templateService;
            _jsonAttributeService = jsonAttributeService;
            _jsonNodeService = jsonNodeService;
        }

        public TemplateViewModel GetById(int id)
        {
            var model = _templateService.GetById(id);

            TemplateViewModel viewModel = _mapper.Map<TemplateViewModel>(model);
            if (viewModel.RootNode > 0)
            {
                viewModel.Json = GetNode(viewModel.RootNode);
            }
            return viewModel;
        }
        public List<ExpandoObject> GetNodes(int id)
        {
            var nodes = new List<ExpandoObject>();
            foreach (var item in _jsonNodeService.GetNodes(id))
            {
                nodes.Add(GetNode(item.Id));
            }
            return nodes;
        }

        public ExpandoObject GetNode(int id)
        {
            var json = new ExpandoObject();
            foreach (var item in _jsonAttributeService.GetAttributes(id))
            {
                switch (item.Type)
                {
                    case JsonType.String:
                        json.TryAdd(item.Description, item.Value);
                        break;
                    case JsonType.Int:
                        json.TryAdd(item.Description, Int32.Parse(item.Value));
                        break;
                    case JsonType.Decimal:
                        json.TryAdd(item.Description, Decimal.Parse(item.Value));
                        break;
                    case JsonType.Bool:
                        json.TryAdd(item.Description, Boolean.Parse(item.Value));
                        break;
                    case JsonType.Char:
                        json.TryAdd(item.Description, Char.Parse(item.Value));
                        break;
                    case JsonType.Object:
                        json.TryAdd(item.Description, GetNode(Int32.Parse(item.Value)));
                        break;
                    case JsonType.Array:
                        json.TryAdd(item.Description, GetNodes(item.Id));
                        break;
                }
            }
            return json;
        }
    }
}
