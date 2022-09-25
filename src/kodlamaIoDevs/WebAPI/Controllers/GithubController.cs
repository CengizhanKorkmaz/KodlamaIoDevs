using Application.Features.Github.Commands.CreateGithub;
using Application.Features.Github.Commands.DeleteGithub;
using Application.Features.Github.Commands.UpdateGithub;
using Application.Features.Github.Dtos;
using Application.Features.Github.Models;
using Application.Features.Github.Queries.GetByIdGithub;
using Application.Features.Github.Queries.GetListGithub;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGithubCommand createGithubCommand)
        {
            CreatedGithubDto result = await Mediator.Send(createGithubCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGithubQuery getListGithubQuery = new() { PageRequest = pageRequest };
            GithubListModel result = await Mediator.Send(getListGithubQuery);
            return Ok(result);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdGithubQuery GithubQuery)
        {
            GithubGetByIdDto GithubGetByIdDto = await Mediator.Send(GithubQuery);
            return Ok(GithubGetByIdDto);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteGithubCommand deleteProgrammingLanguageCommand)
        {
            DeletedGithubDto deleteProgrammingLanguageDto = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(deleteProgrammingLanguageDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubCommand updateProgrammingLanguageCommand)
        {
            UpdatedGithubDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Created("", result);
        }
    }
}
