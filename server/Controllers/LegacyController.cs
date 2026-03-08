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

    [GeneratedRegex(@"<ul[^>]*class=""ingredients""[^>]*>(.*?)</ul>", RegexOptions.Singleline | RegexOptions.IgnoreCase)]
    private static partial Regex IngredientsBlockRegex();

    [GeneratedRegex(@"<ol[^>]*class=""method""[^>]*>(.*?)</ol>", RegexOptions.Singleline | RegexOptions.IgnoreCase)]
    private static partial Regex MethodBlockRegex();

    [GeneratedRegex(@"<li[^>]*>(.*?)</li>", RegexOptions.Singleline | RegexOptions.IgnoreCase)]
    private static partial Regex LiItemsRegex();

    [GeneratedRegex(@"\s+")]
    private static partial Regex WhitespaceRegex();

    private static string? ExtractFirstParagraph(string? html)
    {
        if (string.IsNullOrEmpty(html)) return null;
        var match = FirstParagraphRegex().Match(html);
        if (!match.Success) return null;
        return StripTagsRegex().Replace(match.Groups[1].Value, "").Trim();
    }

    private static List<string> ExtractLiItems(Regex blockRegex, string? html)
    {
        if (string.IsNullOrEmpty(html)) return [];
        var blockMatch = blockRegex.Match(html);
        if (!blockMatch.Success) return [];
        return LiItemsRegex().Matches(blockMatch.Groups[1].Value)
            .Select(m => StripTagsRegex().Replace(m.Groups[1].Value, "").Trim())
            .Where(s => !string.IsNullOrEmpty(s))
            .ToList();
    }

    private static string? ExtractNotes(string? html)
    {
        if (string.IsNullOrEmpty(html)) return null;
        var methodBlock = MethodBlockRegex().Match(html);
        if (!methodBlock.Success) return null;
        var after = html[(methodBlock.Index + methodBlock.Length)..];
        var notes = WhitespaceRegex().Replace(StripTagsRegex().Replace(after, " "), " ").Trim();
        return string.IsNullOrEmpty(notes) ? null : notes;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0)
    {
        var posts = await _db.RawPosts
            .Where(p => p.Publish)
            .OrderByDescending(p => p.PostDate ?? p.Created)
            .Skip(skip)
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

    [HttpGet("blog")]
    public async Task<IActionResult> GetBlogPosts()
    {
        var posts = await _db.RawPosts
            .Where(p => p.Publish && p.Categories.Any(c => c.CategoryType != null && c.CategoryType.Name == "BlogPost"))
            .OrderByDescending(p => p.PostDate ?? p.Created)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Description,
                PostDate = p.PostDate ?? p.Created,
                Category = p.Categories
                    .Where(c => c.CategoryType != null && c.CategoryType.Name == "BlogPost")
                    .Select(c => c.Name)
                    .FirstOrDefault(),
            })
            .ToListAsync();

        var result = posts.Select(p => new
        {
            p.Id,
            p.Name,
            Excerpt = ExtractFirstParagraph(p.Description),
            Image = Images[p.Id % Images.Length],
            p.PostDate,
            p.Category,
        });

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var post = await _db.RawPosts
            .Where(p => p.Id == id && p.Publish)
            .FirstOrDefaultAsync();

        if (post is null) return NotFound();

        return Ok(new
        {
            post.Id,
            post.Name,
            Image = Images[post.Id % Images.Length],
            Excerpt = ExtractFirstParagraph(post.Description),
            Ingredients = ExtractLiItems(IngredientsBlockRegex(), post.Description),
            Method = ExtractLiItems(MethodBlockRegex(), post.Description),
            Notes = ExtractNotes(post.Description),
        });
    }
}
