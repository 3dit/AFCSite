import { Component } from '@angular/core';
import { SidebarComponent } from '../../components/sidebar/sidebar';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [SidebarComponent],
  templateUrl: './contact.html',
  styleUrl: './contact.css'
})
export class ContactComponent {}
