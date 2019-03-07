using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using React.Json.Domain.Interfaces;
using React.Json.Domain.Models;
using React.Json.Domain.Repositories;

namespace React.Json.Domain.Services
{
    public class PageService : IPageService
    {
        private readonly IPageRepository _pageRepository;

        public PageService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public Page GetById(int id)
        {
            return _pageRepository.GetById(id);
        }

        public List<Page> GetAll()
        {
            return _pageRepository.GetAll();
        }

        public List<Page> GetAllGrid()
        {
            return _pageRepository.GetAllGrid();
        }
		
		public int Insert(Page model)
        {
            return _pageRepository.Insert(model);
        }
     
        public bool Update(Page model)
        {
            return _pageRepository.Update(model);
        }
		
		public bool Delete(int id)
        {
            return _pageRepository.Delete(id);
        }
    }
}
