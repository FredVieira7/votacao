using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Votacao.Domain.Commands.Inputs.Autenticacao;
using Votacao.Domain.Commands.Outputs;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Infra.Interfaces.Commands;
using Votacao.Infra.Settings;

namespace Votacao.Domain.Handlers
{
    public class AutenticacaoHandler : ICommandHandler<AutenticarCommand>
    {
        private readonly IUsuarioRepository _repository;
        private readonly AppSettings _settings;

        public AutenticacaoHandler(IUsuarioRepository repository, AppSettings settings)
        {
            _repository = repository;
            _settings = settings;
        }

        public ICommandResult Handle(AutenticarCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AutenticacaoCommandResult(false, "Corrija os erros.",
                        command.Notifications);

                if (!_repository.Autenticar(command.Login, command.Senha))
                    return new AutenticacaoCommandResult(false, "Login ou senha inválido.", new { });
                
                return new AutenticacaoCommandResult(true, "Token criado", GerarToken(command.Login));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private object GerarToken(string login)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, login));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _settings.Issuer,
                Audience = _settings.Audience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddMinutes(_settings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            });
            var encodedToken = tokenHandler.WriteToken(token);

            return new 
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromMinutes(_settings.Expiration).TotalSeconds
            };
        }
    }
}