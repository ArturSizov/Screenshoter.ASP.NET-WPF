using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sceenshoter.ScreenshoterApplication.Interaction.Queries.GetScreensotList;
using Screenshoter.ScreenshoterApplication.Interaction.Commands.CreateScreenshot;
using Screenshoter.ScreenshoterApplication.Interaction.Commands.DeleteScreenshot;

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
               Id = Id
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

        /// <summary>
        /// Deletes the screenshot by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /screenshot/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the screenshot (guid)</param>
        /// <returns>Returns Delete</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteScreenshotCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    } 
}
