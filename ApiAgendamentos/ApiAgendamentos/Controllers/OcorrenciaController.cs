using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAgendamentos.Models;
using ApiAgendamentos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgendamentos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OcorrenciaController : ControllerBase
    {
        private readonly IGerenciadorOcorrencia _gerenciadorOcorrencia;

        public OcorrenciaController(IGerenciadorOcorrencia gerenciadorOcorrencia)
        {
            _gerenciadorOcorrencia = gerenciadorOcorrencia;
        }
        [HttpPost]
        public IActionResult Create([FromBody]Ocorrencia ocorrencia)
        {
            try
            {
                if (ocorrencia == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                bool itemExists = _gerenciadorOcorrencia.OcorrenciaExiste(ocorrencia.Id);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString());
                }
                _gerenciadorOcorrencia.Inserir(ocorrencia);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(ocorrencia);
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
            return Ok(_gerenciadorOcorrencia.ObterTodos());
        }
        [HttpPut]
        public IActionResult Edit([FromBody] Ocorrencia item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                var existingItem = _gerenciadorOcorrencia.Obter(item.Id);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _gerenciadorOcorrencia.Editar(item);
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
                var item = _gerenciadorOcorrencia.Obter(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _gerenciadorOcorrencia.Remover(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }
    }
}
