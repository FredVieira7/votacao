using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Queries;
using Votacao.Infra.Data.DataContexts;
using Votacao.Infra.Data.Repositories.Queries;

namespace Votacao.Infra.Data.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        private readonly DynamicParameters _parameters = new();
        private readonly DataContext _dataContext;

        public VotoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public long Inserir(Voto voto)
        {
            try
            {
                _parameters.Add("Id", voto.Id, DbType.Int64);
                _parameters.Add("IdUsuario", voto.IdUsuario, DbType.Int64);
                _parameters.Add("IdFilme", voto.IdFilme, DbType.Int64);
                return _dataContext.SqlServerConnection.ExecuteScalar<long>(VotoQueries.Inserir, _parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Excluir(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);
                _dataContext.SqlServerConnection.Execute(VotoQueries.Excluir, _parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<VotoQueryResult> Listar()
        {
            try
            {
                return _dataContext.SqlServerConnection.Query<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult ,VotoQueryResult>(
                    VotoQueries.Listar,
                    map: ((voto, usuario, filme) =>
                    {
                        voto.Filme = filme;
                        voto.Usuario = usuario;

                        return voto;
                    }),
                    splitOn: "IdUsuario,IdFilme"
                    ).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public VotoQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);
                return _dataContext.SqlServerConnection.Query<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult ,VotoQueryResult>(
                    VotoQueries.Obter,
                    map: ((voto, usuario, filme) =>
                    {
                        voto.Filme = filme;
                        voto.Usuario = usuario;

                        return voto;
                    }),
                    splitOn: "IdUsuario,IdFilme",
                    param: _parameters
                ).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool CheckId(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);
                return _dataContext.SqlServerConnection.Query<bool>(VotoQueries.CheckId, _parameters).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}