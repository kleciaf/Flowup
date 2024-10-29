using Microsoft.AspNetCore.Mvc;
using WorkshoAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace WorkshoAPI.Controllers
{
    [ApiController]
    [Route("api/colaboradores")] // Mudei para "colaboradores" para se alinhar com a convenção REST
    public class ColaboradorController : ControllerBase
    {
        private static List<Colaborador> colaboradores = new List<Colaborador>();

        // Obter todos os colaboradores
        [HttpGet]
        public ActionResult<List<Colaborador>> GetAll()
        {
            return Ok(colaboradores);
        }

        // Obter colaborador por ID
        [HttpGet("{id}")]
        public ActionResult<Colaborador> GetById(int id)
        {
            var colaborador = colaboradores.FirstOrDefault(c => c.Id == id);
            if (colaborador == null)
                return NotFound();

            return Ok(colaborador);
        }

        // Adicionar novo colaborador
        [HttpPost]
        public ActionResult<Colaborador> Post([FromBody] Colaborador colaborador)
        {
            if (colaborador == null || string.IsNullOrWhiteSpace(colaborador.Nome))
            {
                return BadRequest("Colaborador inválido.");
            }

            // Define o ID para o novo colaborador
            colaborador.Id = colaboradores.Count > 0 ? colaboradores.Max(c => c.Id) + 1 : 1;
            colaboradores.Add(colaborador);
            return CreatedAtAction(nameof(GetById), new { id = colaborador.Id }, colaborador);
        }

        // Atualizar colaborador existente
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Colaborador colaborador)
        {
            var existingColaborador = colaboradores.FirstOrDefault(c => c.Id == id);
            if (existingColaborador == null)
                return NotFound();

            existingColaborador.Nome = colaborador.Nome; // Atualize aqui os campos que quiser
            return NoContent();
        }

        // Deletar colaborador
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var colaborador = colaboradores.FirstOrDefault(c => c.Id == id);
            if (colaborador == null)
                return NotFound();

            colaboradores.Remove(colaborador);
            return NoContent();
        }
    }
}
