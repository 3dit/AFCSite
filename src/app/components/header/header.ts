import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './header.html',
  styleUrl: './header.css'
})
export class HeaderComponent {
  navOpen = false;

  navItems = [
    {
      label: 'Recipes',
      link: '/recipes',
      children: [
        { label: 'Dairy-Free', link: '/recipes', fragment: 'dairy-free' },
        { label: 'Gluten-Free', link: '/recipes', fragment: 'gluten-free' },
        { label: 'Nut-Free', link: '/recipes', fragment: 'nut-free' },
        { label: 'Soy-Free', link: '/recipes', fragment: 'soy-free' },
        { label: 'Egg-Free', link: '/recipes', fragment: 'egg-free' },
      ]
    },
    {
      label: 'Tips & Guides',
      link: '/tips',
      children: [
        { label: 'Substitution Guide', link: '/tips', fragment: 'substitutions' },
        { label: 'Reading Labels', link: '/tips', fragment: 'labels' },
        { label: 'Kitchen Safety', link: '/tips', fragment: 'safety' },
      ]
    },
    {
      label: 'Meal Planning',
      link: '/meal-planning',
      children: []
    },
    {
      label: 'About',
      link: '/about',
      children: []
    },
    {
      label: 'Contact',
      link: '/contact',
      children: []
    },
    {
      label: 'Legacy',
      link: '/legacy',
      children: []
    }
  ];

  toggleNav() {
    this.navOpen = !this.navOpen;
  }
}
