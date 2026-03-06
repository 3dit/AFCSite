import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar';

@Component({
  selector: 'app-meal-planning',
  standalone: true,
  imports: [RouterLink, SidebarComponent],
  templateUrl: './meal-planning.html',
  styleUrl: './meal-planning.css'
})
export class MealPlanningComponent {
  weeklyPlan = [
    { day: 'Monday', meal: 'Soy-Free Teriyaki Chicken with Rice', tags: ['Soy-Free', 'Nut-Free'] },
    { day: 'Tuesday', meal: 'Gluten-Free Pasta Primavera', tags: ['Gluten-Free', 'Egg-Free'] },
    { day: 'Wednesday', meal: 'Dairy-Free Creamy Tomato Soup & Salad', tags: ['Dairy-Free'] },
    { day: 'Thursday', meal: 'Top-8 Free Black Bean Tacos', tags: ['Top-8 Free'] },
    { day: 'Friday', meal: 'Nut-Free Pesto Salmon', tags: ['Nut-Free', 'Dairy-Free'] },
    { day: 'Saturday', meal: 'Egg-Free Veggie Stir Fry', tags: ['Egg-Free', 'Dairy-Free'] },
    { day: 'Sunday', meal: 'Gluten-Free Pizza Night', tags: ['Gluten-Free'] },
  ];
}
