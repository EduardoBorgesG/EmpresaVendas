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
    public class DbConnection<T> : IDisposable where T : class
    {
        private NpgsqlConnection Connection { get; set; }

        public DbConnection()
        {
            try
            {
                //INICIA CONEXÃO COM O MEU BANCO DE DADOS
                Connection = new NpgsqlConnection("Server=localhost;Port=5433;Database=empresa_venda;User ID=postgres;Password=123");
                Connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //FINALIZADO A CONEXÃO COM O BANCO APÓS TERMINAR DE USA-LA
        //CHAMADO AUTOMATICAMENTE PELO CONTAINER DE DI QUANDO O ESCOPO DO FORMULÁRIO É DESCARTADO
        public void Dispose()
        {
            Connection?.Dispose();
        }
        
        //INICIA UMA TRANSAÇÃO PARA AGRUPAR VÁRIOS COMANDOS (TUDO OU NADA)
        public NpgsqlTransaction IniciarTransacao()
        {
            return Connection.BeginTransaction();
        }

        public object ExecuteScalarMetodo(string sql, object param, NpgsqlTransaction transaction = null)
        {        
            //RETORNA O RESULTADO DA MINHA QUERY EM UM OBJECT
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
            //COLETA VALORES E ADICIONAR EM UM IENUMERABLE<T>
           return Connection.Query<T>(sql, param);
        }
        public object ColetaDadosBanco(string sql, object param = null)
        {
            try 
            { 
                //COLETA DADOS DO BANCO MAS SOMENTE A PRIMEIRA LINHA
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
                //PERMITE CONSULTA SEM PARAMETRE E RETORNA T
                return param == null ? Connection.Query<T>(sql) : Connection.Query<T>(sql, param);

            }
            catch (Exception ex) 
            {
                return null;
            }

        }
        
    }
}
