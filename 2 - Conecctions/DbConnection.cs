using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Npgsql;
using NPOI.OpenXmlFormats.Dml;
using NPOI.SS.Formula.Functions;

namespace EmpresaVendas.Conecctions
{
    public class DbConnection<T>where T : class
    {
        private NpgsqlConnection Connection { get; set; }

        public DbConnection()
        {
            try
            {
                //INICIA CONEXÃO COM O MEU BANCO DE DADOS
                Connection = new NpgsqlConnection("Server=localhost;Port=5433;Database=empresa_venda;User ID=postgres;Password=123456");
                Connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //FINALIZADO A CONEXÃO COM O BANCO APÓS TERMINAR DE USA-LA
        public void Dispose()
        {
            if (Connection.State == ConnectionState.Open) {
                Connection.Close();
            }
        }
        public void ExecutaBloco(Action<NpgsqlTransaction> action)
        {
            
            using (var transaction = Connection.BeginTransaction()) {
                try
                {
                    action(transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;                
                }    
            }
        }
        public object ExecuteScalarMetodo(string sql, object param, NpgsqlTransaction transaction = null)
        {                    
                return Connection.ExecuteScalar<object>(sql, param, transaction);           
        }
        
        public int Executar(string sql, object param = null, NpgsqlTransaction transaction = null)
        {
            try 
            { 
                return transaction == null ? Connection.Execute(sql, param) : Connection.Execute(sql, param, transaction);
            } 
            catch (Exception ex) 
            {
                throw ex;
            }
            
        }
        public IEnumerable<T> ColetaValoresDoBanco(string sql, object param = null)
        {
           return Connection.Query<T>(sql, param);
        }
        public object ColetaDadosBanco(string sql, object param = null)
        {
            try 
            { 
                return Connection.QuerySingleOrDefault<(int estoque, decimal preco_produto)>(sql, param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object VerificarnoBanco(string sql, object param = null)
        {
            //VERIFICA UM DADO NO BANCO DE ACORDO COM O ID E ME ARMAZENA EM UM OBJ
            try 
            { 
                return Connection.ExecuteScalar(sql, param);
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<T> Consulta(string sql, object param = null)
        {
            try
            {
                return param == null ? Connection.Query<T>(sql) : Connection.Query<T>(sql, param);

            }
            catch (Exception ex) 
            {
                return null;
            }

        }
        
    }
}
