using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;

namespace React.Json.Tests.Util
{
    public class Response
    {
        public bool success { get; set; }
        public List<Notification> errors { get; set; }
    }
}
