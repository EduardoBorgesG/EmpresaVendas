using EmpresaVendas._3___Repositorios;
using EmpresaVendas._4___Servicos;
using EmpresaVendas._5___Formularios;
using EmpresaVendas._5___Formularios.Clientes;
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
            //ReportViewer
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            // Configurando o Service Collection e injetando serviços
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Criando o ServiceProvider
            var serviceProvider = serviceCollection.BuildServiceProvider();

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
