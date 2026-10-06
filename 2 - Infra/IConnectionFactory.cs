using Npgsql;

namespace EmpresaVendas.Infra
{
    public interface IConnectionFactory
    {
        /// <summary>
        /// Cria uma conexão nova, já aberta. Quem chama é responsável por descartá-la (using)
        /// </summary>
        NpgsqlConnection CriarConexao();
    }
}
