import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar';
import { TipService } from '../../services/tip.service';
import { GuideSummary } from '../../models/guide';

@Component({
  selector: 'app-tips',
  standalone: true,
  imports: [RouterLink, SidebarComponent],
  templateUrl: './tips.html',
  styleUrl: './tips.css'
})
export class TipsComponent implements OnInit {
  guides = signal<GuideSummary[]>([]);

  private tipService = inject(TipService);

  ngOnInit() {
    this.tipService.getAll().subscribe(guides => this.guides.set(guides));
  }
}
