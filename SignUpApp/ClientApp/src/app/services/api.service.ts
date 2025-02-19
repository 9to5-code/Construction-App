import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Globalcurrentuser } from '../global/global-current-user';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiUrl :string = environment.appUrl;
 //  accessToken = Globalcurrentuser.accessToken;
   get accessToken(): any {

    const token = localStorage.getItem("accesstoken");
     console.log("get",token);
    return token;
  }
 
  // private httpOptions = {
   
  //   headers: new HttpHeaders({
     
  //    'Authorization':`Bearer ${this.accessToken}`
  //   }),
    
  // };
  
  constructor(private http: HttpClient) { }

  getData(url:string): Observable < any > {
    return this.http.get(`${this.apiUrl}/${url}`);
}
postData(url:string,payload: any): Observable < any > {
  console.log("url",url);
  console.log("payload",payload);
  console.log("global",this.accessToken);
  return this.http.post(`${this.apiUrl}/${url}`, payload);
} 
updateData(id: number, payload: any): Observable < any > {
  return this.http.put(`${this.apiUrl}/${id}`, payload);
} 
deleteData(id: number): Observable < any > {
  return this.http.delete(`${this.apiUrl}/${id}`);
} 
}
