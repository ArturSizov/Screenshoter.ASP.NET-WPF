using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sceenshoter.Application.Interaction.Queries.GetScreensotList;
using Screenshoter.Application.Interaction.Commands.CreateScreenshot;
using Screenshoter.ASP.NET.Models;

namespace Screenshoter.ASP.NET.Controllers
{
    [Route("api/[controller]")]
    public class ScreenshotController : BaseController
    {
        private readonly IMapper _mapper;

        public ScreenshotController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of notes
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note
        /// </remarks>
        /// <returns>Returns NoteListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ScreenshotList>> GetAll()
        {
            var screenshot = new GetScreenshotListQuery
            {
               UserId = UserId
            };
            var vm = await Mediator.Send(screenshot);
            return Ok(vm);
        }

        /// <summary>
        /// Add screenshot
        /// </summary>
        /// <param name="createScreenshotDto"></param>
        /// <returns>Add screenshot</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateScreenshotDto createScreenshotDto)
        {
            var command = _mapper.Map<CreateScreenshotCommand>(createScreenshotDto);
            var screenshotId = await Mediator.Send(command);
            return Ok(screenshotId);
        }
    } 
}
