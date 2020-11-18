using System;
using System.Collections.Generic;
using ApiAgendamentos.Models;
using ApiAgendamentos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgendamentos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HorarioController : ControllerBase
    {
        private readonly IGerenciadorHorario _gerenciadorHorario;
        public HorarioController(IGerenciadorHorario gerenciadorHorario)
        {
            _gerenciadorHorario = gerenciadorHorario;
        }
        [HttpPost]
        public IActionResult Create([FromBody]Horario horario)
        {
            try
            {
                if (horario == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                bool itemExists = _gerenciadorHorario.HorarioExiste(horario.Id);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString());
                }
                _gerenciadorHorario.Inserir(horario);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(horario);
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
            return Ok(_gerenciadorHorario.ObterTodos());
        }
        [HttpPut]
        public IActionResult Edit([FromBody] Horario item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                var existingItem = _gerenciadorHorario.Obter(item.Id);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _gerenciadorHorario.Editar(item);
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
                var item = _gerenciadorHorario.Obter(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _gerenciadorHorario.Remover(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }
    }
}
