import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';

@Component({
  selector: 'app-edit-user',
  standalone: true,
  imports: [MatButtonModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent],
  templateUrl: './edit-user.component.html',
  styleUrl: './edit-user.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EditUserComponent {
  readonly dialogRef = inject(MatDialogRef<EditUserComponent>);


}
