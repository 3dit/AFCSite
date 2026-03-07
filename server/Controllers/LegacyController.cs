using AFCSite.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace AFCSite.Server.Controllers;

[ApiController]
[Route("api/legacy")]
public partial class LegacyController : ControllerBase
{
    private readonly AppDbContext _db;

    public LegacyController(AppDbContext db) => _db = db;

    private static readonly string[] Images =
    [
        "/images/banana_bread.png",
        "/images/creamy_tomato_soup.png",
        "/images/egg_free_chocolate_cake.png",
        "/images/nut_free_pesto_pasta.png",
        "/images/soy_free_teryaki_chicken.png",
        "/images/Gluten-Free_Pizza_Dough.png",
        "/images/Dairy-Free_Mac_&_Cheese.png",
        "/images/Top-8-Free-Veggie-Burger.png",
        "/images/ultimate_substitution_guide.png",
        "/images/ultimate_guide_on_table.png",
        "/images/Dining_Out.png",
        "/images/Baking_Without_Eggs_Techniques_That_Work.png",
        "/images/How_to_Read_Food_Labels_Like_a_Pro.png",
        "/images/Setting_Up_an_Allergy_Safe_Kitchen.png",
        "/images/Allergen-Free_Cooking_for_Kids.png",
    ];

    [GeneratedRegex(@"<p[^>]*>(.*?)</p>", RegexOptions.Singleline | RegexOptions.IgnoreCase)]
    private static partial Regex FirstParagraphRegex();

    [GeneratedRegex(@"<[^>]+>")]
    private static partial Regex StripTagsRegex();

    private static string? ExtractFirstParagraph(string? html)
    {
        if (string.IsNullOrEmpty(html)) return null;
        var match = FirstParagraphRegex().Match(html);
        if (!match.Success) return null;
        return StripTagsRegex().Replace(match.Groups[1].Value, "").Trim();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _db.RawPosts
            .Where(p => p.Publish)
            .OrderByDescending(p => p.PostDate ?? p.Created)
            .Take(20)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Description,
            })
            .ToListAsync();

        var result = posts.Select(p => new
        {
            p.Id,
            p.Name,
            Excerpt = ExtractFirstParagraph(p.Description),
            Image = Images[p.Id % Images.Length],
        });

        return Ok(result);
    }
}
