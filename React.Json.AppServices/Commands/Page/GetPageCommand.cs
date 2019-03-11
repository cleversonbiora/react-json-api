using System;
using System.Collections.Generic;
using System.Text;

namespace React.Json.AppServices.Commands.Page
{
    public class GetPageCommand
    {
        public string PathName { get; set; }
        public string Hash { get; set; }
        public string Search { get; set; }
    }
}
