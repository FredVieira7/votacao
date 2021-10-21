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
    public class FilmeRepository : IFilmeRepository
    {
        private readonly DynamicParameters _parameters = new();
        private readonly DataContext _dataContext;

        public FilmeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public long Inserir(Filme filme)
        {
            try
            {
                _parameters.Add("Id", filme.IdFilme, DbType.Int64);
                _parameters.Add("Titulo", filme.Titulo, DbType.String);
                _parameters.Add("Diretor", filme.Diretor, DbType.String);
                return _dataContext.SqlServerConnection.ExecuteScalar<long>(FilmeQueries.Inserir, _parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Atualizar(Filme filme)
        {
            try
            {
                _parameters.Add("Id", filme.IdFilme, DbType.Int64);
                _parameters.Add("Titulo", filme.Titulo, DbType.String);
                _parameters.Add("Diretor", filme.Diretor, DbType.String);
                _dataContext.SqlServerConnection.Execute(FilmeQueries.Atualizar, _parameters);
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
                _dataContext.SqlServerConnection.Execute(FilmeQueries.Excluir, _parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<FilmeQueryResult> Listar()
        {
            try
            {
                return _dataContext.SqlServerConnection.Query<FilmeQueryResult>(FilmeQueries.Listar).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public FilmeQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);
                return _dataContext.SqlServerConnection.Query<FilmeQueryResult>(FilmeQueries.Obter, _parameters).FirstOrDefault();
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
                return _dataContext.SqlServerConnection.Query<bool>(FilmeQueries.CheckId, _parameters).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}