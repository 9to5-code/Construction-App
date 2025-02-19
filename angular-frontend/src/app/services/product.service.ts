import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../Model/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'http://localhost:5140/api/Product'; 

  constructor(private http: HttpClient) { }


  getProduct(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl);
  }



}
