using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Perfume.ApplicationCore.DTOs;
using Perfume.ApplicationCore.Entities;
using Perfume.ApplicationCore.Exceptions;
using Perfume.ApplicationCore.Interfaces;
using Perfume.WebApi.Validators;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Perfume.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumeController : Controller
    {
        private readonly IPerfumeInterface perfumeRepository;
        private readonly PerfumeValidator perfumeValidator;
        public PerfumeController(IPerfumeInterface perfumeRepository, PerfumeValidator perfumeValidator)
        {
            this.perfumeRepository = perfumeRepository;
            this.perfumeValidator = perfumeValidator;
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
        public ActionResult Create([FromBody] CreatePerfumeRequest request)
{

            var validationResult = perfumeValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);

                // re-render the view when validation failed.
                //return View(model);
            }

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
