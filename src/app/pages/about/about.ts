import { Component } from '@angular/core';
import { SidebarComponent } from '../../components/sidebar/sidebar';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [SidebarComponent],
  templateUrl: './about.html',
  styleUrl: './about.css'
})
export class AboutComponent {}
