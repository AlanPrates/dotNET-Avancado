using Cepedi.Banco.Pessoa.Compartilhado.Requests;

namespace Cepedi.Banco.Pessoa.Dominio.Entidades
{
    public class EnderecoEntity
    {
        public int Id { get; set; }
        public string Cep { get; set; } = default!;
        public string Logradouro { get; set; } = default!;
        public string Complemento { get; set; } = default!;
        public string Bairro { get; set; } = default!;
        public string Cidade { get; set; } = default!;
        public string Uf { get; set; } = default!;
        public string Pais { get; set; } = default!;
        public string Numero { get; set; } = default!;
        public int IdPessoa { get; set; }

        public PessoaEntity Pessoa { get; set; } = default!;

        public void Atualizar(AtualizarEnderecoRequest request)
        {
            Cep = request.Cep;
            Logradouro = request.Logradouro;
            Complemento = request.Complemento;
            Bairro = request.Bairro;
            Cidade = request.Cidade;
            Uf = request.Uf;
            Pais = request.Pais;
            Numero = request.Numero;
        }

        public class Endereco
        {
            public string cep { get; set; }
            public string logradouro { get; set; }
            public string complemento { get; set; }
            public string bairro { get; set; }
            public string localidade { get; set; }
            public string uf { get; set; }
            public string ibge { get; set; }
            public string gia { get; set; }
            public string ddd { get; set; }
            public string siafi { get; set; }
        }
    }
}