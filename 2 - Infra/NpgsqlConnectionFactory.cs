using Npgsql;
using System.Configuration;

namespace EmpresaVendas.Infra
{
    public class NpgsqlConnectionFactory : IConnectionFactory
    {
        //Mesma connection string usada pelos relatórios (DataSet tipado): a senha fica em um único lugar, o App.config
        private const string NomeConnectionString = "EmpresaVendas.Properties.Settings.empresa_vendaConnectionString";

        private readonly string _connectionString;

        public NpgsqlConnectionFactory()
        {
            var configuracao = ConfigurationManager.ConnectionStrings[NomeConnectionString];
            if (configuracao == null || string.IsNullOrWhiteSpace(configuracao.ConnectionString))
            {
                throw new ConfigurationErrorsException($"A connection string \"{NomeConnectionString}\" não foi encontrada no App.config");
            }
            _connectionString = configuracao.ConnectionString;
        }

        public NpgsqlConnection CriarConexao()
        {
            var conexao = new NpgsqlConnection(_connectionString);
            try
            {
                conexao.Open();
                return conexao;
            }
            catch
            {
                //Se não conseguir abrir, descarta o objeto antes de repassar o erro
                conexao.Dispose();
                throw;
            }
        }
    }
}
