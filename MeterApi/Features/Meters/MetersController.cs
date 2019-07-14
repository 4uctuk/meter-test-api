using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MeterApi.DataAccess;
using MeterApi.Features.Meters.Contracts;
using MeterApi.Features.Meters.Service;
using MeterApi.Features.Validation;
using Microsoft.AspNetCore.Mvc;

namespace MeterApi.Features.Meters
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetersController : ControllerBase
    {
        private readonly IMetersService _metersService;

        public MetersController(IMetersService metersService)
        {
            _metersService = metersService;
        }

        // POST api/Meters
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateMetersDaily createDto)
        {
            try
            {
                await _metersService.AddMetersToDataBase(createDto);
                return StatusCode(201);
            }
            catch (InvalidOperationException ex)
            {
                var messages = new List<string> { ex.Message };

                if (ex.Data.Contains("validationMessages"))
                    messages.AddRange((IEnumerable<string>)ex.Data["validationMessages"]);

                return BadRequest(new ErrorResponse(messages));
            }
        }

        [HttpPost("total")]
        [ProducesResponseType(typeof(float),(int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTotal(TotalDto totalDto)
        {
            try
            {
                var result = await _metersService.GetTotal(totalDto.CustomerId, totalDto.From, totalDto.To);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                var messages = new List<string> { ex.Message };

                if (ex.Data.Contains("validationMessages"))
                    messages.AddRange((IEnumerable<string>)ex.Data["validationMessages"]);

                return BadRequest(new ErrorResponse(messages));
            }
        }

        [HttpPost("meter")]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByMeter(ByMeterDto byMeterDto)
        {
            try
            {
                var result = await _metersService.GetByMeter(byMeterDto.MeterId, byMeterDto.CustomerId, byMeterDto.From, byMeterDto.To);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                var messages = new List<string> { ex.Message };

                if (ex.Data.Contains("validationMessages"))
                    messages.AddRange((IEnumerable<string>)ex.Data["validationMessages"]);

                return BadRequest(new ErrorResponse(messages));
            }
        }

    }
}
