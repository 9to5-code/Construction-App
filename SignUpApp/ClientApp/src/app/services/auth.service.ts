import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private api :ApiService) { }

  get():Observable<any>{
    return this.api.getData("user");
  }

  create(input:any):Observable<any>{
    return this.api.postData("user",input);
  }

}
