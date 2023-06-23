using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.DTOs;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class ConsultaFiltro
    {
        public class AutorUnico: IRequest<AutorDTO>
        {
            public string AutorGuid { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorDTO>
        {
            private ContextoAutor _contexto { get; }
            private IMapper _mapper { get; }

            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<AutorDTO> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _contexto.AutorLibro
                    .Where(x => x.AutorlibroGuid == request.AutorGuid).FirstOrDefaultAsync();
                if(autor is null)
                {
                    throw new Exception("No Se Encontro El Autor");
                }
                var autorDTO = _mapper.Map<AutorDTO>(autor);
                return autorDTO;
            }
        }
    }
}
