using React.Json.AppServices.Commands.Template;
using React.Json.AppServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace React.Json.AppServices.Interfaces
{
    public interface ITemplateAppService
    {
		TemplateViewModel GetById(int id);
  //      List<TemplateViewModel> GetAll();
		//List<TemplateViewModel> GetAllGrid();
		//int Insert(InsertTemplateCommand command);
  //      bool Update(UpdateTemplateCommand command);
		//bool Delete(int id);
    }
}
