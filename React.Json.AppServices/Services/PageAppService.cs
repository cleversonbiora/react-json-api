using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using React.Json.AppServices.Commands.Page;
using React.Json.Domain.Models;
using React.Json.Domain.Interfaces;
using React.Json.AppServices.ViewModels;
using React.Json.AppServices.Interfaces;

namespace React.Json.AppServices.Services
{
    public class PageAppService : IPageAppService
    {
        private readonly IMapper _mapper;
        private readonly IPageService _pageService;

        public PageAppService(IMapper mapper, IPageService pageService)
        {
            _mapper = mapper;
            _pageService = pageService;
        }

        public int Insert(InsertPageCommand command)
        {
            var page = _mapper.Map<Page>(command);

            int id = _pageService.Insert(page);

			return id;
        }

        public bool Update(UpdatePageCommand command)
        {
            Page model = _mapper.Map<Page>(command);

            _pageService.Update(model);

            return true;
        }

        public PageViewModel GetById(int id)
        {
            var model = _pageService.GetById(id);

            PageViewModel viewModel = _mapper.Map<PageViewModel>(model);

            return viewModel;
        }

        public List<PageViewModel> GetAll()
        {
            var lstModel = _pageService.GetAll();

            List<PageViewModel> lstViewModel = _mapper.Map<List<PageViewModel>>(lstModel);

            return lstViewModel;
        }
		
        public List<PageViewModel> GetAllGrid()
        {
            var lstModel = _pageService.GetAllGrid();

            List<PageViewModel> lstViewModel = _mapper.Map<List<PageViewModel>>(lstModel);

            return lstViewModel;
        }

        public bool Delete(int id)
        {       
            _pageService.Delete(id);

            return true;
        }
    }
}
