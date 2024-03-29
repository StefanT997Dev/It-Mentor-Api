using System.Threading.Tasks;
using Application.Mentors;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Attributes;
using System.Security.Claims;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Core.Wrappers;
using Domain;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace API.Controllers
{
	public class MentorsController : BaseApiController
    {
		private readonly DataContext _context;
		private readonly ILogger<MentorsController> _logger;

		public MentorsController(DataContext context, ILogger<MentorsController> logger)
		{
			_context = context;
			_logger = logger;
		}

		[AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetMentorsPaginated([FromQuery] FilterDto filter)
        {
            return HandlePagedListResult(await Mediator.Send(new PaginatedList.Query{ Filter = filter }));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMentor(string id)
        {
            LogAuditEvent();
            return HandleResult(await Mediator.Send(new Details.Query{Id=id}));
        }

        /*[AllowAnonymous]
        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetReviews(string id)
        {
            return HandleResultForLists(await Mediator.Send(new Application.Reviews.List.Query{Id=id}));
        }*/

        [ClaimRequirement(ClaimTypes.Role, "Client")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Client")]
        [HttpPost("{id}/reviews")]
        public async Task<IActionResult> PostReview([FromRoute]string id,[FromBody]ReviewDto review)
        {
            return Ok(await Mediator.Send(new Application.Reviews.Create.Command{Id=id,Review=review}));
        }

        /*[AllowAnonymous]
        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetPosts(string id)
        {
            return HandleResultForLists(await Mediator.Send(new ListForMentor.Query{Id=id}));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Mentor")]
        [HttpPost("{id}/posts")]
        public async Task<IActionResult> PostAPost(string id,Post post)
        {
            return Ok(await Mediator.Send(new CreateAPost.Command{Id=id,Post=post}));
        }
*/
        /*[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Search(SearchSkillDto skill)
        {
            //return Ok(await Mediator.Send(new Search.Command{Skill=skill}));
        }*/

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Mentor")]
        [HttpPatch]
        public async Task<IActionResult> Update(UpdateMentorDto mentor)
        {
            return HandleResult(await Mediator.Send(new Edit.Command { Mentor = mentor }));
        }
    }
}