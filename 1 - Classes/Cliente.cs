using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using EmpresaVendas.Conecctions;
using System.Data;
using System.Windows.Forms;
using EmpresaVendas.Formularios;

namespace EmpresaVendas.Classes
{
    public class Cliente
    {
        public int  Id { get;  set; }  
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public string Telefone { get;  set; }
        public string Cep { get;  set; }
        public string Endereco { get;  set; }
        
        public Cliente( string nome, string email, string telefone, string cep, string endereco)
        {
            Nome = !string.IsNullOrEmpty(nome) ? nome : throw new Exception("Nome do cliente não pode estar vazio");
            Email = email.ToLower();
            Telefone = telefone;
            Cep = cep;
            Endereco = endereco;
        }
        public Cliente(int id, string nome, string email, string telefone, string cep, string endereco)
        {
            Nome = !string.IsNullOrEmpty(nome) ? nome : throw new Exception("Nome do cliente não pode estar vazio");
            Email = email.ToLower();
            Telefone = telefone;
            Cep = cep;
            Endereco = endereco;
            Id = id;
        }
        public void AlterarTelefone(string novoTelefone)
        {
            if (string.IsNullOrEmpty(novoTelefone)) throw new Exception();
            if (novoTelefone.Length != 11) throw new Exception();
            Telefone = novoTelefone;
            //Telefone = !string.IsNullOrEmpty(novoTelefone) ? novoTelefone : throw new Exception("Telefone do cliente não pode estar vazio");
        }
    }
}
