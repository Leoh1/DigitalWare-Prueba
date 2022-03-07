using System;
using AutoMapper;
using Framework.Domain.Entity;
using Framework.Application.DTO;

namespace Framework.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Factura, FacturaDTO>().ReverseMap();
            CreateMap<Detalle, DetalleDTO>().ReverseMap();
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            

            /*
            //En caso de que los modelos no sean iguales se debe hacer de la siguiente forma.
            CreateMap<Clase, ClaseDTO>().ReverseMap()
                .ForMember(destination => destination.CLASE_ID, source => source.MapFrom(src => src.CLASE_ID))
                .ForMember(destination => destination.CLASE_DESCRIP, source => source.MapFrom(src => src.CLASE_DESCRIP))
                .ForMember(destination => destination.CLASE_EMPRESA, source => source.MapFrom(src => src.CLASE_EMPRESA))
                .ForMember(destination => destination.CLASE_EDITABLE, source => source.MapFrom(src => src.CLASE_EDITABLE)).ReverseMap();
            */

        }
    }
}
