using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAgendamentos.Models;
using ApiAgendamentos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static ApiAgendamentos.Controllers.AgendamentoController;

namespace ApiAgendamentos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IGerenciadorEstabelecimento _gerenciadorEstabelecimento;
        public EstabelecimentoController(IGerenciadorEstabelecimento gerenciadorEstabelecimento)
        {
            _gerenciadorEstabelecimento = gerenciadorEstabelecimento;
        }
        [HttpPost]
        public IActionResult Create([FromBody]Estabelecimento estabelecimento)
        {
            try
            {
                if (estabelecimento == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                bool itemExists = _gerenciadorEstabelecimento.EstabelecimentoExiste(estabelecimento.Id);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString());
                }
                _gerenciadorEstabelecimento.Inserir(estabelecimento);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(estabelecimento);
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
            return Ok(_gerenciadorEstabelecimento.ObterTodos());
        }
        [HttpPut]
        public IActionResult Edit([FromBody] Estabelecimento item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                var existingItem = _gerenciadorEstabelecimento.Obter(item.Id);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _gerenciadorEstabelecimento.Editar(item);
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
                var item = _gerenciadorEstabelecimento.Obter(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _gerenciadorEstabelecimento.Remover(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }
    }
}
