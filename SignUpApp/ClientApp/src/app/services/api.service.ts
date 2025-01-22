import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiUrl :string ='http://localhost:5079/api';
  constructor(private http: HttpClient) { }

  getData(url:string): Observable < any > {
    return this.http.get(`${this.apiUrl}/${url}`);
}
postData(url:string,payload: any): Observable < any > {
  return this.http.post(`${this.apiUrl}/${url}`, payload);
} 
updateData(id: number, payload: any): Observable < any > {
  return this.http.put(`${this.apiUrl}/${id}`, payload);
} 
deleteData(id: number): Observable < any > {
  return this.http.delete(`${this.apiUrl}/${id}`);
} 
}
