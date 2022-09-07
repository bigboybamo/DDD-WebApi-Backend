using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Perfume.ApplicationCore.DTOs;
using Perfume.ApplicationCore.Entities;
using Perfume.ApplicationCore.Exceptions;
using Perfume.ApplicationCore.Interfaces;
using Perfume.ApplicationCore.Utils;
using Perfume.Infrastructure.Persistence.Contexts;

namespace Perfume.Infrastructure.Persistence.Repositories
{
    public class PerfumeRepository : IPerfumeInterface
    {
        private readonly StoreContext storeContext;
        private readonly IMapper mapper;

        public PerfumeRepository(StoreContext storeContext, IMapper mapper)
        {
            this.storeContext = storeContext;
            this.mapper = mapper;
        }

        public PerfumeResponse CreatePerfume(CreatePerfumeRequest request)
        {
            var product = this.mapper.Map<PerfumeModel>(request);
            product.CreatedOn = DateUtil.GetCurrentDate();

            this.storeContext.Products.Add(product);
            this.storeContext.SaveChanges();

            return this.mapper.Map<PerfumeResponse>(product);
        }

        public void DeletePerfumeById(int perfumeid)
        {
            var product = this.storeContext.Products.Find(perfumeid);
            if (product != null)
            {
                this.storeContext.Products.Remove(product);
                this.storeContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public PerfumeResponse GetPerfumeById(int perfumeId)
        {
            var product = this.storeContext.Products.Find(perfumeId);
            if (product != null)
            {
                return this.mapper.Map<PerfumeResponse>(product);
            }

            throw new NotFoundException();
        }

        public List<PerfumeResponse> GetPerfumes()
        {
            return this.storeContext.Products.Select(p => this.mapper.Map<PerfumeResponse>(p)).ToList();
        }
    }
}
