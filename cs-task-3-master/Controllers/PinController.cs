using Csharp_Task_3.Data;
using Csharp_Task_3.Models;
using Csharp_Task_3.Models.Dto;
using Csharp_Task_3.Pins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Csharp_Task_3.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/pins")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class PinController : ControllerBase
{
    private readonly ILogger<PinController> _logger;
    public PinController(ILogger<PinController> logger)
    {
        _logger = logger;
        
    }

    [MapToApiVersion("1.0")]
    [HttpGet("{pin}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<PinDTO> Get(string pin)
    {
        _logger.LogInformation("Get one pin ");
        if (pin.Length > 8)
        {
            _logger.LogError("Pin is out of scope. Maximum lenght is 8");
            return BadRequest("Pin is out of scope. Maximum lenght is 8");
        }

        //we accept only digits
        Regex  regex = new Regex("^[0-9]+$");

        if (regex.IsMatch(pin))
        {
            //prepare DTO object 
            PinDTO pins = new PinDTO();

            PinMatrix pmx = new PinMatrix();
            //calculate all variations
            try
            {
                pins.CalulatedPins = pmx.GetPINs(pin);
            }
            catch (Exception ee)
            {
                _logger.LogError("GetPINs exception: " + ee.Message);
                return NotFound("Cannot find any variations for pin: " + pin);
            }


            if (pins.CalulatedPins != null)
            {
                return Ok(pins);
            }
            else
            {
                return NotFound("Cannot find any variations for pin: " + pin);
            }
        }
        else
        {
            return NotFound("Input string is not valid. Please use numbers fom 0-9, your pin is: " + pin);
        }

    }


   

}