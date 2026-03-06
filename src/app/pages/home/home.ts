import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink, SidebarComponent],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class HomeComponent {
  featuredRecipe = {
    title: 'Spring Vegetable Risotto: Completely Dairy-Free',
    description: 'A creamy, satisfying risotto made with coconut cream and nutritional yeast that rivals any traditional version.',
    category: 'Dairy-Free',
    author: 'Michelle Hill',
    date: 'March 5, 2026',
    image: ''
  };

  latestArticles = [
    {
      title: 'The Complete Guide to Gluten-Free Flour Blends',
      excerpt: 'Master the art of gluten-free baking with our comprehensive guide to flour blends and ratios.',
      category: 'Gluten-Free',
      date: 'March 4, 2026',
      image: ''
    },
    {
      title: '15-Minute Nut-Free School Lunches',
      excerpt: 'Quick, delicious, and safe lunch ideas that kids will actually want to eat.',
      category: 'Nut-Free',
      date: 'March 3, 2026',
      image: ''
    },
    {
      title: 'Understanding Cross-Contamination in Your Kitchen',
      excerpt: 'Essential tips for keeping your cooking space safe for family members with severe allergies.',
      category: 'Tips',
      date: 'March 2, 2026',
      image: ''
    },
    {
      title: 'Egg-Free Brunch Ideas for Weekend Entertaining',
      excerpt: 'Impress your guests with these stunning brunch recipes that skip the eggs entirely.',
      category: 'Egg-Free',
      date: 'March 1, 2026',
      image: ''
    },
    {
      title: 'Soy-Free Asian-Inspired Dishes',
      excerpt: 'Enjoy the bold flavors of Asian cuisine with these creative soy-free alternatives.',
      category: 'Soy-Free',
      date: 'Feb 28, 2026',
      image: ''
    },
    {
      title: 'Spring Meal Prep: A Week of Allergen-Free Dinners',
      excerpt: 'Plan ahead with our seasonal meal prep guide featuring top-8 free recipes.',
      category: 'Meal Planning',
      date: 'Feb 27, 2026',
      image: ''
    }
  ];
}
