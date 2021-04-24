import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  apiUrl:string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAll(){
    return this.http.get<Product[]>(`${this.apiUrl}/products`);
  }

  getById(id: string){
    return this.http.get<Product>(`${this.apiUrl}/products/${id}`);
  }

  insert(product: Product){
    return this.http.post(`${this.apiUrl}/products/`, product);
  }

  update(product: Product){
    return this.http.put(`${this.apiUrl}/products/${product.id}`, product);
  }

  delete(id: string){
    return this.http.delete(`${this.apiUrl}/products/${id}`);
  }
}