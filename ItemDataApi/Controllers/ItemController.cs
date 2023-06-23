using ItemDataApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItemDataApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{

    private static List<Item> items = new List<Item>();
    private static int id = 0;

    [HttpPost]
    public void CreateItem([FromBody] Item item)
    {
        item.Id = id++;
        items.Add(item);
    }

    [HttpGet]
    public IEnumerable<Item> GetItems([FromQuery]int skip = 0, [FromQuery]int take = 10)
    {
        return items.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public Item? GetItemById(int id)
    {
        return items.FirstOrDefault(item => item.Id == id);
    }
}
