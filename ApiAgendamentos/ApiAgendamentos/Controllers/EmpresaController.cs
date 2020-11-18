using System;
using ApiAgendamentos.Models;
using ApiAgendamentos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgendamentos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IGerenciadorEmpresa _gerenciadorEmpresa;

        public EmpresaController(IGerenciadorEmpresa gerenciadorEmpresa)
        {
            _gerenciadorEmpresa = gerenciadorEmpresa;
        }
        [HttpPost]
        public IActionResult Create([FromBody]Empresa empresa)
        {
            try
            {
                if (empresa == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                bool itemExists = _gerenciadorEmpresa.EmpresaExiste(empresa.Id);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString());
                }
                _gerenciadorEmpresa.Inserir(empresa);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(empresa);
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
            return Ok(_gerenciadorEmpresa.ObterTodos());
        }
        [HttpPut]
        public IActionResult Edit([FromBody] Empresa item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                var existingItem = _gerenciadorEmpresa.Obter(item.Id);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _gerenciadorEmpresa.Editar(item);
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
                var item = _gerenciadorEmpresa.Obter(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _gerenciadorEmpresa.Remover(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }
    }
}
