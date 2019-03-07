using FluentValidator.Validation;
using System;

namespace React.Json.AppServices.Commands.Template
{
    public class TemplateContract : IContract
    {
        public ValidationContract Contract { get; }

        public TemplateContract(InsertTemplateCommand command)
        {
            Contract = new ValidationContract()
            .Requires()
            .IsNotNullOrEmpty("Campo", "Campo", "O campo Nome é obrigatório");
        }

        public TemplateContract(UpdateTemplateCommand command)
        {
            Contract = new ValidationContract()
            .Requires()
            .IsGreaterThan(1, 0, "Id", "O campo Id é obrigatório");
        }
		
		public TemplateContract(int id)
        {
            Contract = new ValidationContract()
            .Requires()
            .IsLowerOrEqualsThan(id, 0, "Id", "O campo Id é obrigatório");
        }
    }
}
