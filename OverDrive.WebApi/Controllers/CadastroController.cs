using Data.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interface;

namespace Bravi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly ICadastro _cadastro;        

        public PessoaController(ICadastro cadastro, DataContext dataContex)
        {
            _cadastro = cadastro;           
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(EntityCadastrosPessoa cadastro)
        {
            try
            {
                if (cadastro == null)
                {
                    return BadRequest($"Não Foi possível realizar esse cadastro {cadastro} !");
                }
                await _cadastro.Insert(cadastro);
                return Ok("Pessoa cadastrada com sucesso!");
                 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        [HttpGet("ListaCadastros")]
        public async Task<IActionResult> ListaCadastros()
        {
            var result = await _cadastro.GetAll();            
            return Ok(result.ToList());
        }

        [HttpGet("ObterCadastroPorId/{id}")]
        public async Task<IActionResult> ObterCadastroPorId(int id)
        {
            var result = await _cadastro.GetById(id);
            if(result == null)
            {
                return NotFound($"Cadastro com id {id}, não encontrado!");
            }
            return Ok(result);
        }
     

        [HttpDelete("DeletarCadastro/{id}")]
        public async Task<IActionResult> DeletarCadastro(int id)
        {
            var result = await _cadastro.GetById(id);
            if (result == null)
            {
                return NotFound($"cadastro {id}, não encontrado!");
            }
            await _cadastro.Delete(id);
            return Ok($"Cadastro foi deletado com sucesso!");
        }

        [HttpPut("AtualizarCadastro")]
        public async Task<IActionResult> AtualizarCadastro(EntityCadastrosPessoa cadastro)
        {
            if(cadastro != null)
            {
                try
                {
                    await _cadastro.Update(cadastro);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return Ok($"Cadastro atualizado com sucesso!");

            }
            else { return BadRequest("Objeto não encontrado!"); }            

        }
       
    }
}
