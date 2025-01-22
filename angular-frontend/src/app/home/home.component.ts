import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Product } from '../Model/product';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  products:any;
  constructor(private product: ProductService){
    }
    ngOnInit(): void {
      this.loadProjects();
    }
  
    loadProjects(): void {
      this.product.getProduct().subscribe((data: Product[]) => {
        this.products = data;
      });
    }

}
