using Microsoft.AspNetCore.Mvc;
using WorkshoAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace WorkshoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        private static List<Workshop> workshops = new List<Workshop>
        {
            new Workshop { Id = 1, Nome = "Introdução ao C#", DataRealizacao = DateTime.Now, Descricao = "Workshop sobre os fundamentos de C#." },
            new Workshop { Id = 2, Nome = "Desenvolvimento Web com ASP.NET", DataRealizacao = DateTime.Now.AddDays(7), Descricao = "Aprenda a construir aplicações web com ASP.NET." }
        };

        [HttpGet]
        public ActionResult<List<Workshop>> GetAll() => Ok(workshops);

        [HttpGet("{id}")]
        public ActionResult<Workshop> GetById(int id)
        {
            var workshop = workshops.FirstOrDefault(w => w.Id == id);
            if (workshop == null)
                return NotFound();

            return Ok(workshop);
        }

        [HttpPost]
        public ActionResult<Workshop> Create(Workshop workshop)
        {
            workshop.Id = workshops.Max(w => w.Id) + 1; // Simples lógica para gerar novo Id
            workshops.Add(workshop);
            return CreatedAtAction(nameof(GetById), new { id = workshop.Id }, workshop);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Workshop workshop)
        {
            var index = workshops.FindIndex(w => w.Id == id);
            if (index == -1)
                return NotFound();

            workshops[index] = workshop;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var index = workshops.FindIndex(w => w.Id == id);
            if (index == -1)
                return NotFound();

            workshops.RemoveAt(index);
            return NoContent();
        }
    }
}
