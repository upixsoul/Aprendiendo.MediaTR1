﻿using AutoMapper;
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
    public class Consulta
    {
        public class ListaAutor: IRequest<List<AutorDTO>>
        {

        }

        public class Manejador : IRequestHandler<ListaAutor, List<AutorDTO>>
        {
            private ContextoAutor _contexto { get; }
            private IMapper _mapper { get; }

            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<AutorDTO>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _contexto.AutorLibro.ToListAsync();
                var autoresDTO = _mapper.Map<List<AutorDTO>>(autores);
                return autoresDTO;
            }
        }
    }
}
