using React.Json.AppServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React.Json.AppServices.ViewModels
{
    public class TemplateViewModel
    {
        //Atributos de Visualização
        public int Id { get; set; }
        public string Description { get; set; }
        
        public int RootNode { get; set;
        }

        public dynamic Json { get; set; }
    }
}
