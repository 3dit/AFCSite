export interface Recipe {
  slug: string;
  title: string;
  category: string;
  time: string;
  difficulty: string;
  servings: string;
  image: string;
  description: string;
  ingredients: string[];
  method: string[];
}

export type RecipeSummary = Pick<Recipe, 'slug' | 'title' | 'category' | 'time' | 'difficulty' | 'servings' | 'image' | 'description'>;
