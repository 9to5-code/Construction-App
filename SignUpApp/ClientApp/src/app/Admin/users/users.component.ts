import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-users',
  standalone: false,
  imports: [CommonModule],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent {

  items = [
    { id: 1, description: 'Description for item 1' },
    { id: 2, description: 'Description for item 2' }

  ];


}
