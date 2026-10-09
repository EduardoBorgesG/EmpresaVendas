using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmpresaVendas.Infra
{
    public class ArquivoLogger : ILogger
    {
        private readonly string _logDirectory;
        //Lock para garantir que apenas uma thread escreva no arquivo de log por vez
        private readonly object _trava = new object();

        public ArquivoLogger()
        {
            // Define o caminho do arquivo de log na pasta LocalApplicationData
            string logDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _logDirectory = Path.Combine(logDirectory, "EmpresaVendas", "Logs");
        }
        private void GravaArquivo(string message, string logLevel, Exception ex = null)
        {      
            
            try
            {
                lock (_trava)
                {
                    DateTime dataMomento = DateTime.Now;
                    string nomeArquivoLog = $"log_{dataMomento:yyyy-MM-dd}.txt";
                    string textoArquivoLog = $"{dataMomento:yyyy-MM-dd HH:mm:ss} - {logLevel}: {message}{Environment.NewLine}";
                    Directory.CreateDirectory(_logDirectory);
                    string arquivoLog = Path.Combine(_logDirectory, nomeArquivoLog);
                    if (ex != null)
                    {
                        //verifica se a ex não é null, caso não seja, adiciona a mensagem de erro no log
                        textoArquivoLog += $"{ex.ToString()}{Environment.NewLine}";
                    }
                    File.AppendAllText(arquivoLog, textoArquivoLog);
                }
                
            }
            catch
            {
                //ignora o erro de log para não impactar a aplicação       
            }
        }
        public void Log(string message)
        {
            GravaArquivo(message, "INFO");
        }
        public void LogError(string message, Exception ex = null)
        {
            GravaArquivo(message, "ERRO", ex);
        }

        public void LogWarning(string message)
        {
            GravaArquivo(message, "AVISO");
        }   
    }
}
