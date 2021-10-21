using System;
using Votacao.Domain.Commands.Inputs.Voto;
using Votacao.Domain.Commands.Outputs;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Handlers
{
    public class VotoHandler : ICommandHandler<AdicionarVotoCommand>, ICommandHandler<ExcluirVotoCommand>
    {
        private readonly IVotoRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IFilmeRepository _filmeRepository;

        public VotoHandler(IVotoRepository repository, IUsuarioRepository usuarioRepository, IFilmeRepository filmeRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _filmeRepository = filmeRepository;
        }

        public ICommandResult Handle(AdicionarVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new VotoCommandResult(false, "Corrija os erros.",
                        command.Notifications);
                
                if (!_usuarioRepository.CheckId(command.IdUsuario))
                    return new VotoCommandResult(false, "O usuário não existe.", new { });
                
                if (!_filmeRepository.CheckId(command.IdFilme))
                    return new VotoCommandResult(false, "O filme não existe.", new { });

                long id = 0;
                id = _repository.Inserir(new Voto(id, command.IdUsuario, command.IdFilme));
                return new VotoCommandResult(true, "Voto salvo com sucesso!", new {Id = id});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ICommandResult Handle(ExcluirVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new VotoCommandResult(false, "Corrija os erros.",
                        command.Notifications);
                
                if (!_repository.CheckId(command.Id))
                    return new VotoCommandResult(false, "O voto não existe", new { });
                
                _repository.Excluir(command.Id);
                return new VotoCommandResult(true, "Voto excluído com sucesso!", new { });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }   
        }
    }
}