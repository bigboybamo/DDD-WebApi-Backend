using AutoMapper;
using Perfume.ApplicationCore.DTOs;
using Perfume.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.ApplicationCore.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreatePerfumeRequest, PerfumeModel>();
            CreateMap<PerfumeModel, PerfumeResponse>();
        }
    }
}
