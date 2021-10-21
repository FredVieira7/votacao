using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Votacao.Domain.Commands.Inputs.Voto;
using Votacao.Domain.Handlers;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Queries;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Authorize]
    [Route("v1/api")]
    public class VotoController : ControllerBase
    {
        private readonly IVotoRepository _repository;
        private readonly VotoHandler _handler;

        public VotoController(IVotoRepository repository, VotoHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("voto")]
        public ICommandResult InserirVoto([FromBody] AdicionarVotoCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("voto/{id}")]
        public ICommandResult ExcluirVoto(long id)
        {
            return _handler.Handle(new ExcluirVotoCommand() {Id = id});
        }

        [HttpGet]
        [Route("votos")]
        public List<VotoQueryResult> ListarVotos()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("voto/{id}")]
        public VotoQueryResult ObterVoto(long id)
        {
            return _repository.Obter(id);
        }
    }
}