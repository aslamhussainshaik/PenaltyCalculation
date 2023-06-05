
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PenaltyCalculation.Repos;

namespace PenaltyCalculation.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<RegistrationController> _logger;
    private readonly PenaltyCalculationDBContext _dbContext;

    public RegistrationController(ILogger<RegistrationController> logger, IConfiguration configuration,
                                    PenaltyCalculationDBContext dbContext)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    [HttpPost(Name = "RegisterUser")]
    public async Task<IActionResult> RegisterUser(Registration registration)
    {
        try
        {
            // Check ModelState for validation errors
            if (registration.Id <= 0 || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // check if the email is already registered
            if (await _dbContext.Registrations.AnyAsync(r => r.EmailId == registration.EmailId))
            {
                _logger.LogInformation($"user with {registration.EmailId} already registered.");
                return Conflict("Email already exists");
            }

            // Add the registration to the database
            _dbContext.Registrations.Add(registration);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"User {registration.FirstName} {registration.LastName} has succesfully registered.");

            return NoContent();
            // return Ok("Registration Successful.");
        }
        catch (Exception ex)
        {
            // Handle any exceptions
            _logger.LogCritical($"An error occured while registering the user. {ex.InnerException}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occured.");
        }
    }
}