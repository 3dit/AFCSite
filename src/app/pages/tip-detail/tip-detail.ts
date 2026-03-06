import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar';

interface Guide {
  slug: string;
  title: string;
  category: string;
  readTime: string;
  image: string;
  intro: string;
  sections: { heading: string; content: string }[];
}

@Component({
  selector: 'app-tip-detail',
  standalone: true,
  imports: [RouterLink, SidebarComponent],
  templateUrl: './tip-detail.html',
  styleUrl: './tip-detail.css'
})
export class TipDetailComponent implements OnInit, AfterViewInit, OnDestroy {
  guide: Guide | null = null;
  titleStuck = false;

  @ViewChild('guideHeader') guideHeader!: ElementRef;
  private observer!: IntersectionObserver;

  guides: Guide[] = [
    {
      slug: 'ultimate-allergen-substitution-guide',
      title: 'The Ultimate Allergen Substitution Guide',
      category: 'Substitutions',
      readTime: '12 min read',
      image: 'images/ultimate_guide_on_table.png',
      intro: 'Whether you are cooking for someone with a newly diagnosed allergy or adapting a beloved family recipe, finding the right substitution can feel overwhelming. This guide covers every major allergen group with tested, reliable swaps that preserve the taste and texture you expect.',
      sections: [
        {
          heading: 'Dairy Substitutions',
          content: 'For milk, oat milk provides the closest neutral flavor for baking, while full-fat coconut milk works best in savory sauces and curries. When replacing butter, use a vegan butter stick (not spread) for baking — the water content in spreads will throw off your ratios. For cheese, cashew-based cheese melts and stretches best, while nutritional yeast adds a savory, umami-rich flavor to sauces, popcorn, and pasta. Coconut cream, chilled overnight and whipped, makes a convincing stand-in for whipped cream.'
        },
        {
          heading: 'Egg Substitutions',
          content: 'The best egg substitute depends on the role the egg plays in your recipe. For binding (meatballs, veggie burgers), use a flax egg: 1 tablespoon ground flaxseed mixed with 3 tablespoons water, rested 5 minutes. For leavening (cakes, muffins), use 1/4 cup aquafaba (chickpea liquid) whipped until foamy — it traps air just like egg whites. For moisture (brownies, quick breads), 1/4 cup unsweetened applesauce or mashed banana per egg works beautifully. Commercial egg replacers like Bob\'s Red Mill work well as all-purpose options.'
        },
        {
          heading: 'Gluten Substitutions',
          content: 'A reliable gluten-free flour blend is essential. A good ratio is 2 parts rice flour, 2/3 part potato starch, and 1/3 part tapioca starch. Add 1 teaspoon xanthan gum per cup of flour blend to mimic the elasticity gluten provides. For breadcrumbs, crush gluten-free crackers or use almond meal. For thickening sauces, cornstarch or arrowroot powder work identically to wheat flour — use half the amount. Oat flour (certified gluten-free) adds a mild sweetness to baked goods and pancakes.'
        },
        {
          heading: 'Nut Substitutions',
          content: 'Sunflower seed butter is the most versatile nut butter replacement — it behaves almost identically in baking and sauces. For recipes calling for chopped nuts, try toasted sunflower seeds, pumpkin seeds, or toasted coconut flakes for crunch. Tahini (sesame paste) works well in dressings and sauces where you\'d use cashew or almond butter. For nut milks, oat milk and rice milk are safe alternatives. When making pesto, swap pine nuts for roasted sunflower seeds — the flavor is surprisingly close.'
        },
        {
          heading: 'Soy Substitutions',
          content: 'Coconut aminos are the go-to soy sauce replacement. They are slightly sweeter, so reduce any added sugar in your recipe by half. For tofu, chickpea tofu (made from chickpea flour) holds up well in stir-fries and scrambles. Sunflower lecithin can replace soy lecithin in baking. For miso paste, chickpea miso is now widely available and provides a similar fermented depth. In marinades, a combination of coconut aminos, rice vinegar, and a pinch of seaweed flakes replicates the savory complexity of soy-based sauces.'
        },
        {
          heading: 'Tips for Successful Substitutions',
          content: 'Always make one substitution at a time when adapting a recipe — if something goes wrong, you\'ll know exactly what caused it. Keep notes on what works and what doesn\'t. Expect some trial and error: allergen-free baking in particular often requires adjusting liquid ratios or bake times. Taste as you go, and remember that many substitutions improve with practice. Stock your pantry with the basics — a good flour blend, flax meal, coconut aminos, and oat milk — and you\'ll be ready to adapt nearly any recipe on the fly.'
        }
      ]
    },
    {
      slug: 'how-to-read-food-labels',
      title: 'How to Read Food Labels Like a Pro',
      category: 'Labels',
      readTime: '8 min read',
      image: 'images/How_to_Read_Food_Labels_Like_a_Pro.png',
      intro: 'Food labels can be confusing, even misleading. Understanding how to decode ingredient lists, recognize hidden allergens, and interpret advisory statements is one of the most important skills for anyone managing food allergies. This guide walks you through everything you need to know.',
      sections: [
        {
          heading: 'Understanding the Ingredient List',
          content: 'Ingredients are listed in descending order by weight. The first few ingredients make up the bulk of the product. Allergens can appear under scientific or unfamiliar names — casein and whey are dairy, albumin is egg, and hydrolyzed vegetable protein often contains soy. Always read the full list, even for products you\'ve bought before, as manufacturers frequently change formulations without prominent labeling.'
        },
        {
          heading: 'The "Contains" Statement',
          content: 'Under FALCPA (Food Allergen Labeling and Consumer Protection Act), manufacturers must clearly declare the presence of the top 9 allergens (milk, eggs, fish, shellfish, tree nuts, peanuts, wheat, soybeans, and sesame) in a "Contains" statement near the ingredient list. However, this statement is only required for intentionally added allergens, not for cross-contact. Always read both the ingredient list and the Contains statement.'
        },
        {
          heading: 'Advisory Labels: "May Contain" and Shared Facilities',
          content: 'Statements like "may contain traces of" or "manufactured in a facility that also processes" are voluntary — there is no regulation governing their use. Some companies use them liberally out of caution, while others with significant cross-contact risk may not include them at all. For severe allergies, contact the manufacturer directly to ask about their allergen control procedures and cleaning protocols between production runs.'
        },
        {
          heading: 'Hidden Allergens to Watch For',
          content: 'Dairy hides in unexpected places: "natural flavors" can contain dairy derivatives, caramel color may use lactose as a carrier, and many medications use lactose as a filler. Wheat appears in modified food starch (unless specified as corn), soy sauce, and many seasoning blends. Soy lecithin is in nearly every chocolate bar. Tree nuts show up in cereals, granola bars, and ice cream as mix-ins. Always check condiments, sauces, and spice blends — they are among the most common sources of hidden allergens.'
        },
        {
          heading: 'Certified Labels You Can Trust',
          content: 'Look for third-party certifications for added confidence. The Gluten-Free Certification Organization (GFCO) logo means the product tests below 10 ppm gluten. Kosher Pareve certification means no dairy or meat ingredients (though it does not address other allergens). Vegan certifications indicate no animal products but do not address nuts, soy, or gluten. FARE (Food Allergy Research & Education) provides a list of companies with strong allergen control programs. No single label covers everything — use certifications as one tool alongside your own ingredient reading.'
        },
        {
          heading: 'Building a Safe Shopping Routine',
          content: 'Read labels every single time, even for familiar products. Set up a notes app on your phone with a running list of safe brands and products. When trying a new product, read the label at home where you can focus, not in a crowded store aisle. Bookmark the manufacturer\'s allergen FAQ page. Teach older children to read labels themselves so they can participate in their own safety. Consistency and vigilance are the most powerful tools you have.'
        }
      ]
    },
    {
      slug: 'setting-up-an-allergy-safe-kitchen',
      title: 'Setting Up an Allergy-Safe Kitchen',
      category: 'Safety',
      readTime: '10 min read',
      image: 'images/Setting_Up_an_Allergy_Safe_Kitchen.png',
      intro: 'Cross-contamination is one of the biggest risks in a shared kitchen. Whether you are living in a household where only one person has allergies or running an entirely allergen-free kitchen, proper setup and habits can dramatically reduce the risk of accidental exposure.',
      sections: [
        {
          heading: 'Designate Allergen-Free Zones',
          content: 'If your kitchen serves both allergen-containing and allergen-free foods, designate a specific counter area, cutting board, and set of utensils exclusively for allergen-free cooking. Use color-coded cutting boards — for example, green for allergen-free prep. Store allergen-free ingredients on a separate shelf, ideally above allergen-containing foods so nothing can drip or spill downward. Label shelves clearly so every household member knows the system.'
        },
        {
          heading: 'Separate Tools and Equipment',
          content: 'Porous materials like wooden spoons, wooden cutting boards, and cast iron pans can harbor allergen residue even after washing. Consider keeping separate sets for allergen-free cooking, or switching entirely to non-porous options like stainless steel, silicone, and glass. Toasters are a major source of gluten cross-contact — use a dedicated allergen-free toaster or toaster bags. Colanders, strainers, and sifters with fine mesh are difficult to clean thoroughly and are best kept separate.'
        },
        {
          heading: 'Cleaning Protocols That Work',
          content: 'Soap and water are effective at removing most allergen proteins from hard surfaces — you don\'t need special cleaners. However, you must wash thoroughly with friction, not just a quick rinse. Dishwashers are generally effective for non-porous items. Always wash hands with soap and water (not just hand sanitizer) before handling allergen-free food. Wipe down counters, stovetops, and sink areas before starting allergen-free meal prep. Consider keeping a separate sponge or brush for allergen-free dishwashing.'
        },
        {
          heading: 'Safe Storage Practices',
          content: 'Store all allergen-free foods in sealed, airtight containers clearly labeled with the contents and date. Use a separate shelf or bin in the refrigerator for allergen-free items. Never reuse containers that previously held allergen-containing food unless they are non-porous and have been thoroughly washed. Keep allergen-free flours and baking supplies in their own canisters — a stray cup dipped into the wrong flour bin can cause a reaction. When in doubt, keep it sealed and labeled.'
        },
        {
          heading: 'Cooking Order Matters',
          content: 'Always prepare allergen-free meals first, before cooking with any allergens. This minimizes airborne and surface contamination. If you are making two versions of a dish (one allergen-free and one not), prepare the allergen-free version completely — portioned and covered — before bringing out any allergen-containing ingredients. Use separate pots of boiling water for allergen-free pasta. Never use the same cooking oil for frying allergen-free and allergen-containing foods.'
        },
        {
          heading: 'Creating a Kitchen Emergency Plan',
          content: 'Keep epinephrine auto-injectors (if prescribed) in an accessible, known location in or near the kitchen — not locked away in a medicine cabinet. Make sure every household member knows where they are and how to use them. Post a laminated card with emergency steps and your allergist\'s phone number. If a reaction occurs, administer epinephrine first, then call emergency services. Review your plan with the whole household every few months.'
        }
      ]
    },
    {
      slug: 'dining-out-with-food-allergies',
      title: 'Dining Out with Food Allergies',
      category: 'Lifestyle',
      readTime: '7 min read',
      image: 'images/Setting_Up_an_Allergy-Safe_Kitchen.png',
      intro: 'Eating at restaurants does not have to be stressful. With the right preparation and communication, you can enjoy meals out safely. This guide covers how to choose restaurants, communicate with staff, and handle tricky situations with confidence.',
      sections: [
        {
          heading: 'Choosing the Right Restaurant',
          content: 'Research restaurants online before you go. Look for menus that list allergens or offer a separate allergen menu. Chains often have detailed allergen information on their websites. Smaller, independent restaurants may be more willing to accommodate special requests because they cook from scratch. Avoid buffets and shared-plate restaurants where cross-contact is almost impossible to control. Cuisines that naturally avoid certain allergens can be a good starting point — for example, many Japanese dishes are naturally dairy-free, and many Mexican dishes are naturally nut-free.'
        },
        {
          heading: 'How to Communicate Your Allergies',
          content: 'Call ahead during a non-peak hour and ask to speak with the chef or kitchen manager. Explain your specific allergies clearly and ask what they can safely prepare. When you arrive, inform your server again — do not assume the message was passed along. Use a chef card: a small printed card listing your allergens that the server can hand directly to the kitchen. Be specific — say "I have a milk allergy that can cause anaphylaxis" rather than "I don\'t do dairy," which can sound like a preference rather than a medical need.'
        },
        {
          heading: 'Questions to Ask Your Server',
          content: 'Ask how each dish is prepared, not just what\'s in it. Grilled items may share a grill with buttered dishes. Fryers often cook multiple items in the same oil. Ask whether sauces and dressings are made in-house or from a pre-made product (pre-made products are harder to verify). Ask about marinades — soy sauce is a common marinade ingredient. Ask if the kitchen can use clean cookware and a clean section of the grill for your meal. A good restaurant will take these questions seriously.'
        },
        {
          heading: 'Navigating Social Dining Situations',
          content: 'When dining with a group, suggest the restaurant so you can choose a safe option. If someone else is choosing, look at the menu ahead of time and call the restaurant to plan. Do not feel embarrassed about asking questions at the table — your safety is more important than social awkwardness. If you are at a dinner party, offer to bring a dish you know is safe, and let the host know your allergies in advance. Most people appreciate the heads-up and want to help.'
        },
        {
          heading: 'What to Carry With You',
          content: 'Always carry your epinephrine auto-injector, antihistamines, and your chef card when dining out. Keep a small card in your wallet listing your allergies and emergency contact information. If you are traveling, carry translations of your allergy information in the local language. Consider packing safe snacks in case the restaurant cannot accommodate you — it is better to have a backup than to take a risk on an uncertain meal.'
        }
      ]
    },
    {
      slug: 'baking-without-eggs',
      title: 'Baking Without Eggs: Techniques That Work',
      category: 'Substitutions',
      readTime: '9 min read',
      image: 'images/Baking_Without_Eggs_Techniques_That_Work.png',
      intro: 'Eggs play multiple roles in baking — binding, leavening, adding moisture, and providing structure. The key to successful egg-free baking is understanding which role the egg plays in your recipe and choosing a substitute that fills that specific function.',
      sections: [
        {
          heading: 'Understanding What Eggs Do in Baking',
          content: 'In a cake, eggs primarily provide lift and structure. In cookies, they act as a binder holding fats, sugars, and flour together. In custards and quiches, eggs are the main structural element. In brownies and quick breads, eggs mostly contribute moisture. Before reaching for a substitute, ask yourself: is this egg here for binding, leavening, moisture, or structure? The answer determines which replacement will work best.'
        },
        {
          heading: 'Flax Eggs and Chia Eggs',
          content: 'Mix 1 tablespoon of ground flaxseed or chia seeds with 3 tablespoons of water. Stir and let rest for 5 minutes until a gel forms. This replaces one egg and works best as a binder in cookies, muffins, pancakes, and quick breads. Flax adds a mild nutty flavor, so it works better in whole grain or chocolate recipes. Chia is more neutral in flavor. Neither provides much leavening, so they are not ideal as the sole egg replacement in fluffy cakes.'
        },
        {
          heading: 'Aquafaba: The Secret Weapon',
          content: 'Aquafaba is the liquid from a can of chickpeas, and it is a remarkable egg white substitute. Use 3 tablespoons of aquafaba to replace one whole egg, or 2 tablespoons to replace one egg white. It can be whipped to stiff peaks just like egg whites, making it perfect for meringues, macarons, marshmallow fluff, and angel food cake. Whip it with cream of tartar for extra stability. It also works well folded into cake batters for added lift. Store unused aquafaba in the refrigerator for up to a week, or freeze it in tablespoon portions in an ice cube tray.'
        },
        {
          heading: 'Fruit and Vegetable Purees',
          content: 'Unsweetened applesauce, mashed banana, and pumpkin puree all work as egg replacements when moisture is the primary need. Use 1/4 cup per egg. Applesauce is the most neutral option — banana adds sweetness and flavor (great in banana bread, less ideal in vanilla cake). Pumpkin puree adds moisture and a subtle earthy flavor that works well in spice cakes, muffins, and pancake batters. These purees add density, so they work best in recipes that are already moist and tender rather than light and airy.'
        },
        {
          heading: 'Commercial Egg Replacers',
          content: 'Products like Bob\'s Red Mill Egg Replacer, JUST Egg, and Ener-G Egg Replacer each work differently. Bob\'s Red Mill is a powder blend that works well in most baking recipes. JUST Egg is a liquid made from mung beans — it\'s best for scrambles, quiches, and French toast where you want an egg-like texture. Ener-G is a leavening-focused replacer that works in light cakes and cookies. Follow the package instructions closely, as ratios vary by brand. Keep a couple of options on hand since no single product works perfectly in every recipe.'
        },
        {
          heading: 'Combining Techniques for Best Results',
          content: 'For recipes that call for 2 or more eggs, consider using a combination of substitutes. For example, use a flax egg for binding plus a splash of aquafaba for lift. In a cake recipe calling for 3 eggs, you might use 1/4 cup applesauce for moisture, 1 flax egg for binding, and 3 tablespoons whipped aquafaba for leavening. This multi-pronged approach more closely mimics what eggs do in complex recipes. Keep notes on what combinations work for your favorite recipes — your personal substitution playbook will become your most valuable kitchen resource.'
        }
      ]
    },
    {
      slug: 'allergen-free-cooking-for-kids',
      title: 'Allergen-Free Cooking for Kids',
      category: 'Lifestyle',
      readTime: '6 min read',
      image: 'images/Allergen-Free Cooking for Kids.png',
      intro: 'Getting kids involved in the kitchen builds confidence, teaches them about their allergies, and makes allergen-free eating feel normal rather than restrictive. These strategies make cooking with children safe, fun, and educational.',
      sections: [
        {
          heading: 'Age-Appropriate Kitchen Tasks',
          content: 'Children as young as 3 can help with washing vegetables, tearing lettuce, and stirring cold ingredients. Ages 5–7 can measure dry ingredients, spread soft fillings, and use cookie cutters. Ages 8–10 can follow simple recipes, crack eggs (if safe for them), chop soft foods with a child-safe knife, and operate a stand mixer with supervision. Teens can handle most kitchen tasks independently, including stovetop cooking. Assign tasks that match your child\'s motor skills and attention span — the goal is success, not frustration.'
        },
        {
          heading: 'Teaching Allergen Awareness Early',
          content: 'Start with simple, concrete lessons: "We don\'t eat peanuts because they make your body sick." As children grow, explain the concept of ingredients hiding inside foods. Practice reading labels together at the grocery store — turn it into a game where they spot the allergens. Teach them the phrases to use with adults: "I have a food allergy to X. Can you tell me if this has X in it?" Role-play scenarios like birthday parties and school lunches so they feel prepared. Empower them without frightening them — knowledge is the goal, not fear.'
        },
        {
          heading: 'Recipes Kids Love to Make',
          content: 'Start with no-bake recipes like energy balls (oat flour, sunflower seed butter, honey, and dairy-free chocolate chips), fruit kabobs, or trail mix with safe ingredients. Smoothies are great because kids can choose their own add-ins. For baking, simple cookies and muffins with minimal steps build confidence. Pizza night with allergen-free dough and a topping bar lets kids customize their own meal. The key is choosing recipes with short ingredient lists, minimal wait times, and a result they are excited to eat.'
        },
        {
          heading: 'Making Allergen-Free Food Fun, Not Different',
          content: 'Avoid framing allergen-free food as a lesser version of "normal" food. Instead, present it as the family\'s way of cooking. When the whole family eats the same allergen-free meal, it removes the feeling of being singled out. Let kids name their own recipe creations. Use fun shapes, bright colors, and build-your-own formats (tacos, grain bowls, pizza). Celebrate cooking successes together. When children feel ownership over their food, they are far more likely to eat it enthusiastically.'
        },
        {
          heading: 'Navigating School and Social Situations',
          content: 'Work with your child\'s school to establish a food allergy action plan. Send safe snacks and lunches that your child helped prepare — they will be more excited to eat something they made themselves. For birthday parties, send a cupcake or treat that matches the party food so your child does not feel left out. Talk to other parents in advance and provide a list of safe snack brands. As your child gets older, involve them in these conversations so they learn to advocate for themselves. Practice what to say and do if someone offers them unsafe food.'
        }
      ]
    }
  ];

  constructor(private route: ActivatedRoute, private location: Location) {}

  goBack() {
    this.location.back();
  }

  ngOnInit() {
    const slug = this.route.snapshot.paramMap.get('slug');
    this.guide = this.guides.find(g => g.slug === slug) || null;
  }

  ngAfterViewInit() {
    if (this.guideHeader) {
      this.observer = new IntersectionObserver(
        ([entry]) => { this.titleStuck = !entry.isIntersecting; },
        { threshold: 0 }
      );
      this.observer.observe(this.guideHeader.nativeElement);
    }
  }

  ngOnDestroy() {
    this.observer?.disconnect();
  }
}
