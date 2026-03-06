import { RenderMode, ServerRoute } from '@angular/ssr';

const API_BASE = 'http://localhost:5000/api';

async function fetchSlugs(endpoint: string): Promise<{ slug: string }[]> {
  try {
    const res = await fetch(`${API_BASE}/${endpoint}`);
    const items: { slug: string }[] = await res.json();
    return items.map(i => ({ slug: i.slug }));
  } catch {
    return [];
  }
}

export const serverRoutes: ServerRoute[] = [
  // Static pages — prerendered at build time
  { path: '', renderMode: RenderMode.Prerender },
  { path: 'recipes', renderMode: RenderMode.Client },
  { path: 'tips', renderMode: RenderMode.Client },
  { path: 'meal-planning', renderMode: RenderMode.Prerender },
  { path: 'about', renderMode: RenderMode.Prerender },
  { path: 'contact', renderMode: RenderMode.Prerender },

  // Parameterised detail pages — slugs fetched from the API at build time
  {
    path: 'recipes/:slug',
    renderMode: RenderMode.Prerender,
    async getPrerenderParams() {
      return fetchSlugs('recipes');
    },
  },
  {
    path: 'tips/:slug',
    renderMode: RenderMode.Prerender,
    async getPrerenderParams() {
      return fetchSlugs('tips');
    },
  },

  // Everything else renders client-side
  { path: '**', renderMode: RenderMode.Client },
];
