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
      slug: 'ultimate-allergen-substitution-guide',
      title: 'The Ultimate Allergen Substitution Guide',
      excerpt: 'A comprehensive reference for replacing common allergens in any recipe without sacrificing taste or texture.',
      category: 'Substitutions',
      readTime: '12 min read',
      image: 'images/ultimate_guide_on_table.png'
    },
    {
      slug: 'how-to-read-food-labels',
      title: 'How to Read Food Labels Like a Pro',
      excerpt: 'Learn to decode ingredient lists, understand advisory labels, and spot hidden allergens in packaged foods.',
      category: 'Labels',
      readTime: '8 min read',
      image: 'images/How_to_Read_Food_Labels_Like_a_Pro.png'
    },
    {
      slug: 'setting-up-an-allergy-safe-kitchen',
      title: 'Setting Up an Allergy-Safe Kitchen',
      excerpt: 'Step-by-step guide to organizing your kitchen to prevent cross-contamination and keep everyone safe.',
      category: 'Safety',
      readTime: '10 min read',
      image: 'images/Setting_Up_an_Allergy_Safe_Kitchen.png'
    },
    {
      slug: 'dining-out-with-food-allergies',
      title: 'Dining Out with Food Allergies',
      excerpt: 'Tips for navigating restaurant menus, communicating with staff, and enjoying meals away from home.',
      category: 'Lifestyle',
      readTime: '7 min read',
      image: 'images/Setting_Up_an_Allergy-Safe_Kitchen.png'
    },
    {
      slug: 'baking-without-eggs',
      title: 'Baking Without Eggs: Techniques That Work',
      excerpt: 'From flax eggs to aquafaba, master the science behind egg-free baking for perfect results every time.',
      category: 'Substitutions',
      readTime: '9 min read',
      image: 'images/Baking_Without_Eggs_Techniques_That_Work.png'
    },
    {
      slug: 'allergen-free-cooking-for-kids',
      title: 'Allergen-Free Cooking for Kids',
      excerpt: 'Getting children involved in the kitchen while teaching them about food safety and allergy awareness.',
      category: 'Lifestyle',
      readTime: '6 min read',
      image: 'images/Allergen-Free Cooking for Kids.png'
    },
  ];
}
