using System.Collections.Generic;
using Votacao.Domain.Entidades;
using Votacao.Domain.Queries;

namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository
    {
        long Inserir(Filme usuario);
        void Atualizar(Filme usuario);
        void Excluir(long id);
        List<FilmeQueryResult> Listar();
        FilmeQueryResult Obter(long id);
        bool CheckId(long id);
    }
}