using Cepedi.Compartilhado.Exceptions;

namespace Cepedi.Banco.Pessoa.Compartilhado.Enums
{
    public static class BancoCentralMensagemErrors
    {
        public static readonly ResultadoErro Generico = new ResultadoErro
        {
            Titulo = "Ops ocorreu um erro no nosso sistema",
            Descricao = "No momento, nosso sistema está indisponível. Por Favor tente novamente",
            Tipo = ETipoErro.Erro
        };

        public static readonly ResultadoErro SemResultados = new ResultadoErro
        {
            Titulo = "Sua busca não obteve resultados",
            Descricao = "Tente buscar novamente",
            Tipo = ETipoErro.Alerta
        };

        public static readonly ResultadoErro ErroGravacaoUsuario = new ResultadoErro
        {
            Titulo = "Ocorreu um erro na gravação",
            Descricao = "Ocorreu um erro na gravação do usuário. Por favor tente novamente",
            Tipo = ETipoErro.Erro
        };

        public static readonly ResultadoErro DadosInvalidos = new ResultadoErro
        {
            Titulo = "Dados inválidos",
            Descricao = "Os dados enviados na requisição são inválidos",
            Tipo = ETipoErro.Erro
        };
    }
}
