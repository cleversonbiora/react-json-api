using Dapper;
using System.Linq;
using System.Data;
using System;
using System.Collections.Generic;
using React.Json.Domain.Repositories;
using React.Json.Domain.Models;

namespace React.Json.Infra.Repositories
{
    public partial class PageRepository : IPageRepository
    {
        public int Insert(Page model)
        {
			//TODO: Implementar a chamada de abertura da sua conexão: Ex.:  using (var conn = ConnectionFactory.GetOpenConnection())
            using (var conn = ConnectionFactory.GetJsonOpenConnection())
            {
                IDbTransaction trans = conn.BeginTransaction();
                try
                {
					//Insere o page
                    var id = conn.Query<int>(QueryInsert, model, trans).Single();

                    trans.Commit();

                    return id;
                }
                catch (Exception ex)
                {
                    trans.Rollback();

                    throw ex;
                }
            }
        }
		
        public bool Update(Page model)
        {
			//TODO: Implementar a chamada de abertura da sua conexão: Ex.:  using (var conn = ConnectionFactory.GetOpenConnection())
            using (var conn = ConnectionFactory.GetJsonOpenConnection()) 
            {
                IDbTransaction trans = conn.BeginTransaction();

                try
                {
					//Atualizar page
					conn.Query(QueryUpdate, model, trans);

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
		
        public bool Delete(int id)
        {
			
			//TODO: Implementar a chamada de abertura da sua conexão: Ex.:  using (var conn = ConnectionFactory.GetOpenConnection())
            using (var conn = ConnectionFactory.GetJsonOpenConnection())
            {
                IDbTransaction trans = conn.BeginTransaction();

                try
                {
					//Delete page
					conn.Query(QueryDelete, new { id }, trans);

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
      
        public Page GetById(int id)
        {
			//TODO: Implementar a chamada de abertura da sua conexão: Ex.:  using (var conn = ConnectionFactory.GetOpenConnection())
            using (var conn = ConnectionFactory.GetJsonOpenConnection())
			{
				return conn.Query<Page>(QuerySelectById, new { Id = id }).FirstOrDefault();
			}
        }

        public List<Page> GetAll()
        {
			//TODO: Implementar a chamada de abertura da sua conexão: Ex.:  using (var conn = ConnectionFactory.GetOpenConnection())
            using (var conn = ConnectionFactory.GetJsonOpenConnection())
			{
				return conn.Query<Page>(QuerySelectAll).ToList();
			}
        }

        public List<Page> GetAllGrid()
        {
			//TODO: Implementar a chamada de abertura da sua conexão: Ex.:  using (var conn = ConnectionFactory.GetOpenConnection())
            using (var conn = ConnectionFactory.GetJsonOpenConnection())
			{
				return conn.Query<Page>(QuerySelectAllGrid).ToList();
			}
        }
    }
}
