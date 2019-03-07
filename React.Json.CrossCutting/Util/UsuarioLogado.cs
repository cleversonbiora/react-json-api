using System;
using System.Collections.Generic;
using System.Text;

namespace React.Json.CrossCutting.Util
{
    /// <summary>
    /// Classe Utilizada para Passar os Dados dos Usuários por qualquer camada. Utilizando injeção de dependência
    /// </summary>
    public class UsuarioLogado
    {
        public int PessoaId { get; set; }
    }
}
