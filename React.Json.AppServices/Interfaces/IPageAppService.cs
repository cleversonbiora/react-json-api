using React.Json.AppServices.Commands.Page;
using React.Json.AppServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace React.Json.AppServices.Interfaces
{
    public interface IPageAppService
    {
		PageViewModel GetById(int id);
        List<PageViewModel> GetAll();
		List<PageViewModel> GetAllGrid();
		int Insert(InsertPageCommand command);
        bool Update(UpdatePageCommand command);
		bool Delete(int id);
    }
}
