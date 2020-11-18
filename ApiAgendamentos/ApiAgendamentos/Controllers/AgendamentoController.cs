using System;
using ApiAgendamentos.Models;
using ApiAgendamentos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgendamentos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IGerenciadorAgendamento _gerenciadorAgendamento;
        public AgendamentoController(IGerenciadorAgendamento gerenciadorAgendamento)
        {
            _gerenciadorAgendamento = gerenciadorAgendamento;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Agendamento agendamento)
        {
            try
            {
                if (agendamento == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                bool itemExists = _gerenciadorAgendamento.AgendamentoExiste(agendamento.Id);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString());
                }
                _gerenciadorAgendamento.Inserir(agendamento);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(agendamento);
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
            return Ok(_gerenciadorAgendamento.ObterTodos());
        }
        [HttpPut]
        public IActionResult Edit([FromBody] Agendamento item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                var existingItem = _gerenciadorAgendamento.Obter(item.Id);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _gerenciadorAgendamento.Editar(item);
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
                var item = _gerenciadorAgendamento.Obter(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _gerenciadorAgendamento.Remover(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }
    }
}
