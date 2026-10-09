using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVendas._5___Formularios.Erros
{
    public interface ITratadorErros
    {
        void Tratar(string message, Exception ex = null);
    }
}
