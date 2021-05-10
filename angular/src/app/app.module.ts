import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule, MatCardModule, MatDialogModule, MatDialogRef, MatFormFieldModule, MatIconModule, MatInputModule, MatTableModule, MAT_DIALOG_DATA } from '@angular/material';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { ProductsComponent } from './pages/products/products.component';
import { CartComponent } from './pages/cart/cart/cart.component';
import { DialogConfirmationComponent } from './components/dialog-confirmation/dialog-confirmation/dialog-confirmation.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ProductsComponent,
    CartComponent,
    DialogConfirmationComponent
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
    MatDialogModule,
    RouterModule.forRoot([
      { path: '', component: ProductsComponent, pathMatch: 'full' },
      { path: 'products', component: ProductsComponent },
      { path: 'cart', component: CartComponent },
    ])
  ],
  providers: [
    { provide: MAT_DIALOG_DATA, useValue: {} },
    { provide: MatDialogRef, useValue: {} }
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    DialogConfirmationComponent
  ]
})
export class AppModule { }
