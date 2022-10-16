using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim;
using Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto createdUserOperationClaimDto = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", createdUserOperationClaimDto);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        {
            UpdatedUserOperationClaimDto updatedUserOperationClaimDto = await Mediator.Send(updateUserOperationClaimCommand);
            return Ok(updatedUserOperationClaimDto);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            DeletedUserOperationClaimDto deletedUserOperationClaimDto = await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok(deletedUserOperationClaimDto);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetListUserOperationClaimQuery getListUserOperationClaimQuery)
        {
            UserOperationClaimListModel userOperationClaimListModel = await Mediator.Send(getListUserOperationClaimQuery);
            return Ok(userOperationClaimListModel);
        }

        [HttpGet("UserId/{id}")]
        public async Task<IActionResult> GetByUserId([FromQuery] GetByUserIdUserOperationClaimQuery getByUserIdUserOperationClaim)
        {
            GetByUserIdUserOperationClaimDto getByUserIdUserOperationClaimDto = await Mediator.Send(getByUserIdUserOperationClaim);
            return Ok(getByUserIdUserOperationClaimDto);
        }
    }
}
