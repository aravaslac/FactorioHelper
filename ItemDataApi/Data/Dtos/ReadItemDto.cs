using System.ComponentModel.DataAnnotations;

namespace ItemDataApi.Data.Dtos;

public class ReadItemDto
{
    public string? Name { get; set; }
    public string? Recipe { get; set; }
    public string? CraftableIn { get; set; }
    public double CraftingTime { get; set; }
    public int StackSize { get; set; }
    public DateTime QueryTime { get; set; } = DateTime.Now;
}
