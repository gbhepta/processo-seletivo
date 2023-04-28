using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using processo_seletivo.Models;
using System.Net;

namespace processo_seletivo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        /// <summary>
        /// Retorna a lista de todos os funcionarios cadastrados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Funcionario> Get()
        {
            try
            {
                return Ok(Funcionario.GetTodos());
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        /// <summary>
        /// Cadastra um novo funcionário.
        /// </summary>
        /// <param name="novoFuncionario">Dados do funcionário a cadastrar</param>
        /// <returns>Objeto "novoFuncionario" com a propriedade "id" preenchida com o valor gerado no BD</returns>
        [HttpPost]
        public ActionResult<Funcionario> Post([FromBody] Funcionario novoFuncionario)
        {
            try
            {
                return Ok(Funcionario.Inclui(novoFuncionario));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        /// <summary>
        /// Modifica um funcionário já existente.
        /// </summary>
        /// <param name="funcionarioAlterado">Objeto contendo os novos valores para as propriedades do funcionário
        /// a ser modificado. As modificações serão aplicadas ao funcionário cujo "id" é igual à propriedade "id"
        /// do objeto fornecido.</param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put([FromBody] Funcionario funcionarioAlterado)
        {
            return StatusCode((int)HttpStatusCode.NotImplemented, "método não implementado");
        }

        /// <summary>
        /// Exclui um funcionário
        /// </summary>
        /// <param name="id">Id do funcionário a excluir</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            return StatusCode((int)HttpStatusCode.NotImplemented, "método não implementado");
        }
    }
}
