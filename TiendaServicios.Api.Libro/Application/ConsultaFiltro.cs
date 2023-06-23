using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.DTOs;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Application
{
    public class ConsultaFiltro
    {
        public class LibroUnico : IRequest<LibroMaterialDTO>
        {
            public Guid LibreriaMaterialId { get; set; }
        }

        public class Manejador : IRequestHandler<LibroUnico, LibroMaterialDTO>
        {
            private ContextoLibreria _contexto { get; }
            private IMapper _mapper { get; }

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<LibroMaterialDTO> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libro = await _contexto.LibreriaMaterial
                    .Where(x => x.LibreriaMaterialId == request.LibreriaMaterialId).FirstOrDefaultAsync();
                if (libro is null)
                {
                    throw new Exception("No Se Encontro El Libro");
                }
                var libroDTO = _mapper.Map<LibreriaMaterial, LibroMaterialDTO>(libro);
                return libroDTO;
            }
        }
    }
}
