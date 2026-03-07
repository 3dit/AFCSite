export interface LegacyRecipe {
  id: number;
  name: string;
  excerpt: string | null;
  image: string;
}

export interface LegacyRecipeDetail {
  id: number;
  name: string;
  image: string;
  excerpt: string | null;
  ingredients: string[];
  method: string[];
  notes: string | null;
}
