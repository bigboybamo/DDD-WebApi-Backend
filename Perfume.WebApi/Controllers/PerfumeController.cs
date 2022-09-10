using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Perfume.ApplicationCore.DTOs;
using Perfume.ApplicationCore.Entities;
using Perfume.ApplicationCore.Exceptions;
using Perfume.ApplicationCore.Interfaces;
using Perfume.WebApi.Validators;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace Perfume.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumeController : Controller
    {
        private readonly IPerfumeInterface perfumeRepository;
        private readonly PerfumeValidator perfumeValidator;
        private readonly ILogger<PerfumeController> _logger;
        public PerfumeController(IPerfumeInterface perfumeRepository, PerfumeValidator perfumeValidator, ILogger<PerfumeController> _logger)
        {
            this.perfumeRepository = perfumeRepository;
            this.perfumeValidator = perfumeValidator;
            this._logger = _logger;
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

                string res = JsonConvert.SerializeObject(product);
                _logger.LogInformation("Response = " + res);
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
            _logger.LogInformation("Request = " + JsonConvert.SerializeObject(request));

            var validationResult = perfumeValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);

                // re-render the view when validation failed.
                //return View(model);
            }

            var product = this.perfumeRepository.CreatePerfume(request);

            string res = JsonConvert.SerializeObject(product);
            _logger.LogInformation("Response = " + res);

            return Ok(product);
        }


        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdatePerfumeRequest request)
        {
            
            try
            {
                _logger.LogInformation("Request = " + JsonConvert.SerializeObject(request));

                var validationResult = perfumeValidator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult);

                    // re-render the view when validation failed.
                    //return View(model);
                }
                var product = this.perfumeRepository.UpdatePerfume(id, request);
                _logger.LogInformation("Response = " + JsonConvert.SerializeObject(product));
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
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
