using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace EmpresaVendas.Infra
{
    /// <summary>
    /// Métodos auxiliares para reduzir repetição no uso de NpgsqlCommand e NpgsqlDataReader
    /// </summary>
    public static class NpgsqlExtensions
    {
        /// <summary>
        /// Adiciona um parâmetro nomeado ao comando. Valores nulos são enviados como NULL do banco (DBNull)
        /// </summary>
        public static void AdicionarParametro(this NpgsqlCommand comando, string nome, object valor)
        {
            comando.Parameters.AddWithValue(nome, valor ?? DBNull.Value);
        }

        /// <summary>
        /// Executa o comando e converte cada linha retornada usando a função de mapeamento
        /// </summary>
        public static List<T> LerLista<T>(this NpgsqlCommand comando, Func<IDataRecord, T> mapear)
        {
            var lista = new List<T>();
            using (var leitor = comando.ExecuteReader())
            {
                while (leitor.Read())
                {
                    lista.Add(mapear(leitor));
                }
            }
            return lista;
        }

        //Leitura de colunas pelo nome, tratando NULL do banco

        public static int ObterInt(this IDataRecord registro, string coluna)
        {
            int indice = registro.GetOrdinal(coluna);
            return registro.IsDBNull(indice) ? 0 : registro.GetInt32(indice);
        }

        public static decimal ObterDecimal(this IDataRecord registro, string coluna)
        {
            int indice = registro.GetOrdinal(coluna);
            return registro.IsDBNull(indice) ? 0m : registro.GetDecimal(indice);
        }

        public static string ObterString(this IDataRecord registro, string coluna)
        {
            int indice = registro.GetOrdinal(coluna);
            return registro.IsDBNull(indice) ? null : registro.GetString(indice);
        }
    }
}
