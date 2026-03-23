using Microsoft.AspNetCore.Mvc;
using BowlingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BowlingAPI.Controllers;

// Sets the URL route to api/bowlers
[Route("api/[controller]")]
// Marks this as an API controller
[ApiController]
public class BowlersController : ControllerBase
{
    // Holds our database connection
    private readonly BowlingContext _context;

    // Constructor injection - .NET automatically passes in BowlingContext
    public BowlersController(BowlingContext context)
    {
        _context = context;
    }

    // Handles GET requests to api/bowlers and returns all bowlers as JSON
    [HttpGet]
    public IEnumerable<object> GetBowlers()
    {
        // Join Bowlers with Teams, filter for only Marlins and Sharks
        var bowlers = (from b in _context.Bowlers
            join t in _context.Teams on b.TeamID equals t.TeamID
            where t.TeamName == "Marlins" || t.TeamName == "Sharks"
            select new
            {
                b.BowlerID,
                b.BowlerFirstName,
                b.BowlerLastName,
                b.BowlerMiddleInit,
                b.BowlerAddress,
                b.BowlerCity,
                b.BowlerState,
                b.BowlerZip,
                b.BowlerPhoneNumber,
                t.TeamName
            }).ToList();
        return bowlers;
    }
}