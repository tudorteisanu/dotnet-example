using Example.Models;

namespace example.Interfaces;

public interface IPizzaServiceInterface
{
    Pizza? GetOne(int id);
    List<Pizza> GetAll();
    public Pizza Add(Pizza pizza);
    public void Update(Pizza pizza);
    public void Delete(int id);

}