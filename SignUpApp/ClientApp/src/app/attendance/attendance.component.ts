import { ChangeDetectionStrategy, Component, OnInit, inject } from '@angular/core';
import { FormControl } from '@angular/forms';

import { PeriodicElement, User } from '../models/user';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { UserService } from '../services/user.service';
import { Observable, map, startWith } from 'rxjs';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule} from '@angular/material/dialog';
import { EditUserComponent } from '../Admin/users/edit-user/edit-user.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';

@Component({
  selector: 'app-attendance',
  standalone: false,
 imports: [ MatButtonModule, MatFormFieldModule,
  MatAutocompleteModule,
  MatTableModule,
  MatIconModule,
  MatMenuModule,
  MatDialogModule,
  MatButtonModule,
  MatButtonModule],
  templateUrl: './attendance.component.html',
  styleUrl: './attendance.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,

})
export class AttendanceComponent implements OnInit {
  readonly dialog = inject(MatDialog);
public user:User[]  = [];
  displayedColumns: string[] = ['id', 'name', 'emailId','actions'];
  dataSource = new MatTableDataSource<User>([]);
constructor(public UserService: UserService) { }
myControl = new FormControl('');
  options: string[] = [];
  filteredOptions!: Observable<string[]>;

  ngOnInit(){
     this.UserService.get().subscribe((data) => {

      this.user =data;
      this.options = this.user.map(x=>x.name);
      console.log(this.user);
      this.dataSource.data =this.user;
  })
  this.filteredOptions = this.myControl.valueChanges.pipe(
    startWith(''),
    map(value => this._filter(value || ''))
  );


}
private _filter(value: string): string[] {
  const filterValue = value.toLowerCase();
  return this.options.filter(option => option.toLowerCase().includes(filterValue));
}


editUser(enterAnimationDuration: string, exitAnimationDuration: string){
  this.dialog.open(EditUserComponent, {
    width: '250px',
    enterAnimationDuration,
    exitAnimationDuration,
  });
}



}


// deleteUser(user:User){

// }
const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];
