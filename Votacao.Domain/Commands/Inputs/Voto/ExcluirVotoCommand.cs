using System;
using System.Text.Json.Serialization;
using Flunt.Notifications;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Inputs.Voto
{
    public class ExcluirVotoCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (Id < 0)
                    AddNotification("Id", "O id do voto inválido.");

                return Valid;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}