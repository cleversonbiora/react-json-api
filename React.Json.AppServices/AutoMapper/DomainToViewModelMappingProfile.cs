using AutoMapper;
using React.Json.AppServices.ViewModels;
using React.Json.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace React.Json.AppServices.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {

			//Page
			CreateMap<Page, PageViewModel>();

			CreateMap<Template, TemplateViewModel>();
        }
    }
}
