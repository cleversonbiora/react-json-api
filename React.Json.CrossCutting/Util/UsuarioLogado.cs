using System;
using System.Collections.Generic;
using System.Text;

namespace React.Json.CrossCutting.Util
{
    /// <summary>
    /// Classe Utilizada para Passar os Dados dos Usu�rios por qualquer camada. Utilizando inje��o de depend�ncia
    /// </summary>
    public class UsuarioLogado
    {
        public int PessoaId { get; set; }
    }
}
