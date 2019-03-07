using FluentValidator.Validation;

namespace React.Json.AppServices.Commands.Json
{
    public class JsonCommandContract : IContract
    {
        public ValidationContract Contract { get; }

        public JsonCommandContract()
        {
            Contract = new ValidationContract()
            .Requires()
            .IsNotNullOrEmpty("Campo", "Campo", "O campo Nome é obrigatório");
        }

        public JsonCommandContract(JsonCommand command)
        {
            Contract = new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(command.Assunto, "Asunto", "O Assunto não pode ser nulo")
                .HasMinLen(command.Assunto, 5, "Assunto", "O Assunto deve ter mais de 5 caracteres")
                .HasMaxLen(command.Assunto, 100, "Assunto", "O Assunto deve ter menos de 100 caracteres");
        }

        public JsonCommandContract(InserirJsonCommand command)
        {
            Contract = new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(command.Assunto, "Asunto", "O Assunto não pode ser nulo")
                .HasMinLen(command.Assunto, 5, "Assunto", "O Assunto deve ter mais de 5 caracteres")
                .HasMaxLen(command.Assunto, 100, "Assunto", "O Assunto deve ter menos de 100 caracteres");
        }
    }
}
