using FluentValidator.Validation;
using System;

namespace React.Json.AppServices.Commands.Page
{
    public class PageContract : IContract
    {
        public ValidationContract Contract { get; }

        public PageContract(InsertPageCommand command)
        {
            Contract = new ValidationContract()
            .Requires()
            .IsNotNullOrEmpty("Campo", "Campo", "O campo Nome é obrigatório");
        }

        public PageContract(UpdatePageCommand command)
        {
            Contract = new ValidationContract()
            .Requires()
            .IsGreaterThan(1, 0, "Id", "O campo Id é obrigatório");
        }
		
		public PageContract(int id)
        {
            Contract = new ValidationContract()
            .Requires()
            .IsLowerOrEqualsThan(id, 0, "Id", "O campo Id é obrigatório");
        }
    }
}
