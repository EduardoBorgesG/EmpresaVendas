using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Npgsql;
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
        public int Executar(string sql, object param = null)
        {
            try 
            { 
                return Connection.Execute(sql, param); 
            } 
            catch (Exception ex) 
            {
                throw ex;
            }
            
        }
        public object VerificarnoBanco(string sql, object param = null)
        {
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
