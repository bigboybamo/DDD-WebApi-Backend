using Perfume.ApplicationCore.DTOs;
using Perfume.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.ApplicationCore.Interfaces
{
    public interface IPerfumeInterface
    {
        List<PerfumeResponse> GetPerfumes();

        PerfumeResponse GetPerfumeById(int perfumeId);

        void DeletePerfumeById(int perfumeid);

        PerfumeResponse CreatePerfume(CreatePerfumeRequest request);

        PerfumeResponse UpdatePerfume(int perfumeId, UpdatePerfumeRequest request);
    }
}
