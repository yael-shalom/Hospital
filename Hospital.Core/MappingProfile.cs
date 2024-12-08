using AutoMapper;
using Hospital.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<Placement, PlacementDto>().ReverseMap();
        }
    }
}
