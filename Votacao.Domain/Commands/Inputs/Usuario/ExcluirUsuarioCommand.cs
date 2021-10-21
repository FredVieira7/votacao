using System.Text.Json.Serialization;
using Flunt.Notifications;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Inputs.Usuario
{
    public class ExcluirUsuarioCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }

        public bool ValidarCommand()
        {
            if (Id < 0)
                AddNotification("Id", "Id inválido.");

            return Valid;
        }
    }
}