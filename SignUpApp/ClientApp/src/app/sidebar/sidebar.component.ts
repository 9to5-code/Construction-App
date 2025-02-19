import { Component } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  standalone: false,
  imports: [],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {
  isHidden = false;

  toggleSidebar() {
    this.isHidden = !this.isHidden;
    const sidebar = document.querySelector('.sidebar');
    const content = document.querySelector('.content');

    if (this.isHidden) {
      sidebar?.classList.add('hidden');
      content?.classList.add('full');
    } else {
      sidebar?.classList.remove('hidden');
      content?.classList.remove('full');
    }
  }
}
