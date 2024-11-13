using EmpresaVendas.Conecctions;
using EmpresaVendas.Formularios;
using EmpresaVendas.Repositorios;
using EmpresaVendas.Servicos;
using Microsoft.Extensions.DependencyInjection;
using NPOI.SS.Formula.Functions;
using System;
using System.Data.Common;
using System.Windows.Forms;

namespace EmpresaVendas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Configurando o Service Collection e injetando serviços
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Criando o ServiceProvider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Resolvendo o Form inicial com DI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(serviceProvider.GetRequiredService<frmInicial>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Registrando a interface e implementação do serviço
            services.AddSingleton<IClienteSerico, ClienteSerico>();
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();

            services.AddTransient(p => new DbConnection<T>());
            // Registrando o formulário inicial
            services.AddTransient<frmInicial>();
            services.AddTransient<frmClientes>();
        }
    }
}