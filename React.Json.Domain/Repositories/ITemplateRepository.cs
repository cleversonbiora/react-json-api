using System;
using System.Collections.Generic;
using System.Text;
using React.Json.Domain.Models;

namespace React.Json.Domain.Repositories
{
    public interface ITemplateRepository
    {
		Template GetById(int id);
		//List<Template> GetAll();
		//List<Template> GetAllGrid();
  //      int Insert(Template model);
  //      bool Update(Template model);
  //      bool Delete(int id);
    }
}
