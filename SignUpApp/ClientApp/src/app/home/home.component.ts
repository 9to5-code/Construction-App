import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { debounce } from 'rxjs';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {

  signIn:boolean=true;
  form: any;


  ngOnInit(){
    this.signIn = false;
  }
  constructor(private fb: FormBuilder,private user:UserService, private router: Router) {
    this.form = this.fb.group({
      id: [0, Validators.required],
      name: ['', [Validators.required, Validators.email]],
      emailId: ['', [Validators.required, Validators.minLength(6)]],
      password:['',[Validators.required]]
    });
  }
  onSubmit(){
    
    console.log("formData",this.form.value);

    this.user.create(this.form.value).subscribe(result =>{
      console.log("result", result);
      this.router.navigateByUrl("/SignIn")
    })

  }


}


