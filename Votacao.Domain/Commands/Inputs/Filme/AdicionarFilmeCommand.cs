using System;
using Flunt.Notifications;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Inputs.Filme
{
    public class AdicionarFilmeCommand : Notifiable, ICommandPadrao
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public bool ValidarCommand()
        {
            try
            {
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