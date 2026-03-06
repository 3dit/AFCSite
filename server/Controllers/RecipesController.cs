using AFCSite.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace AFCSite.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    // In-memory seed data — mirrors the Angular hardcoded recipes.
    // Replace with a database / EF Core context when ready.
    private static readonly List<Recipe> Recipes =
    [
        new()
        {
            Slug = "classic-gluten-free-banana-bread",
            Title = "Classic Gluten-Free Banana Bread",
            Category = "Gluten-Free",
            Time = "55 min",
            Difficulty = "Easy",
            Servings = "8 slices",
            Image = "images/banana_bread.png",
            Description = "Moist, flavorful banana bread using our signature gluten-free flour blend. This recipe produces a perfectly tender loaf every time.",
            Ingredients =
            [
                "3 large ripe bananas, mashed",
                "2 cups gluten-free all-purpose flour blend",
                "3/4 cup granulated sugar",
                "1/3 cup melted coconut oil",
                "2 large eggs",
                "1 teaspoon vanilla extract",
                "1 teaspoon baking soda",
                "1/2 teaspoon salt",
                "1/2 teaspoon cinnamon",
                "1/4 teaspoon nutmeg",
                "1/2 cup dairy-free chocolate chips (optional)"
            ],
            Method =
            [
                "Preheat your oven to 350°F (175°C). Grease a 9x5-inch loaf pan and line with parchment paper.",
                "In a large bowl, mash the bananas until mostly smooth with a few small chunks remaining for texture.",
                "Add the melted coconut oil, sugar, eggs, and vanilla extract to the bananas. Whisk until well combined.",
                "In a separate bowl, whisk together the gluten-free flour blend, baking soda, salt, cinnamon, and nutmeg.",
                "Fold the dry ingredients into the wet ingredients until just combined. Do not overmix — a few streaks of flour are fine.",
                "Fold in the chocolate chips if using.",
                "Pour the batter into the prepared loaf pan and smooth the top with a spatula.",
                "Bake for 50–55 minutes, until a toothpick inserted into the center comes out clean or with just a few moist crumbs.",
                "Let the bread cool in the pan for 10 minutes, then transfer to a wire rack to cool completely before slicing."
            ]
        },
        new()
        {
            Slug = "dairy-free-creamy-tomato-soup",
            Title = "Dairy-Free Creamy Tomato Soup",
            Category = "Dairy-Free",
            Time = "30 min",
            Difficulty = "Easy",
            Servings = "4 servings",
            Image = "images/creamy_tomato_soup.png",
            Description = "Rich and velvety tomato soup made with cashew cream for incredible depth of flavor. Comfort food at its finest, without a drop of dairy.",
            Ingredients =
            [
                "2 tablespoons olive oil",
                "1 medium yellow onion, diced",
                "3 cloves garlic, minced",
                "2 cans (28 oz each) whole San Marzano tomatoes",
                "1 cup raw cashews, soaked in hot water for 15 minutes and drained",
                "1 cup vegetable broth",
                "2 tablespoons tomato paste",
                "1 teaspoon dried basil",
                "1/2 teaspoon dried oregano",
                "1/2 teaspoon smoked paprika",
                "1 teaspoon sugar",
                "Salt and black pepper to taste",
                "Fresh basil leaves for garnish"
            ],
            Method =
            [
                "Heat the olive oil in a large pot over medium heat. Add the diced onion and cook for 5 minutes until softened and translucent.",
                "Add the garlic and cook for another 30 seconds until fragrant.",
                "Add the canned tomatoes with their juices, tomato paste, dried basil, oregano, smoked paprika, and sugar. Stir to combine.",
                "Bring to a simmer and cook for 15 minutes, stirring occasionally, until the tomatoes have broken down.",
                "While the soup simmers, blend the soaked and drained cashews with the vegetable broth in a blender until completely smooth, about 1–2 minutes.",
                "Add the cashew cream to the pot and stir to combine.",
                "Use an immersion blender to puree the soup until smooth. Alternatively, carefully blend in batches in a standing blender.",
                "Season with salt and pepper to taste. Ladle into bowls and garnish with fresh basil leaves before serving."
            ]
        },
        new()
        {
            Slug = "nut-free-pesto-pasta",
            Title = "Nut-Free Pesto Pasta",
            Category = "Nut-Free",
            Time = "20 min",
            Difficulty = "Easy",
            Servings = "4 servings",
            Image = "images/nut_free_pesto_pasta.png",
            Description = "A vibrant pesto using sunflower seeds instead of pine nuts, tossed with your favorite pasta. Bright, herbaceous, and completely nut-free.",
            Ingredients =
            [
                "12 oz pasta of choice (use gluten-free pasta if needed)",
                "2 cups fresh basil leaves, packed",
                "1/2 cup roasted sunflower seeds",
                "1/2 cup extra virgin olive oil",
                "3 cloves garlic",
                "2 tablespoons lemon juice",
                "1/2 teaspoon salt",
                "1/4 teaspoon black pepper",
                "1/4 cup nutritional yeast (or grated Parmesan if dairy is tolerated)",
                "1/4 cup reserved pasta cooking water",
                "Cherry tomatoes, halved, for serving",
                "Fresh basil for garnish"
            ],
            Method =
            [
                "Bring a large pot of salted water to a boil. Cook pasta according to package directions until al dente. Reserve 1/2 cup of pasta water before draining.",
                "While the pasta cooks, combine the basil, sunflower seeds, garlic, lemon juice, salt, and pepper in a food processor. Pulse several times until coarsely chopped.",
                "With the food processor running, slowly drizzle in the olive oil until the pesto reaches your desired consistency.",
                "Add the nutritional yeast and pulse a few more times to combine.",
                "Drain the pasta and return it to the pot. Add the pesto and toss to coat, adding reserved pasta water a tablespoon at a time until the sauce clings nicely to the pasta.",
                "Serve topped with halved cherry tomatoes and fresh basil."
            ]
        },
        new()
        {
            Slug = "egg-free-chocolate-cake",
            Title = "Egg-Free Chocolate Cake",
            Category = "Egg-Free",
            Time = "45 min",
            Difficulty = "Medium",
            Servings = "12 slices",
            Image = "images/egg_free_chocolate_cake.png",
            Description = "A decadent chocolate cake that uses aquafaba for lift and moisture. Rich, fudgy, and indistinguishable from traditional chocolate cake.",
            Ingredients =
            [
                "2 cups all-purpose flour",
                "2 cups granulated sugar",
                "3/4 cup unsweetened cocoa powder",
                "2 teaspoons baking soda",
                "1 teaspoon baking powder",
                "1 teaspoon salt",
                "1 cup aquafaba (liquid from a can of chickpeas)",
                "1 cup oat milk (or any dairy-free milk)",
                "1/2 cup vegetable oil",
                "2 teaspoons vanilla extract",
                "1 cup hot coffee or hot water",
                "For the frosting:",
                "1/2 cup cocoa powder",
                "3 cups powdered sugar",
                "1/3 cup oat milk",
                "1/3 cup coconut oil, softened",
                "1 teaspoon vanilla extract"
            ],
            Method =
            [
                "Preheat the oven to 350°F (175°C). Grease and flour two 9-inch round cake pans.",
                "In a large bowl, whisk together the flour, sugar, cocoa powder, baking soda, baking powder, and salt.",
                "Add the aquafaba, oat milk, vegetable oil, and vanilla extract. Beat with an electric mixer on medium speed for 2 minutes.",
                "Stir in the hot coffee — the batter will be thin, but this is expected. The coffee deepens the chocolate flavor.",
                "Divide the batter evenly between the prepared pans.",
                "Bake for 30–35 minutes, until a toothpick inserted in the center comes out clean.",
                "Cool in pans for 10 minutes, then turn out onto wire racks to cool completely.",
                "For the frosting, beat together the coconut oil and cocoa powder. Gradually add powdered sugar alternating with oat milk, beating until smooth. Add vanilla.",
                "Place one cake layer on a serving plate. Spread frosting on top, then place the second layer on top. Frost the top and sides of the cake."
            ]
        },
        new()
        {
            Slug = "soy-free-teriyaki-chicken",
            Title = "Soy-Free Teriyaki Chicken",
            Category = "Soy-Free",
            Time = "35 min",
            Difficulty = "Easy",
            Servings = "4 servings",
            Image = "images/soy_free_teryaki_chicken.png",
            Description = "Sweet and savory teriyaki made with coconut aminos instead of soy sauce. All the flavor of classic teriyaki, completely soy-free.",
            Ingredients =
            [
                "1.5 lbs boneless, skinless chicken thighs, cut into bite-sized pieces",
                "1 tablespoon avocado oil",
                "For the teriyaki sauce:",
                "1/2 cup coconut aminos",
                "2 tablespoons honey",
                "1 tablespoon rice vinegar",
                "1 tablespoon sesame oil",
                "2 cloves garlic, minced",
                "1 teaspoon fresh ginger, grated",
                "1 tablespoon cornstarch mixed with 2 tablespoons water",
                "For serving:",
                "Steamed white or brown rice",
                "2 green onions, thinly sliced",
                "1 tablespoon sesame seeds",
                "Steamed broccoli"
            ],
            Method =
            [
                "In a small bowl, whisk together the coconut aminos, honey, rice vinegar, sesame oil, garlic, and ginger. Set aside.",
                "Heat the avocado oil in a large skillet or wok over medium-high heat.",
                "Season the chicken pieces with salt and pepper. Add to the hot skillet in a single layer, working in batches if needed to avoid crowding.",
                "Cook the chicken for 4–5 minutes per side until golden brown and cooked through (internal temperature of 165°F).",
                "Pour the teriyaki sauce over the chicken and bring to a simmer.",
                "Add the cornstarch slurry and stir constantly for 1–2 minutes until the sauce thickens and coats the chicken in a glossy glaze.",
                "Serve immediately over steamed rice, garnished with sliced green onions and sesame seeds, with steamed broccoli on the side."
            ]
        },
        new()
        {
            Slug = "top-8-free-veggie-burger",
            Title = "Top-8 Free Veggie Burger",
            Category = "Top-8 Free",
            Time = "40 min",
            Difficulty = "Medium",
            Servings = "6 patties",
            Image = "images/Top-8-Free-Veggie-Burger.png",
            Description = "A hearty veggie burger free from all top-8 allergens, packed with flavor. Holds together beautifully and satisfies even the biggest appetites.",
            Ingredients =
            [
                "1 can (15 oz) black beans, drained and rinsed",
                "1 cup cooked quinoa",
                "1/2 cup finely diced mushrooms",
                "1/2 cup finely diced red bell pepper",
                "1/4 cup finely diced red onion",
                "2 cloves garlic, minced",
                "1/4 cup oat flour (certified gluten-free)",
                "2 tablespoons ground flaxseed mixed with 5 tablespoons water (flax egg)",
                "1 teaspoon cumin",
                "1 teaspoon smoked paprika",
                "1/2 teaspoon chili powder",
                "1/2 teaspoon salt",
                "1/4 teaspoon black pepper",
                "1 tablespoon olive oil for cooking",
                "Allergen-free buns and desired toppings for serving"
            ],
            Method =
            [
                "Prepare the flax egg by mixing ground flaxseed with water. Let sit for 5 minutes until it thickens into a gel.",
                "In a large bowl, mash the black beans with a fork until mostly mashed with some chunks remaining for texture.",
                "Heat a small skillet over medium heat. Sauté the mushrooms, bell pepper, and onion for 5 minutes until softened. Add the garlic and cook 30 seconds more. Let cool slightly.",
                "Add the sautéed vegetables, cooked quinoa, oat flour, flax egg, cumin, smoked paprika, chili powder, salt, and pepper to the beans. Mix until well combined.",
                "Form the mixture into 6 patties, about 3/4 inch thick. Place on a parchment-lined baking sheet and refrigerate for 15 minutes to firm up.",
                "Heat olive oil in a large skillet over medium heat. Cook the patties for 4–5 minutes per side until a crispy crust forms and the patties are heated through.",
                "Serve on allergen-free buns with your favorite toppings — lettuce, tomato, avocado, and mustard all work great."
            ]
        },
        new()
        {
            Slug = "gluten-free-pizza-dough",
            Title = "Gluten-Free Pizza Dough",
            Category = "Gluten-Free",
            Time = "90 min",
            Difficulty = "Medium",
            Servings = "2 crusts (12-inch)",
            Image = "images/Gluten-Free_Pizza_Dough.png",
            Description = "Crispy, chewy pizza dough that folds and stretches like the real thing. The secret is a combination of tapioca starch and psyllium husk for elasticity.",
            Ingredients =
            [
                "2 cups gluten-free all-purpose flour blend",
                "1/2 cup tapioca starch",
                "2 teaspoons psyllium husk powder",
                "1 packet (2 1/4 teaspoons) active dry yeast",
                "1 teaspoon sugar",
                "1 cup warm water (110°F)",
                "2 tablespoons olive oil",
                "1 teaspoon salt",
                "1 teaspoon Italian seasoning",
                "1/2 teaspoon garlic powder",
                "Cornmeal or additional flour for dusting"
            ],
            Method =
            [
                "In a small bowl, combine the warm water, sugar, and yeast. Stir gently and let sit for 5–10 minutes until foamy.",
                "In a large bowl, whisk together the gluten-free flour blend, tapioca starch, psyllium husk powder, salt, Italian seasoning, and garlic powder.",
                "Add the yeast mixture and olive oil to the dry ingredients. Stir with a wooden spoon until a shaggy dough forms.",
                "Knead the dough in the bowl for 2–3 minutes. It should be slightly sticky but hold together. Add flour a tablespoon at a time if too wet.",
                "Cover the bowl with a damp towel or plastic wrap and let rise in a warm spot for 45–60 minutes until nearly doubled in size.",
                "Preheat your oven to 475°F (245°C). If using a pizza stone, place it in the oven while preheating.",
                "Divide the dough in half. On a sheet of parchment paper dusted with cornmeal, press and stretch each portion into a 12-inch round.",
                "Par-bake the crust for 8 minutes. Remove from oven, add your desired sauce and toppings, then return to the oven for another 8–10 minutes until the crust is golden and toppings are bubbly."
            ]
        },
        new()
        {
            Slug = "dairy-free-mac-and-cheese",
            Title = "Dairy-Free Mac & Cheese",
            Category = "Dairy-Free",
            Time = "25 min",
            Difficulty = "Easy",
            Servings = "6 servings",
            Image = "images/Dairy-Free_Mac_&_Cheese.png",
            Description = "Ultra-creamy mac and cheese made from sweet potatoes and nutritional yeast. Kids and adults alike will be amazed this is dairy-free.",
            Ingredients =
            [
                "16 oz elbow macaroni (use gluten-free if needed)",
                "1 large sweet potato, peeled and cubed (about 2 cups)",
                "1/2 cup raw cashews, soaked for 15 minutes (omit for nut-free)",
                "1 cup vegetable broth",
                "1/4 cup nutritional yeast",
                "2 tablespoons lemon juice",
                "1 tablespoon apple cider vinegar",
                "1 teaspoon onion powder",
                "1 teaspoon garlic powder",
                "1 teaspoon smoked paprika",
                "1 teaspoon salt",
                "1/2 teaspoon turmeric (for color)",
                "1/2 teaspoon mustard powder",
                "Black pepper to taste",
                "Fresh chives for garnish"
            ],
            Method =
            [
                "Cook the macaroni in a large pot of salted boiling water according to package directions. Drain and set aside.",
                "While the pasta cooks, steam or boil the sweet potato cubes for 12–15 minutes until fork-tender. Drain well.",
                "Add the cooked sweet potato, soaked cashews, vegetable broth, nutritional yeast, lemon juice, apple cider vinegar, onion powder, garlic powder, smoked paprika, salt, turmeric, and mustard powder to a high-speed blender.",
                "Blend on high for 1–2 minutes until completely smooth and creamy. Scrape down the sides as needed.",
                "Pour the sauce over the cooked pasta and stir until every piece is coated in the creamy sauce.",
                "If the sauce is too thick, add a splash of vegetable broth or pasta water to thin it out.",
                "Taste and adjust seasoning. Serve hot, garnished with fresh chives and a dash of smoked paprika."
            ]
        }
    ];

    /// <summary>
    /// GET /api/recipes — returns all recipes (summary only, no method/ingredients).
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var summaries = Recipes.Select(r => new
        {
            r.Slug,
            r.Title,
            r.Category,
            r.Time,
            r.Difficulty,
            r.Servings,
            r.Image,
            r.Description
        });
        return Ok(summaries);
    }

    /// <summary>
    /// GET /api/recipes/{slug} — returns full recipe detail.
    /// </summary>
    [HttpGet("{slug}")]
    public IActionResult GetBySlug(string slug)
    {
        var recipe = Recipes.FirstOrDefault(r => r.Slug == slug);
        return recipe is not null ? Ok(recipe) : NotFound();
    }
}
