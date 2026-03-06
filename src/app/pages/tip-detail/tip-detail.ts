import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild, ElementRef, PLATFORM_ID, inject, signal } from '@angular/core';
import { Location, isPlatformBrowser } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar';
import { TipService } from '../../services/tip.service';
import { Guide } from '../../models/guide';

@Component({
  selector: 'app-tip-detail',
  standalone: true,
  imports: [RouterLink, SidebarComponent],
  templateUrl: './tip-detail.html',
  styleUrl: './tip-detail.css'
})
export class TipDetailComponent implements OnInit, AfterViewInit, OnDestroy {
  guide = signal<Guide | null>(null);
  titleStuck = signal(false);

  @ViewChild('guideHeader') guideHeader!: ElementRef;
  private observer!: IntersectionObserver;
  private platformId = inject(PLATFORM_ID);
  private tipService = inject(TipService);

  constructor(private route: ActivatedRoute, private location: Location) {}

  goBack() {
    this.location.back();
  }

  ngOnInit() {
    const slug = this.route.snapshot.paramMap.get('slug');
    if (slug) {
      this.tipService.getBySlug(slug).subscribe(guide => this.guide.set(guide));
    }
  }

  ngAfterViewInit() {
    if (isPlatformBrowser(this.platformId) && this.guideHeader) {
      this.observer = new IntersectionObserver(
        ([entry]) => { this.titleStuck.set(!entry.isIntersecting); },
        { threshold: 0 }
      );
      this.observer.observe(this.guideHeader.nativeElement);
    }
  }

  ngOnDestroy() {
    this.observer?.disconnect();
  }
}
