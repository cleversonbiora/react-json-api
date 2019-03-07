using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using React.Json.CrossCutting.Util;

namespace React.Json.Api.Middleware
{
    public class UserMiddleware
    {
        private readonly RequestDelegate _next;

        public UserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var dataProviderFactory = context.RequestServices.GetRequiredService<UsuarioLogado>();

            //dataProviderFactory.PessoaId = Convert.ToInt32(context.User.Identity.GetPessoaId());

            await _next(context);
        }
    }
}
