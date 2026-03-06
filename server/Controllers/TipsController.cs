using AFCSite.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace AFCSite.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TipsController : ControllerBase
{
    // In-memory seed data — mirrors the Angular hardcoded guides.
    // Replace with a database / EF Core context when ready.
    private static readonly List<Guide> Guides =
    [
        new()
        {
            Slug = "ultimate-allergen-substitution-guide",
            Title = "The Ultimate Allergen Substitution Guide",
            Category = "Substitutions",
            ReadTime = "12 min read",
            Image = "images/ultimate_guide_on_table.png",
            Intro = "Whether you are cooking for someone with a newly diagnosed allergy or adapting a beloved family recipe, finding the right substitution can feel overwhelming.",
            Sections =
            [
                new() { Heading = "Dairy Substitutions", Content = "For milk, oat milk provides the closest neutral flavor for baking..." },
                new() { Heading = "Egg Substitutions", Content = "The best egg substitute depends on the role the egg plays in your recipe..." },
                new() { Heading = "Gluten Substitutions", Content = "A reliable gluten-free flour blend is essential..." }
            ]
        },
        new()
        {
            Slug = "how-to-read-food-labels",
            Title = "How to Read Food Labels for Allergens",
            Category = "Safety",
            ReadTime = "8 min read",
            Image = "images/How_to_Read_Food_Labels_Like_a_Pro.png",
            Intro = "Understanding food labels is one of the most important skills for anyone managing food allergies.",
            Sections =
            [
                new() { Heading = "Understanding the Label", Content = "Food labels can be complex, but knowing what to look for makes it manageable." }
            ]
        },
        new()
        {
            Slug = "setting-up-an-allergy-safe-kitchen",
            Title = "Setting Up an Allergy-Safe Kitchen",
            Category = "Kitchen Setup",
            ReadTime = "10 min read",
            Image = "images/Setting_Up_an_Allergy_Safe_Kitchen.png",
            Intro = "An allergy-safe kitchen is the foundation of safe cooking for those with food allergies.",
            Sections =
            [
                new() { Heading = "Organization", Content = "Keep allergen-free ingredients separated and clearly labeled." }
            ]
        },
        new()
        {
            Slug = "dining-out-with-food-allergies",
            Title = "Dining Out with Food Allergies",
            Category = "Lifestyle",
            ReadTime = "7 min read",
            Image = "images/Dining_Out.png",
            Intro = "Dining out with food allergies doesn't have to be stressful.",
            Sections =
            [
                new() { Heading = "Choosing a Restaurant", Content = "Look for restaurants that clearly mark allergens on their menus." }
            ]
        },
        new()
        {
            Slug = "baking-without-eggs",
            Title = "Baking Without Eggs: A Complete Guide",
            Category = "Baking",
            ReadTime = "9 min read",
            Image = "images/Baking_Without_Eggs_Techniques_That_Work.png",
            Intro = "Eggs play multiple roles in baking, but there are reliable substitutes for each one.",
            Sections =
            [
                new() { Heading = "Egg Roles in Baking", Content = "Understanding whether the egg is a binder, leavener, or moisturizer determines the best substitute." }
            ]
        },
        new()
        {
            Slug = "allergen-free-cooking-for-kids",
            Title = "Allergen-Free Cooking for Kids",
            Category = "Family",
            ReadTime = "8 min read",
            Image = "images/Allergen-Free_Cooking_for_Kids.png",
            Intro = "Getting kids excited about allergen-free food starts with making it fun and delicious.",
            Sections =
            [
                new() { Heading = "Kid-Friendly Recipes", Content = "Start with familiar favorites adapted to be allergen-free." }
            ]
        }
    ];

    /// <summary>
    /// GET /api/tips — returns all guides (summary only, no sections).
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var summaries = Guides.Select(g => new
        {
            g.Slug,
            g.Title,
            g.Category,
            g.ReadTime,
            g.Image,
            g.Intro
        });
        return Ok(summaries);
    }

    /// <summary>
    /// GET /api/tips/{slug} — returns full guide detail.
    /// </summary>
    [HttpGet("{slug}")]
    public IActionResult GetBySlug(string slug)
    {
        var guide = Guides.FirstOrDefault(g => g.Slug == slug);
        return guide is not null ? Ok(guide) : NotFound();
    }
}
