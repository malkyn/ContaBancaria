using ContaCorrente.Interfaces;
using ContaCorrente.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContaCorrente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IExtratoInterface _extratoInterface;

        public HomeController(IExtratoInterface productInterface)
        {
            _extratoInterface = productInterface;
        }

        [HttpPost]
        [Route("cadastroTransacao")]
        public IActionResult CadastrarUsuario([FromBody] Extrato user) { return Ok(_extratoInterface.Transacao(user)); }

        [HttpDelete]
        [Route("deletarTransacao/{id}")]
        public IActionResult DeletarOperacao(string id) { return Ok(_extratoInterface.Delete(id)); }

        [HttpGet]
        [Route("consulta/{cpf}")]
        public IActionResult Consulta([FromRoute] string cpf, [FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim) { return Ok(_extratoInterface.Extrato(cpf, dataInicio, dataFim)); }
    }
}