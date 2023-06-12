using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PenaltyCalculation.Models;
// using PenaltyCalculation.Models;
using PenaltyCalculation.Repos;
using PenaltyCalculation.Services;

namespace PenaltyCalculation.Controllers;

// [Authorize]
[ApiController]
[Route("[controller]")]
public class PenaltyController : ControllerBase
{
    private readonly IPenaltyRepository _penaltyRepository;
    private readonly ILogger<PenaltyController> _logger;

    public PenaltyController(ILogger<PenaltyController> logger, IPenaltyRepository penaltyRepository,
                            IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _penaltyRepository = penaltyRepository ?? throw new ArgumentNullException(nameof(penaltyRepository));
    }

    [HttpGet("GetAllPenalties")]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetPenalties()
    {
        var transactions = await _penaltyRepository.GetTransactionsAsync();
        
        return Ok(transactions);
    }

    [HttpGet("GetAllISINS")]
    public async Task<ActionResult<IEnumerable<char>>> GetISINs()
    {
        var listOfIsins = await _penaltyRepository.GetAllISINsAsync();

        return Ok(listOfIsins);
    }

    [HttpGet("{isin}")]
    public async Task<ActionResult<Transaction>> GetTransaction(string? isin)
    {
        var transaction = await _penaltyRepository.GetTransaction(isin);

        if (transaction == null)
        {
            return NotFound();
        }

        return transaction;
    }

}