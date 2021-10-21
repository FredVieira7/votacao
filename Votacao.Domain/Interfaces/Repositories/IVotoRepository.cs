using System.Collections.Generic;
using Votacao.Domain.Entidades;
using Votacao.Domain.Queries;

namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IVotoRepository
    {
        long Inserir(Voto voto);
        void Excluir(long id);
        List<VotoQueryResult> Listar();
        VotoQueryResult Obter(long id);
        bool CheckId(long id);
    }
}