using Microservice.WebApi.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Microservice.WebApi.Controllers
{
    [Route("api/examples")]
    public class ExamplesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ExampleDto>> Get()
        {
            ExampleDto[] list =
            {
                new ExampleDto { Id = 1, Value = "D3FCBFA9-29C6-463A-9D9C-628AD13DE45D" },
                new ExampleDto { Id = 2, Value = "9F036B8E-A562-4066-8D78-DB6B22A1E0C6" }
            };

            return Ok(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ExampleDto> GetById(int id)
        {
            ExampleDto dto = new ExampleDto { Id = id, Value = Guid.NewGuid().ToString() };
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] ExampleAddDto addDto)
        {
            ExampleDto dto = new ExampleDto { Id = 42, Value = addDto.Value };
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(int id, [FromBody] ExampleUpdateDto updateDto)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
