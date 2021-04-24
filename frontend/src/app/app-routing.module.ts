import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth-guard';
import { ProductFormComponent } from './product-form/product-form.component';
import { ProductsListComponent } from './products-list/products-list.component';

const routes: Routes = [
  { path: '', pathMatch:'full', redirectTo: 'products' },
  { 
    path: 'products',
    component: ProductsListComponent,
    canActivate: [AuthGuard] 
  },
  { 
    path: 'products/:id/edit',
    component: ProductFormComponent,
    canActivate: [AuthGuard] 
  },
  { 
    path: 'products/new',
    component: ProductFormComponent,
    canActivate: [AuthGuard] 
  },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
