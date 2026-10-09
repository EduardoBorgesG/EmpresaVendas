using System;
using EmpresaVendas._1___Classes.Excecoes;

namespace EmpresaVendas.Classes
{
    public class Cliente
    {
        public int  Id { get;  set; }  
        public string nome { get;  set; }
        public string Email { get;  set; }
        public string Telefone { get;  set; }
        public string Cep { get;  set; }
        public string Endereco { get;  set; }

        public Cliente()
        {

        }
        public Cliente(int id)
        {
            Id = id;
        }
        public Cliente(string telefone, int id)
        {
            Telefone = !string.IsNullOrEmpty(telefone) && telefone.Length == 15 ? telefone : throw new RegraNegocioException("Telefone do cliente preenchido incorretamente");
            Telefone = telefone;
            Id = id;
        }
        public Cliente(int id, string nome_cliente, string email, string cep, string endereco)
        {
            Id = id;
            nome = !string.IsNullOrEmpty(nome_cliente) ? nome_cliente : throw new RegraNegocioException("Nome do cliente não pode estar vazio");
            nome = nome_cliente;
            Email = email;
            Cep = cep;
            Endereco = endereco;
        }
        public Cliente(string nome_cliente, string email, string telefone, string cep, string endereco)
        {
            nome = !string.IsNullOrEmpty(nome_cliente) ? nome_cliente : throw new RegraNegocioException("Nome do cliente não pode estar vazio");
            nome = nome_cliente;
            Email = email?.ToLower();
            //Verifica se o telefone não é nulo e se está totalmente preenchido
            Telefone = !string.IsNullOrEmpty(telefone) && telefone.Length == 15 ? telefone : throw new RegraNegocioException("Telefone do cliente preenchido incorretamente");
            Telefone = telefone;
            //Verifica se o CEP não é nulo e se está totalmente preenchido
            Cep = !string.IsNullOrEmpty(cep) && cep.Length == 9 ? cep : throw new RegraNegocioException("CEP do Cliente está preenchido incorretamente");
            Cep = cep;
            Endereco = endereco;
        }
        public Cliente(int id, string nome_cliente, string email, string telefone, string cep, string endereco)
        {
            //Construtor utilizado para salvar edição
            nome = !string.IsNullOrEmpty(nome_cliente) ? nome_cliente : throw new RegraNegocioException("Nome do cliente não pode estar vazio");
            nome = nome_cliente;
            Email = !string.IsNullOrEmpty(email) ? email : throw new RegraNegocioException("O Email não pode estar vazio");
            Email = email.ToLower();
            //Verifica se o telefone não é nulo e se está totalmente preenchido
            Telefone = !string.IsNullOrEmpty(telefone) && telefone.Length == 15 ? telefone : throw new RegraNegocioException("Telefone do cliente preenchido incorretamente");
            Telefone = telefone;
            //Verifica se o CEP não é nulo e se está totalmente preenchido
            Cep = !string.IsNullOrEmpty(cep) && cep.Length == 9 ? cep : throw new RegraNegocioException("CEP do Cliente está preenchido incorretamente");
            Cep = cep;
            Endereco = !string.IsNullOrEmpty(endereco) ? endereco : throw new RegraNegocioException("O Endereço não pode estar vazio");
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
