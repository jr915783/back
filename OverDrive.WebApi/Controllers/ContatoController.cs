using Data.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interface;

namespace Bravi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly ICadastroContato _cadastroContato;        

        public ContatoController(ICadastroContato cadastro, DataContext dataContex)
        {
            _cadastroContato = cadastro;           
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(EntityContato cadastro)
        {
            try
            {
                if (cadastro == null)
                {
                    return BadRequest($"Não Foi possível realizar esse cadastro {cadastro} !");
                }         
                    await _cadastroContato.Insert(cadastro);
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
            var result = await _cadastroContato.buscarPessoaContato();           
            return Ok(result.ToList());
        }

        [HttpGet("ObterCadastroPorId/{id}")]
        public async Task<IActionResult> ObterCadastroPorId(int id)
        {
            var result = await _cadastroContato.GetById(id);
            if(result == null)
            {
                return NotFound($"Cadastro com id {id}, não encontrado!");
            }
            return Ok(result);
        }
     

        [HttpDelete("DeletarCadastro/{id}")]
        public async Task<IActionResult> DeletarCadastro(int id)
        {
            var result = await _cadastroContato.GetById(id);
            if (result == null)
            {
                return NotFound($"cadastro {id}, não encontrado!");
            }
            await _cadastroContato.Delete(id);
            return Ok($"Cadastro foi deletado com sucesso!");
        }

        [HttpPut("AtualizarCadastro")]
        public async Task<IActionResult> AtualizarCadastro(EntityContato cadastro)
        {           

            if(cadastro != null)
            {
                try
                {
                    await _cadastroContato.Update(cadastro);
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
