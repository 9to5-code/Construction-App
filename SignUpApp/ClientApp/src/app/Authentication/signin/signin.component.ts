import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Globalcurrentuser } from 'src/app/global/global-current-user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.css'
})


export class SigninComponent implements OnInit   {
  signInForm:any;
  ngOnInit(){

 }
   constructor(private fb: FormBuilder,private auth:UserService,private router:Router) {
     this.signInForm = this.fb.group({
      username:['', Validators.required],
      password:['',Validators.required]
     });
     console.log("formData",this.signInForm.value);

   }

   login(){

     console.log("formData",this.signInForm.value);
      this.auth.login(this.signInForm.value).subscribe(a =>{
       Globalcurrentuser.accessToken=a.token;
       console.log("data",a.token)
       this.router.navigateByUrl('Sidebar')

      });

}
}
