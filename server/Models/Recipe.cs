namespace AFCSite.Server.Models;

public class Recipe
{
    public required string Slug { get; set; }
    public required string Title { get; set; }
    public required string Category { get; set; }
    public required string Time { get; set; }
    public required string Difficulty { get; set; }
    public required string Servings { get; set; }
    public required string Image { get; set; }
    public required string Description { get; set; }
    public required List<string> Ingredients { get; set; }
    public required List<string> Method { get; set; }
}
