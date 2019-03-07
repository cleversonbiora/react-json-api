using Dapper;
using System.Linq;
using System.Data;
using System;
using System.Collections.Generic;
using React.Json.Domain.Repositories;
using React.Json.Domain.Models;

namespace React.Json.Infra.Repositories
{
    public partial class TemplateRepository : ITemplateRepository
    {
   //     public int Insert(Template model)
   //     {
			////TODO: Implementar a chamada de abertura da sua conexão: Ex.:  using (var conn = ConnectionFactory.GetOpenConnection())
   //         using (var conn = null)
   //         {
   //             IDbTransaction trans = conn.BeginTransaction();
   //             try
   //             {
			//		//Insere o template
   //                 var id = conn.Query<int>(QueryInsert, model, trans).Single();

   //                 trans.Commit();

   //                 return id;
   //             }
   //             catch (Exception ex)
   //             {
   //                 trans.Rollback();

   //                 throw ex;
   //             }
   //         }
   //     }
		
   //     public bool Update(Template model)
   //     {
			////TODO: Implementar a chamada de abertura da sua conexão: Ex.:  using (var conn = ConnectionFactory.GetOpenConnection())
   //         using (var conn = null) 
   //         {
   //             IDbTransaction trans = conn.BeginTransaction();

   //             try
   //             {
			//		//Atualizar template
			//		conn.Query(QueryUpdate, model, trans);

   //                 trans.Commit();
   //                 return true;
   //             }
   //             catch (Exception ex)
   //             {
   //                 trans.Rollback();
   //                 throw;
   //             }
   //         }
   //     }
		
   //     public bool Delete(int id)
   //     {
			
			////TODO: Implementar a chamada de abertura da sua conexão: Ex.:  using (var conn = ConnectionFactory.GetOpenConnection())
   //         using (var conn = null)
   //         {
   //             IDbTransaction trans = conn.BeginTransaction();

   //             try
   //             {
			//		//Delete template
			//		conn.Query(QueryDelete, new { id }, trans);

   //                 trans.Commit();
   //                 return true;
   //             }
   //             catch (Exception ex)
   //             {
   //                 trans.Rollback();
   //                 throw;
   //             }
   //         }
   //     }
      
        public Template GetById(int id)
        {
            using (var conn = ConnectionFactory.GetJsonOpenConnection())
			{
				return conn.Query<Template>(QuerySelectById, new { Id = id }).FirstOrDefault();
			}
        }

   //     public List<Template> GetAll()
   //     {
			////TODO: Implementar a chamada de abertura da sua conexão: Ex.:  using (var conn = ConnectionFactory.GetOpenConnection())
   //         using (var conn = null)
			//{
			//	return conn.Query<Template>(QuerySelectAll).ToList();
			//}
   //     }

   //     public List<Template> GetAllGrid()
   //     {
			////TODO: Implementar a chamada de abertura da sua conexão: Ex.:  using (var conn = ConnectionFactory.GetOpenConnection())
   //         using (var conn = null)
			//{
			//	return conn.Query<Template>(QuerySelectAllGrid).ToList();
			//}
   //     }
    }
}
