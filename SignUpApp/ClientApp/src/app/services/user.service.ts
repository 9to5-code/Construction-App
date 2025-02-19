import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private api :ApiService) { }

  get():Observable<any>{
    return this.api.getData("user");
  }

  create(input:any):Observable<any>{
    return this.api.postData("user",input);
  }
  

  login(input:any):Observable<any>{
    return this.api.postData("Auth/login",input);
  }
}
