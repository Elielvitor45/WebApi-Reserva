
using WebAPIMacoratti.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPIMacoratti.Models;

namespace WebAPIMacoratti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private IRepository repository;

        public ReservasController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Reserva> Get() => repository.Reservas;

        [HttpGet("{id}")]
        public Reserva Get(int id) => repository[id];

        [HttpPost]
        public Reserva Post([FromBody] Reserva res) =>
        repository.AddReserva(new Reserva
        {
            nome = res.nome,
            inicioLocacao = res.inicioLocacao,
            fimLocacao = res.fimLocacao
        });
        [HttpPut]
        public Reserva Put([FromForm] Reserva res) => repository.UpdateReserva(res);

        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromForm] JsonPatchDocument<Reserva> patch)
        {
            Reserva res = Get(id);
            if (res != null)
            {
                patch.ApplyTo(res);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteReserva(id);
    }
}