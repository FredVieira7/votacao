using System;
using Flunt.Notifications;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Inputs.Autenticacao
{
    public class AutenticarCommand : Notifiable, ICommandPadrao
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        
        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Login))
                    AddNotification("Login", "O login é um campo obrigatório.");
                
                if (string.IsNullOrEmpty(Senha))
                    AddNotification("Senha", "A senha é um campo obrigatório.");
                
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