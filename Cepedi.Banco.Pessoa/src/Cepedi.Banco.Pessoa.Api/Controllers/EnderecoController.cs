using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using Cepedi.Banco.Pessoa.Dados;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Cepedi.Banco.Pessoa.Dominio.Entidades;

namespace Cepedi.Banco.Pessoa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : BaseController
    {
        private readonly ILogger<EnderecoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public EnderecoController(IMediator mediator, ILogger<EnderecoController> logger, ApplicationDbContext context, IHttpClientFactory httpClientFactory) : base(mediator)
        {
            _logger = logger;
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<ObterTodosEnderecosResponse>> ObterTodosEnderecos()
        {
            return await SendCommand(new ObterTodosEnderecosRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObterEnderecoResponse>> ObterEndereco([FromRoute] int id)
        {
            return await SendCommand(new ObterEnderecoRequest() { EnderecoId = id });
        }

        [HttpGet("/cep/{cep}")]
        public async Task<ActionResult<ObterEnderecoPorCepResponse>> ObterEnderecoPorCep([FromRoute] string cep)
        {
            try
            {
                string url = $"https://viacep.com.br/ws/{cep}/json/";
                
                var httpClient = _httpClientFactory.CreateClient();
                
                HttpResponseMessage response = await httpClient.GetAsync(url);
                
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    
                    var endereco = JsonSerializer.Deserialize<EnderecoEntity.Endereco>(jsonResponse);
                    
                    return Ok(endereco);
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CadastrarEnderecoResponse>> CadastrarEndereco([FromBody] CadastrarEnderecoRequest request)
        {
            return await SendCommand(request);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AtualizarEnderecoResponse>> AtualizarEndereco([FromBody] AtualizarEnderecoRequest request)
        {
            return await SendCommand(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ExcluirEnderecoResponse>> ExcluirEndereco([FromRoute] int id)
        {
            var request = new ExcluirEnderecoRequest() { EnderecoId = id };
            return await SendCommand(request);
        }

    }
}
