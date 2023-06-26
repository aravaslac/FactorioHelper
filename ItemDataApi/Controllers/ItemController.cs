using AutoMapper;
using ItemDataApi.Data;
using ItemDataApi.Data.Dtos;
using ItemDataApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ItemDataApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private ItemContext _context;
    private IMapper _mapper;

    public ItemController(ItemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddItem([FromBody] CreateItemDto itemDto)
    {
        Item item = _mapper.Map<Item>(itemDto);
        _context.Items.Add(item);
        _context.SaveChanges();
        return CreatedAtAction(
                nameof(GetItemById),
                new { id = item.Id },
                item
                );
    }

    [HttpGet]
    public IEnumerable<ReadItemDto> GetItems([FromQuery]int skip = 0, [FromQuery]int take = 10)
    {
        return _mapper.Map<List<ReadItemDto>>(_context.Items.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetItemById(int id)
    {
        var item = _context.Items.FirstOrDefault(
            item => item.Id == id);
        if (item == null) return NotFound();
        var itemDto = _mapper.Map<ReadItemDto>(item);
        return Ok(item);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateItem(int id, [FromBody] UpdateItemDto itemDto)
    {
        var item = _context.Items.FirstOrDefault(
            item => item.Id == id);
        if (item == null) return NotFound();
        _mapper.Map(itemDto, item);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateItemPartially(int id, JsonPatchDocument<UpdateItemDto> patch)
    {

        var item = _context.Items.FirstOrDefault(
            item => item.Id == id);
        if (item == null) return NotFound();

        var itemToUpdate = _mapper.Map<UpdateItemDto>(item);
        patch.ApplyTo(itemToUpdate, ModelState);

        if (!TryValidateModel(itemToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(itemToUpdate, item);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteItem(int id)
    {
        var item = _context.Items.FirstOrDefault(
            item => item.Id == id);
        if (item == null) return NotFound();
        _context.Remove(item);
        _context.SaveChanges();
        return NoContent();
    }
}
