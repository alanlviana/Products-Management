import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../models/product';
import { ProductService } from '../api/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  products: Product[] = [];

  constructor(private productService: ProductService, private router: Router) { }

  async ngOnInit() {
    await this.loadProducts();
  }

  loadProducts() {
    this.productService.getAll().subscribe(
      (products) => {
        this.products = products;
      },
      (error) => this.errorHandler(error)
    )
  }
  errorHandler(error: any): void {
    console.log(error);
  }

  editProduct(id: string){
    this.router.navigate([`products/${id}/edit`])
  }

  createProduct(){
    this.router.navigate([`products/new`])
  }

  async deleteProduct(id: string){
    if (window.confirm("Are you sure you want to delete this product?")){
      await this.productService.delete(id).toPromise();
      this.loadProducts();
    }
  }

  numberToCurrencyFormat(value: any){
    return new Intl.NumberFormat('en-US',{ style: 'currency', currency: 'USD' }).format(value) 
  }
  
}
