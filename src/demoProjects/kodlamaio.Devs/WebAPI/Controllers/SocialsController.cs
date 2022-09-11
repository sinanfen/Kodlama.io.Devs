using Application.Features.Socials.Commands.CreateSocial;
using Application.Features.Socials.Commands.DeleteSocial;
using Application.Features.Socials.Commands.UpdateSocial;
using Application.Features.Socials.Models;
using Application.Features.Socials.Queries.GetListSocial;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialCommand createSocialCommand)
        {
            var result = await Mediator.Send(createSocialCommand);

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSocialCommand deleteSocialCommand)
        {
            var result = await Mediator.Send(deleteSocialCommand);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialCommand updateSocialCommand)
        {
            var result = await Mediator.Send(updateSocialCommand);

            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSocialQuery getListSocialQuery = new() { PageRequest = pageRequest };
            SocialListModel result = await Mediator.Send(getListSocialQuery);
            return Ok(result);
        }
    }
}
