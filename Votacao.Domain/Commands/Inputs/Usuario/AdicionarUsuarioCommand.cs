using System;
using Flunt.Notifications;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Inputs.Usuario
{
    public class AdicionarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                int tamanhoLogin = 20;
                if (string.IsNullOrEmpty(Login))
                    AddNotification("Login", "O login é um campo obrigatório.");
                if (Login.Length > tamanhoLogin) 
                    AddNotification("Login", $"O login deve ser menor do que {tamanhoLogin} caracteres.");
                
                if (string.IsNullOrEmpty(Senha))
                    AddNotification("Senha", "A senha é um campo obrigatório.");
                
                if (string.IsNullOrEmpty(Nome))
                    AddNotification("Nome", "O nome é um campo obrigatório.");

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