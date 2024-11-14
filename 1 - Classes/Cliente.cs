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
using System.Runtime.CompilerServices;

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

        public Cliente(int id)
        {
            Id = id;
        }
        public Cliente(string telefone, int id)
        {
            Telefone = telefone.Length == 15 && !string.IsNullOrEmpty(telefone) ? telefone : throw new Exception("Telefone do cliente preenchido incorretamente");
            Telefone = telefone;
            Id = id;
        }
        public Cliente(int id, string nome, string email, string cep, string endereco) 
        { 
            Id = id;
            Nome = !string.IsNullOrEmpty(nome) ? nome : throw new Exception("Nome do cliente não pode estar vazio");
            Nome = nome;
            Email = email;
            Telefone = cep;
            Endereco = endereco;
        }
        public Cliente( string nome, string email, string telefone, string cep, string endereco)
        {
            Nome = !string.IsNullOrEmpty(nome) ? nome : throw new Exception("Nome do cliente não pode estar vazio");
            Nome = nome;
            Email = email.ToLower();
            //Verifica se o telefone está totalmente preenchido e não é nulo
            Telefone = telefone.Length == 15 && !string.IsNullOrEmpty(telefone) ? telefone : throw new Exception("Telefone do cliente preenchido incorretamente");
            Telefone = telefone;
            //Verifica se o CEP não é nulo e se está totalmente preenchido
            Cep = cep.Length == 9 && !string.IsNullOrEmpty(cep) ? cep : throw new Exception("CEP do Cliente está preenchido incorretamente");
            Cep = cep;
            Endereco = endereco;
        }
        public Cliente(int id, string nome, string email, string telefone, string cep, string endereco)
        {
            //Construtor utilizado para salvar edição
            Nome = !string.IsNullOrEmpty(nome) ? nome : throw new Exception("Nome do cliente não pode estar vazio");
            Nome = nome;
            Email = !string.IsNullOrEmpty(email) ? email : throw new Exception("O Email não pode estar vazio");
            Email = email.ToLower();
            //Verifica se o telefone está totalmente preenchido e não é nulo
            Telefone = telefone.Length == 15 && !string.IsNullOrEmpty(telefone) ? telefone : throw new Exception("Telefone do cliente preenchido incorretamente");
            Telefone = telefone;
            //Verifica se o CEP não é nulo e se está totalmente preenchido
            Cep = cep.Length == 9 && !string.IsNullOrEmpty(cep) ? cep : throw new Exception("CEP do Cliente está preenchido incorretamente");
            Cep = cep;
            Endereco = !string.IsNullOrEmpty(endereco) ? endereco : throw new Exception("O Endereço não pode estar vazio");
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
