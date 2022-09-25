using Application.Features.SubProgramLanguage.Commands.CreateSubProgramLanguage;
using Application.Features.SubProgramLanguage.Commands.DeleteSubProgramLanguage;
using Application.Features.SubProgramLanguage.Commands.UpdateSubProgramLanguage;
using Application.Features.SubProgramLanguage.Dtos;
using Application.Features.SubProgramLanguage.Models;
using Application.Features.SubProgramLanguage.Queries.GetByIdSubProgramLanguage;
using Application.Features.SubProgramLanguage.Queries.GetListSubProgramLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubSubProgramLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSubProgramLanguageCommand createSubProgramLanguageCommand)
        {
            CreatedSubProgramLanguageDto result = await Mediator.Send(createSubProgramLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSubProgramLanguageQuery getListSubProgramLanguageQuery = new() { PageRequest = pageRequest };
            SubProgramLanguageListModel result = await Mediator.Send(getListSubProgramLanguageQuery);
            return Ok(result);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSubProgramLanguageQuery SubProgramLanguageQuery)
        {
            SubProgramLanguageGetByIdDto SubProgramLanguageGetByIdDto = await Mediator.Send(SubProgramLanguageQuery);
            return Ok(SubProgramLanguageGetByIdDto);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSubProgramLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedSubProgramLanguageDto deleteProgrammingLanguageDto = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(deleteProgrammingLanguageDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSubProgramLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedSubProgramLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Created("", result);
        }
    }
}
