using System.ComponentModel.DataAnnotations;

namespace ItemDataApi.Models;

public class Item
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The name is required.")]
    [MaxLength(255, ErrorMessage = "Name is too long.")]
    public string Name { get; set; }

    [Required]
    public string Recipe { get; set; }

    [Required]
    public string CraftableIn { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Ivalid crafting time.")]
    public double CraftingTime { get; set; }

    [Required]
    [Range(1, 200, ErrorMessage = "Max stack size is 200.")]
    public int StackSize { get; set; }
}