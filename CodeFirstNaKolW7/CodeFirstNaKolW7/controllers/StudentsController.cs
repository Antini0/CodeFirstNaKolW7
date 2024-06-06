using CodeFirstNaKolW7.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstNaKolW7.controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    public StudentsController()
    {
        
    }
        

    [HttpGet]
    public IActionResult GetStudents()
    {
        var dbContext = new W7Context();
        var result = dbContext.Countries
            .Include(c => c.Region)
            .Where(c => c.CountryName.Contains("A"))
            .OrderBy(c => c.CountryName)
            .Select(c => new
            {
                Nazwa = c.CountryName
            });
        
        //include mowi "zrób mi joina i pobierz z innej tabeli"
        
        
        return Ok(result);
    }
}