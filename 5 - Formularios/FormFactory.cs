using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace EmpresaVendas._5___Formularios
{
    public interface IFormFactory
    {
        /// <summary>
        /// Cria um formulário com todas as suas dependências resolvidas pelo container de DI
        /// </summary>
        T Criar<T>() where T : Form;
    }

    public class FormFactory : IFormFactory
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public FormFactory(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public T Criar<T>() where T : Form
        {
            //Cada formulário ganha o próprio escopo: serviços, repositórios e conexões
            //vivem enquanto a tela estiver aberta e são descartados quando ela fecha
            var escopo = _scopeFactory.CreateScope();
            try
            {
                var form = escopo.ServiceProvider.GetRequiredService<T>();
                form.Disposed += (sender, e) => escopo.Dispose();
                return form;
            }
            catch
            {
                //Se o formulário falhar ao ser criado, libera o escopo (e as conexões) mesmo assim
                escopo.Dispose();
                throw;
            }
        }
    }
}
