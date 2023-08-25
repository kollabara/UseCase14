using System.Globalization;
using System.Resources;
using Microsoft.AspNetCore.Mvc;

namespace UseCase14.Controllers;

[Route("[controller]/format/{locale:locale}")]
public class TestController : ControllerBase
{
    private readonly ResourceManager _resourceManager;

    public TestController()
    {
        _resourceManager = Resources.Controllers.TestController.ResourceManager;
    }

    [HttpGet("date")]
    public IActionResult FormatDate()
    {
        var localizeTemplate =
            _resourceManager.GetString("DateTime", CultureInfo.CurrentCulture);

        return Ok(DateTime.UtcNow.ToString(localizeTemplate));
    }

    [HttpGet("number")]
    public IActionResult FormatNumber([FromQuery]long number)
    {
        var localizeTemplate =
            _resourceManager.GetString("Number", CultureInfo.CurrentCulture);

        return Ok(number.ToString(localizeTemplate));
    }
    
    [HttpGet("fluid")]
    public IActionResult FormatFluid([FromQuery]long fluid)
    {
        var localizeTemplate =
            _resourceManager.GetString("Fluid", CultureInfo.CurrentCulture);

        var formattedFluid = localizeTemplate switch
        {
            "oz" => fluid * 33.8,
            _ => fluid
        };

        return Ok($"In {CultureInfo.CurrentCulture.Name} you have {formattedFluid} {localizeTemplate}");
    }
    
    [HttpGet("weight")]
    public IActionResult FormatWeight([FromQuery]long weight)
    {
        var localizeTemplate =
            _resourceManager.GetString("Weight", CultureInfo.CurrentCulture);

        var formattedWeight = localizeTemplate switch
        {
            "pounds" => weight * 2.2,
            _ => weight
        };

        return Ok($"In {CultureInfo.CurrentCulture.Name} you have {formattedWeight} {localizeTemplate}");
    }
    
    [HttpGet("length")]
    public IActionResult FormatLength([FromQuery]long length)
    {
        var localizeTemplate =
            _resourceManager.GetString("Length", CultureInfo.CurrentCulture);

        var formattedLength = localizeTemplate switch
        {
            "inches" => length * 0.4,
            _ => length
        };

        return Ok($"In {CultureInfo.CurrentCulture.Name} you have {formattedLength} {localizeTemplate}");
    }
    
    [HttpGet]
    public IActionResult ChangeLocale()
    {
        return Ok();
    }
}