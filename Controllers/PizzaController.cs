using System.Text.Json;
using example.Interfaces;
using Example.Models;
using Example.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers;

[ApiController]
[Route("[controller]")]
// [Authorize]
public class PizzaController : ControllerBase
{
    
    private readonly IPizzaServiceInterface _service;  
  
    public PizzaController(IPizzaServiceInterface service)  
    {  
        _service = service;  
    }  
  
    [HttpGet]
    [AllowAnonymous]
    public IList<Pizza> Get()  
    {  
        return this._service.GetAll();  
    }
    
    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza?> Get(int id)
    {   
        var pizza = this._service.GetOne(id);

        if (pizza == null)
        {
            return NotFound();
        }

        return pizza;
    }

    // POST action
    [HttpPost]
    public Pizza Create( [FromBody] Pizza body)
    {
        
        return this._service.Add(body);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();
            
        var existingPizza = this._service.GetOne(id);
        if(existingPizza is null)
            return NotFound();
    
        this._service.Update(pizza);           
    
        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = this._service.GetOne(id);
    
        if (pizza is null)
            return NotFound();
        
        this._service.Delete(id);
    
        return NoContent();
    }
}