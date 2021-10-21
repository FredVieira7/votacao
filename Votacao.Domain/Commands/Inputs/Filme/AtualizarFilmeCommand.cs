using System;
using System.Text.Json.Serialization;
using Flunt.Notifications;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Inputs.Filme
{
    public class AtualizarFilmeCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (Id < 0)
                    AddNotification("Id", "O id é inválido.");
            
                if (string.IsNullOrEmpty(Titulo))
                    AddNotification("Titulo", "O título é um campo obrigatório.");
            
                if (string.IsNullOrEmpty(Diretor))
                    AddNotification("Diretor", "O diretor é um campo obrigatório.");

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