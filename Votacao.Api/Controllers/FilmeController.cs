using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Votacao.Domain.Commands.Inputs.Filme;
using Votacao.Domain.Handlers;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Queries;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    [Route("api/v1")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _repository;
        private readonly FilmeHandler _handler;

        public FilmeController(IFilmeRepository repository, FilmeHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("filme")]
        public ICommandResult InserirFilme([FromBody] AdicionarFilmeCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("filme/{id}")]
        public ICommandResult AtualizarFilme(long id, [FromBody] AtualizarFilmeCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("filme/{id}")]
        public ICommandResult ExcluirFilme(long id)
        {
            var command = new ExcluirFilmeCommand() {Id = id};
            return _handler.Handle(command);
        }
        
        [HttpGet]
        [Route("filmes")]
        public List<FilmeQueryResult> ListarFilmes()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("filme/{id}")]
        public FilmeQueryResult ObterFilme(long id)
        {
            return _repository.Obter(id);
        }
    }
}