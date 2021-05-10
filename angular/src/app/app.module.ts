import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule, MatCardModule, MatFormFieldModule, MatIconModule, MatInputModule, MatTableModule } from '@angular/material';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { ProductsComponent } from './pages/products/products.component';
import { CartComponent } from './pages/cart/cart/cart.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ProductsComponent,
    CartComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatIconModule,
    MatTableModule,
    RouterModule.forRoot([
      { path: '', component: ProductsComponent, pathMatch: 'full' },
      { path: 'products', component: ProductsComponent },
      { path: 'cart', component: CartComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
