using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Application;
using TiendaServicios.Api.Libro.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaServicios.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroMaterialController : ControllerBase
    {
        public IMediator _mediator { get; }

        public LibroMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LibroMaterialController>
        [HttpGet]
        public async Task<ActionResult<List<LibroMaterialDTO>>> GetLibro()
        {
            return await _mediator.Send(new Consulta.Ejecuta());
        }

        // GET api/<LibroMaterialController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroMaterialDTO>> GetLibroUnico(Guid id)
        {
            return await _mediator.Send(new ConsultaFiltro.LibroUnico {
            LibreriaMaterialId = id
            });
        }

        // POST api/<LibroMaterialController>
        [HttpPost]
        public async Task<ActionResult<Unit>> Crea(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        // PUT api/<LibroMaterialController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibroMaterialController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
