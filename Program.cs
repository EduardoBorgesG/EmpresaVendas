using EmpresaVendas._3___Repositorios;
using EmpresaVendas._4___Servicos;
using EmpresaVendas._5___Formularios;
using EmpresaVendas._5___Formularios.Clientes;
using EmpresaVendas._5___Formularios.Erros;
using EmpresaVendas._5___Formularios.Produtos;
using EmpresaVendas._5___Formularios.Vendas;
using EmpresaVendas.Formularios;
using EmpresaVendas.Formularios.Produtos;
using EmpresaVendas.Infra;
using EmpresaVendas.Repositorios;
using EmpresaVendas.Servicos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace EmpresaVendas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            //Envia o erro ao Forms impedindo que o programa trave e feche, o erro é tratado no evento ThreadException
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);      
            //ReportViewer
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            // Configurando o Service Collection e injetando serviços
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            // Criando o ServiceProvider
            var serviceProvider = serviceCollection.BuildServiceProvider();
            // Resolvendo o tratador de erros para que ele seja inicializado e comece a tratar os erros, foi configurado a interface por conta que ela está registradas na DI, sempre que for chamado a classe Tratador de erros é passada a I
            var tratadorErros = serviceProvider.GetRequiredService<ITratadorErros>();
            Application.ThreadException += (sender, e) => tratadorErros.Tratar("Ocorreu um erro inesperado.", e.Exception);
            // Captura exceções não tratadas em threads não-UI, o programa fecha porém o erro é coletado no LOG
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => tratadorErros.Tratar("Programa foi encerrado devido ao erro", e.ExceptionObject as Exception);

            // Resolvendo o Form inicial com DI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(serviceProvider.GetRequiredService<frmInicial>());

            // Ao fechar o programa, descarta o container (e o que ainda estiver aberto nele)
            (serviceProvider as IDisposable)?.Dispose();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Fábrica de conexões: Singleton porque só guarda a connection string (sem estado mutável).
            // Cada operação dos repositórios abre e fecha a própria conexão com "using"
            services.AddSingleton<IConnectionFactory, NpgsqlConnectionFactory>();
            services.AddSingleton<ILogger, ArquivoLogger>();
            services.AddSingleton<ITratadorErros, TratadorErros>();

            // Repositórios e serviços são Scoped: uma instância por formulário aberto
            // (cada formulário é criado em um escopo próprio pelo FormFactory)

            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IVendaRepositorio, VendaRepositorio>();

            services.AddScoped<IClienteSerico, ClienteSerico>();
            services.AddScoped<IProdutoServico, ProdutoServico>();
            services.AddScoped<IVendaServico, VendaServico>();

            // Fábrica usada pelo frmInicial para abrir as telas
            services.AddSingleton<IFormFactory, FormFactory>();

            // Formulários
            services.AddTransient<frmInicial>();
            services.AddTransient<frmClientes>();
            services.AddTransient<frmProdutos>();
            services.AddTransient<frmVenda>();
            services.AddTransient<frmAtivarClientes>();
            services.AddTransient<frmAtivarProdutos>();
            services.AddTransient<frmRelatorioClientes>();
            services.AddTransient<frmRelatorioProduto>();
            services.AddTransient<frmRelatorioVenda>();
        }
    }
}
