using System;
using Flunt.Notifications;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Inputs.Voto
{
    public class AdicionarVotoCommand : Notifiable, ICommandPadrao
    {
        public long IdUsuario { get; set; }
        public long IdFilme { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (IdUsuario < 0)
                    AddNotification("IdUsuario", "O id do usuário inválido.");
            
                if (IdFilme < 0)
                    AddNotification("IdFilme", "O id do filme inválido.");

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