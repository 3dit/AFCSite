import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar';

@Component({
  selector: 'app-recipes',
  standalone: true,
  imports: [RouterLink, SidebarComponent],
  templateUrl: './recipes.html',
  styleUrl: './recipes.css'
})
export class RecipesComponent {
  filters = ['All', 'Dairy-Free', 'Gluten-Free', 'Nut-Free', 'Soy-Free', 'Egg-Free', 'Top-8 Free'];
  activeFilter = 'All';

  recipes = [
    { title: 'Classic Gluten-Free Banana Bread', category: 'Gluten-Free', time: '55 min', difficulty: 'Easy', excerpt: 'Moist, flavorful banana bread using our signature gluten-free flour blend.' },
    { title: 'Dairy-Free Creamy Tomato Soup', category: 'Dairy-Free', time: '30 min', difficulty: 'Easy', excerpt: 'Rich and velvety tomato soup made with cashew cream for incredible depth of flavor.' },
    { title: 'Nut-Free Pesto Pasta', category: 'Nut-Free', time: '20 min', difficulty: 'Easy', excerpt: 'A vibrant pesto using sunflower seeds instead of pine nuts, tossed with your favorite pasta.' },
    { title: 'Egg-Free Chocolate Cake', category: 'Egg-Free', time: '45 min', difficulty: 'Medium', excerpt: 'A decadent chocolate cake that uses aquafaba for lift and moisture.' },
    { title: 'Soy-Free Teriyaki Chicken', category: 'Soy-Free', time: '35 min', difficulty: 'Easy', excerpt: 'Sweet and savory teriyaki made with coconut aminos instead of soy sauce.' },
    { title: 'Top-8 Free Veggie Burger', category: 'Top-8 Free', time: '40 min', difficulty: 'Medium', excerpt: 'A hearty veggie burger free from all top-8 allergens, packed with flavor.' },
    { title: 'Gluten-Free Pizza Dough', category: 'Gluten-Free', time: '90 min', difficulty: 'Medium', excerpt: 'Crispy, chewy pizza dough that folds and stretches like the real thing.' },
    { title: 'Dairy-Free Mac & Cheese', category: 'Dairy-Free', time: '25 min', difficulty: 'Easy', excerpt: 'Ultra-creamy mac and cheese made from sweet potatoes and nutritional yeast.' },
  ];

  setFilter(filter: string) {
    this.activeFilter = filter;
  }

  get filteredRecipes() {
    if (this.activeFilter === 'All') return this.recipes;
    return this.recipes.filter(r => r.category === this.activeFilter);
  }
}
