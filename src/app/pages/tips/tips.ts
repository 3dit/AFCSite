import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar';

@Component({
  selector: 'app-tips',
  standalone: true,
  imports: [RouterLink, SidebarComponent],
  templateUrl: './tips.html',
  styleUrl: './tips.css'
})
export class TipsComponent {
  guides = [
    {
      title: 'The Ultimate Allergen Substitution Guide',
      excerpt: 'A comprehensive reference for replacing common allergens in any recipe without sacrificing taste or texture.',
      category: 'Substitutions',
      readTime: '12 min read'
    },
    {
      title: 'How to Read Food Labels Like a Pro',
      excerpt: 'Learn to decode ingredient lists, understand advisory labels, and spot hidden allergens in packaged foods.',
      category: 'Labels',
      readTime: '8 min read'
    },
    {
      title: 'Setting Up an Allergy-Safe Kitchen',
      excerpt: 'Step-by-step guide to organizing your kitchen to prevent cross-contamination and keep everyone safe.',
      category: 'Safety',
      readTime: '10 min read'
    },
    {
      title: 'Dining Out with Food Allergies',
      excerpt: 'Tips for navigating restaurant menus, communicating with staff, and enjoying meals away from home.',
      category: 'Lifestyle',
      readTime: '7 min read'
    },
    {
      title: 'Baking Without Eggs: Techniques That Work',
      excerpt: 'From flax eggs to aquafaba, master the science behind egg-free baking for perfect results every time.',
      category: 'Substitutions',
      readTime: '9 min read'
    },
    {
      title: 'Allergen-Free Cooking for Kids',
      excerpt: 'Getting children involved in the kitchen while teaching them about food safety and allergy awareness.',
      category: 'Lifestyle',
      readTime: '6 min read'
    },
  ];
}
