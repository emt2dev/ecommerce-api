using api.DAL.Interfaces;
using api.DAL.Models;
using api.DAL.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebugController : ControllerBase
    {
        private readonly IEntryService _ES;
        private readonly UserManager<UserModel> _UM;
        private readonly ILogger<DebugController> _LOGS;

        public DebugController(IEntryService ES, UserManager<UserModel> UM, ILogger<DebugController> LOGS)
        {
            this._ES = ES;
            this._UM = UM;
            this._LOGS = LOGS;
        }

        [HttpGet]
        [Route("new/shopper")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public async Task<IActionResult> DebugNewShopper()
        {
            BaseUserDTO NewShopper = new BaseUserDTO
            {
                Email = "shopper@shopper.com",
                Password = "P@ssword1",
                Source = "Shopper",
            };

            _ = await _ES.RegisterUser(NewShopper);
            return Ok();
        }

        [HttpGet]
        [Route("new/employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public async Task<IActionResult> DebugNewEmployee()
        {
            BaseUserDTO NewEmployee = new BaseUserDTO
            {
                Email = "employee@employee.com",
                Password = "P@ssword1",
                Source = "Employee",
            };

            _ = await _ES.RegisterUser(NewEmployee);
            return Ok();
        }

        [HttpGet]
        [Route("new/manager")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public async Task<IActionResult> DebugNewManager()
        {
            BaseUserDTO NewManager = new BaseUserDTO
            {
                Email = "manager@manager.com",
                Password = "P@ssword1",
                Source = "Manager",
            };

            _ = await _ES.RegisterUser(NewManager);
            return Ok();
        }

        [HttpGet]
        [Route("new/owner")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public async Task<IActionResult> DebugNewOwner()
        {
            BaseUserDTO NewOwner = new BaseUserDTO
            {
                Email = "owner@owner.com",
                Password = "P@ssword1",
                Source = "Owner",
            };

            _ = await _ES.RegisterUser(NewOwner);
            return Ok();
        }

        [HttpGet]
        [Route("new/dev")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // if validation fails, send this
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // If client issues
        [ProducesResponseType(StatusCodes.Status200OK)] // if okay
        public async Task<IActionResult> DebugNewDev()
        {
            BaseUserDTO NewDeveloper = new BaseUserDTO
            {
                Email = "dev@dev.com",
                Password = "P@ssword1",
                Source = "Developer",
            };

            _ = await _ES.RegisterUser(NewDeveloper);
            return Ok();
        }
    }
}
