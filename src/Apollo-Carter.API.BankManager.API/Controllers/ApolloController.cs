using System;
using System.Threading.Tasks;
using Apollo_Carter.API.BankManager.Application.Services;
using Apollo_Carter.API.BankManager.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Apollo_Carter.API.BankManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApolloController : ControllerBase
    {
        private readonly ITaskService _taskService;


        public ApolloController(ITaskService taskService)
        {
            _taskService = taskService;            
        }

        /// <summary>
        /// Get Apollo Data
        /// </summary>
        /// <returns>Returns a list of All Apollo Data</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApolloViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _taskService.GetAll());
            }
            catch (Exception ex)
            {
                Log.Error($"Error: message: {ex.Message} ");

                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }

        /// <summary>
        /// Get Apollo Data by ID
        /// </summary>
        /// <param name="id">Apollo Data's ID</param>
        /// <returns>Returns a Task by its ID</returns>
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(ApolloViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _taskService.GetById(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Error: message: {ex.Message} ");

                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }

        /// <summary>
        /// Create a new Apollo Data
        /// </summary>
        /// <param name="taskViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApolloViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] ApolloViewModel taskViewModel)
        {
            try
            {
                return Ok(await _taskService.Create(taskViewModel));
            }
            catch (Exception ex)
            {
                Log.Error($"Error: message: {ex.Message} ");

                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }

        /// <summary>
        /// Delete a Apollo Data
        /// </summary>
        /// <param name="id">Apollo's ID</param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            try
            {
                await _taskService.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent);

            }
            catch (Exception ex)
            {
                Log.Error($"Error: message: {ex.Message} ");

                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
    }
}
