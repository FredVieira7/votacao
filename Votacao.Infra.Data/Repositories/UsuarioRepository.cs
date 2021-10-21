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

namespace SistemaDeVotacao.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository

    {
        private readonly DynamicParameters _parameters = new();
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public long Inserir(Usuario usuario)
        {
            try
            {
                _parameters.Add("Id", usuario.IdUsuario, DbType.Int64);
                _parameters.Add("Nome", usuario.Nome, DbType.String);
                _parameters.Add("Login", usuario.Login, DbType.String);
                _parameters.Add("Senha", usuario.Senha, DbType.String);
                return _dataContext.SqlServerConnection.ExecuteScalar<long>(UsuarioQueries.Inserir, _parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Atualizar(Usuario usuario)
        {
            try
            {
                _parameters.Add("Id", usuario.IdUsuario, DbType.Int64);
                _parameters.Add("Nome", usuario.Nome, DbType.String);
                _parameters.Add("Login", usuario.Login, DbType.String);
                _parameters.Add("Senha", usuario.Senha, DbType.String);
                _dataContext.SqlServerConnection.Execute(UsuarioQueries.Atualizar, _parameters);
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
                _dataContext.MySqlConnection.Execute(UsuarioQueries.Excluir, _parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<UsuarioQueryResult> Listar()
        {
            try
            {
                return _dataContext.SqlServerConnection.Query<UsuarioQueryResult>(UsuarioQueries.Listar).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public UsuarioQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);
                return _dataContext.SqlServerConnection.Query<UsuarioQueryResult>(UsuarioQueries.Obter, _parameters)
                    .FirstOrDefault();
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
                return _dataContext.SqlServerConnection.Query<bool>(UsuarioQueries.CheckId, _parameters).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool Autenticar(string login, string senha)
        {
            try
            {
                _parameters.Add("Login", login, DbType.String);
                _parameters.Add("Senha", senha, DbType.String);
                return _dataContext.SqlServerConnection.Query<bool>(UsuarioQueries.Autenticar, _parameters)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}