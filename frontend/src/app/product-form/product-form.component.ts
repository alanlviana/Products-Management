import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../models/product';
import { ProductService } from '../api/product.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {

  productId: string = '';
  product: Product = new Product();
  errors: any = [];

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private router: Router
    ) { }

  ngOnInit() {
    this.route.params.subscribe(async params =>  {
      this.productId = params['id'];
      if (this.productId){
        this.product = await this.productService.getById(this.productId).toPromise();
      }
   });
  }

  async save(){
    if(this.isNewProduct()){
      this.insertProduct();
    }else{
      this.updateProduct();
    }
  }

  private isNewProduct() {
    return !this.product.id;
  }

  insertProduct(){
    this.productService.insert(this.product).subscribe(
      () => this.navigateToProductsList(),
      error => this.handleError(error)
    );
  }

  updateProduct(){
    this.productService.update(this.product).subscribe(
      () => this.navigateToProductsList(),
      error => this.handleError(error)
    );
  }

  handleError(error: any) {
    console.log(error);
    this.errors = error.error?.errors;
  }

  cancel(){
    this.navigateToProductsList();
  }

  navigateToProductsList() {
    this.router.navigate(['products']);
  }

}
