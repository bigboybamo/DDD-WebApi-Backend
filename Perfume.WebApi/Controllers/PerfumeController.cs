using Microsoft.AspNetCore.Mvc;
using Perfume.ApplicationCore.DTOs;
using Perfume.ApplicationCore.Exceptions;
using Perfume.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace Perfume.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumeController : Controller
    {
        private readonly IPerfumeInterface perfumeRepository;
        public PerfumeController(IPerfumeInterface perfumeRepository)
        {
            this.perfumeRepository = perfumeRepository;
        }


        [HttpGet]
        public ActionResult<List<PerfumeResponse>> GetPerfumes()
        {
            return Ok(this.perfumeRepository.GetPerfumes());
        }

        [HttpGet("{id}")]
        public ActionResult GetPerfumeById(int id)
        {
            try
            {
                var product = this.perfumeRepository.GetPerfumeById(id);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Create(CreatePerfumeRequest request)
        {
            var product = this.perfumeRepository.CreatePerfume(request);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.perfumeRepository.DeletePerfumeById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
