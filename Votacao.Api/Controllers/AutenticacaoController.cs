using Microsoft.AspNetCore.Mvc;
using Votacao.Domain.Commands.Inputs.Autenticacao;
using Votacao.Domain.Handlers;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Route("autenticar")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly AutenticacaoHandler _handler;

        public AutenticacaoController(AutenticacaoHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("signin")]
        public ICommandResult Autenticar([FromBody] AutenticarCommand command)
        {
            return _handler.Handle(command);
        }
        
    }
}