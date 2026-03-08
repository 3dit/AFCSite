import { Component, inject, OnInit, signal } from '@angular/core';
import { DatePipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar';
import { LegacyService } from '../../services/legacy.service';
import { BlogPost } from '../../models/legacy-recipe';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink, SidebarComponent, DatePipe],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class HomeComponent implements OnInit {
  private legacyService = inject(LegacyService);

  featuredPost = signal<BlogPost | null>(null);
  latestPosts = signal<BlogPost[]>([]);

  ngOnInit() {
    this.legacyService.getBlogPosts().subscribe(posts => {
      if (posts.length > 0) {
        this.featuredPost.set(posts[0]);
        this.latestPosts.set(posts.slice(1));
      }
    });
  }
}
