using System;
using System.Collections.Generic;
using System.Text;
using React.Json.Domain.Models;

namespace React.Json.Domain.Interfaces
{
    public interface IPageService
    {
		Page GetById(int id);
        List<Page> GetAll();
		List<Page> GetAllGrid();
		int Insert(Page model);
        bool Update(Page model);
		bool Delete(int id);
    }
}
