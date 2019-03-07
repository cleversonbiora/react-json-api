using System;
using System.Collections.Generic;
using System.Text;
using React.Json.AppServices.Commands.Json;
using React.Json.AppServices.ViewModels;

namespace React.Json.AppServices.Interfaces
{
    public interface IJsonNodeAppService
    {
        JsonNodeViewModel GetById(int Id);
    }
}
