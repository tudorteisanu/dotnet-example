using example.Interfaces;
using Example.Models;

namespace Example.Services;

public class PizzaService : IPizzaService
{
    private readonly MySQLDBContext _dbContext;  
    
    public PizzaService(MySQLDBContext context)
    {
        _dbContext = context;  
    }

    public List<Pizza> GetAll()
    {
        return this._dbContext.Pizza.ToList();
    }

    public Pizza? GetOne(int id)
    {
        return this._dbContext.Pizza.FirstOrDefault();
    }

    public Pizza Add(Pizza pizza)
    { 
        var newPizza = new Pizza { Name = pizza.Name, IsGlutenFree = pizza.IsGlutenFree };
       this._dbContext.Pizza.Add(newPizza);
       this._dbContext.SaveChanges();
       return newPizza;
    }

    public void Delete(int id)
    {
        var pizza = this.GetOne(id);
        if(pizza is null)
            return;
    }

    public void Update(Pizza pizza)
    {
    }
}