import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css'
})
export class SidebarComponent {
  popularRecipes = [
    { title: 'Classic Gluten-Free Banana Bread', link: '/recipes/classic-gluten-free-banana-bread' },
    { title: 'Dairy-Free Creamy Tomato Soup', link: '/recipes/dairy-free-creamy-tomato-soup' },
    { title: 'Nut-Free Pesto Pasta', link: '/recipes/nut-free-pesto-pasta' },
    { title: 'Egg-Free Chocolate Cake', link: '/recipes/egg-free-chocolate-cake' },
    { title: 'Soy-Free Teriyaki Chicken', link: '/recipes/soy-free-teriyaki-chicken' },
  ];

  categories = [
    { label: 'Dairy-Free', count: 42 },
    { label: 'Gluten-Free', count: 38 },
    { label: 'Nut-Free', count: 31 },
    { label: 'Soy-Free', count: 24 },
    { label: 'Egg-Free', count: 19 },
    { label: 'Top-8 Free', count: 15 },
  ];

  quickLinks = [
    { label: 'Substitution Chart', link: '/tips' },
    { label: 'Meal Planning Templates', link: '/meal-planning' },
    { label: 'Emergency Allergy Guide', link: '/tips' },
    { label: 'Safe Brands Directory', link: '/tips' },
    { label: 'Newsletter Signup', link: '/contact' },
  ];
}
