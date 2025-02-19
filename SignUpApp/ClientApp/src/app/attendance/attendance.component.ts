import { Component } from '@angular/core';

@Component({
  selector: 'app-attendance',
  standalone: false,
  imports: [],
  templateUrl: './attendance.component.html',
  styleUrl: './attendance.component.css'
})
export class AttendanceComponent {
  users = [
    { id: 1, first: 'Mark', last: 'Otto', handle: '@mdo' },
    { id: 2, first: 'Jacob', last: 'Thornton', handle: '@fat' },
    { id: 3, first: 'Larry the Bird', last: '', handle: '@twitter' }
  ];

  user = Array.from({ length: 50 }, (_, i) => ({
    id: i + 1,
    name: `User ${i + 1}`
  })); // Mock 50 users

  page = 1; // Current page
  pageSize = 10;
}
