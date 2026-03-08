export interface LegacyRecipe {
  id: number;
  name: string;
  excerpt: string | null;
  image: string;
}

export interface BlogPost {
  id: number;
  name: string;
  excerpt: string | null;
  image: string;
  postDate: string;
  category: string | null;
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
