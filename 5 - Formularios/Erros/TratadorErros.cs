using EmpresaVendas._1___Classes.Excecoes;
using EmpresaVendas.Infra;
using System;
using System.Windows.Forms;

namespace EmpresaVendas._5___Formularios.Erros
{
    public class TratadorErros : ITratadorErros
    {
        private readonly ILogger _logger;

        public TratadorErros(ILogger logger)
        {
            _logger = logger;
        }
        private string ObterMensagemTratada(Exception ex)
        {
            if (ex is RegraNegocioException)
            {
                return ex.Message;
            }
            //metodo para tratar todos os erros com uma mensagem padrão
            return "Ocorreu um erro. Verifique o Log do dia " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " para mais detalhes";
        }
      
        public void Tratar(string message, Exception ex = null)
        {
             
            bool isRegraNegocioException = ex is RegraNegocioException;
            string texto = message ?? "Ocorreu um erro não tratado.";
            if (isRegraNegocioException)
            {
                _logger.LogWarning(texto + ": " + ex.Message);
            }
            else
            {

                _logger.LogError(texto, ex);
            }          
            string titulo = isRegraNegocioException ? "Aviso" : "Erro";
            MessageBoxIcon icon = isRegraNegocioException ? MessageBoxIcon.Warning : MessageBoxIcon.Error;
             MessageBox.Show(ObterMensagemTratada(ex), titulo, MessageBoxButtons.OK, icon);

        }
    }
}
