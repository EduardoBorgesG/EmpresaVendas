using System;

namespace EmpresaVendas._1___Classes.Excecoes
{
    public class RegraNegocioException : Exception
    {
        // Construtor da classe ExceptionPersonalizadas, que herda da classe Exception, permitindo criar exceções personalizadas com mensagens específicas
        // :base chama o construtor da classe base (Exception) com a mensagem fornecida

        public RegraNegocioException(string message) : base(message) {}
        public RegraNegocioException(string message, Exception innerException) : base(message, innerException) { }
    }
}
