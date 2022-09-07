using Application.Features.ProgramLanguage.Commands.CreateProgramLanguage;
using Application.Features.ProgramLanguage.Commands.DeleteProgramLanguage;
using Application.Features.ProgramLanguage.Commands.UpdateProgramLanguage;
using Application.Features.ProgramLanguage.Dtos;
using Application.Features.ProgramLanguage.Models;
using Application.Features.ProgramLanguage.Queries.GetByIdProgramLanguage;
using Application.Features.ProgramLanguage.Queries.GetListProgramLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramLanguageCommand createProgramLanguageCommand)
        {
            CreatedProgramLanguageDto result = await Mediator.Send(createProgramLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgramLanguageQuery getListProgramLanguageQuery = new() { PageRequest = pageRequest };
            ProgramLanguageListModel result = await Mediator.Send(getListProgramLanguageQuery);
            return Ok(result);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramLanguageQuery programLanguageQuery)
        {
            ProgramLanguageGetByIdDto programLanguageGetByIdDto= await Mediator.Send(programLanguageQuery);
            return Ok(programLanguageGetByIdDto);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProgramLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgramLanguageDto deleteProgrammingLanguageDto = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(deleteProgrammingLanguageDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgramLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgramLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Created("", result);
        }
    }
}
