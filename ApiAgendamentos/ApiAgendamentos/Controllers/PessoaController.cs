using System;
using ApiAgendamentos.Models;
using ApiAgendamentos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgendamentos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IGerenciadorPessoa _gerenciadorPessoa;

        public PessoaController(IGerenciadorPessoa gerenciadorPessoa)
        {
            _gerenciadorPessoa = gerenciadorPessoa;
        }
        [HttpPost]
        public IActionResult Create([FromBody]Pessoa pessoa)
        {
            try
            {
                if (pessoa == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                bool itemExists = _gerenciadorPessoa.PessoaExiste(pessoa.Id);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString());
                }
                _gerenciadorPessoa.Inserir(pessoa);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(pessoa);
        }
        public enum ErrorCode
        {
            TodoItemNameAndNotesRequired,
            TodoItemIDInUse,
            RecordNotFound,
            CouldNotCreateItem,
            CouldNotUpdateItem,
            CouldNotDeleteItem
        }
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_gerenciadorPessoa.ObterTodos());
        }
        [HttpPut]
        public IActionResult Edit([FromBody] Pessoa item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                var existingItem = _gerenciadorPessoa.Obter(item.Id);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _gerenciadorPessoa.Editar(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _gerenciadorPessoa.Obter(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _gerenciadorPessoa.Remover(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }

    }
}
