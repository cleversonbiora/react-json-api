namespace React.Json.AppServices.Commands.Json
{
    public class JsonCommand
    {
        public int StatusId { get; set; }
        public byte TipoEnvioId { get; set; }
        public string Remetente { get; set; }
        public string Destinatario { get; set; }
        public string DestinatarioCC { get; set; }
        public string DestinatarioCCO { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
    }
}
