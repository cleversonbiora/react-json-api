using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using React.Json.Domain.Interfaces;
using React.Json.Domain.Models;
using React.Json.Domain.Repositories;

namespace React.Json.Domain.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _templateRepository;

        public TemplateService(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public Template GetById(int id)
        {
            return _templateRepository.GetById(id);
        }

  //      public List<Template> GetAll()
  //      {
  //          return _templateRepository.GetAll();
  //      }

  //      public List<Template> GetAllGrid()
  //      {
  //          return _templateRepository.GetAllGrid();
  //      }
		
		//public int Insert(Template model)
  //      {
  //          return _templateRepository.Insert(model);
  //      }
     
  //      public bool Update(Template model)
  //      {
  //          return _templateRepository.Update(model);
  //      }
		
		//public bool Delete(int id)
  //      {
  //          return _templateRepository.Delete(id);
  //      }
    }
}
