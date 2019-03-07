using AutoMapper;
using React.Json.AppServices.ViewModels;
using React.Json.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using React.Json.AppServices.Commands.Page;

namespace React.Json.AppServices.AutoMapper
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
		{
			//Page
			CreateMap<InsertPageCommand, Page>();
			CreateMap<UpdatePageCommand, Page>();

            //Template
            //CreateMap<Template, TemplateViewModel>();
        }
    }
}
