### Example Project

Start project:
```shell
docker-compose up -d
```

### Migrations
add new migration
```shell
dotnet ef migrations add <migrationName>
```
apply migrations
```shell
dotnet ef database update 
```

### DI
- Create new service
- Create interface for this srevice
- then update `Program.cs`
```
builder.Services.AddScoped<<ServiceInterface>, <Service>();
```

- usage in controller
```shell
public class ExampleController : ControllerBase
{
    
    private readonly IExampleServiceInterface _service;  
  
    public PizzaController(IExampleServiceInterface service)  
    {  
        _service = service;  
    }  
    
    
    [HttpGet]
    public IList<Example> Get()  
    {  
        return this._service.GetAll();  
    }
}
```