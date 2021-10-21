using System;
using System.Text.Json.Serialization;
using Flunt.Notifications;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Inputs.Filme
{
    public class ExcluirFilmeCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (Id < 0)
                    AddNotification("Id", "O id é inválido.");
                
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