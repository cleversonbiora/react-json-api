using System;
using System.Collections.Generic;
using System.Text;
using React.Json.Domain.Models;

namespace React.Json.Domain.Repositories
{
    public interface IPageRepository
    {
		Page GetById(int id);
		List<Page> GetAll();
		List<Page> GetAllGrid();
        int Insert(Page model);
        bool Update(Page model);
        bool Delete(int id);
    }
}
