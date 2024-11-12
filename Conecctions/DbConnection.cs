using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace EmpresaVendas.Conecctions
{
    public class DbConnection : IDisposable
    {
        public NpgsqlConnection Connection { get; set; }

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
            Connection.Close();
        }
    }
}
