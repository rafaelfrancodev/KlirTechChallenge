import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Router } from '@angular/router';
import { DialogConfirmationComponent } from 'src/app/components/dialog-confirmation/dialog-confirmation/dialog-confirmation.component';
import { CheckoutService } from 'src/app/services/checkout-service/checkout.service';
import { ICheckoutInput } from 'src/app/services/checkout-service/contracts/icheckout-input';
import { ICheckoutViewModel } from 'src/app/services/checkout-service/contracts/icheckout-view-model';
import { IProductViewModel, IProductWithPromotionViewModel } from 'src/app/services/products-service/contracts/iproduct-with-promotio-view-model';
import { ProductService } from 'src/app/services/products-service/product.service';

export interface IQuantityProducts {
  qty: number;
  productId: number;
}
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  products: Array<IProductWithPromotionViewModel> = new Array<IProductWithPromotionViewModel>();
  confirmationDialog: MatDialogRef<DialogConfirmationComponent>;
  quantity: Array<IQuantityProducts> = new Array<IQuantityProducts>();

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<ProductsComponent>,
    private _productService: ProductService,
    private _checkoutService: CheckoutService,
    private _dialog: MatDialog,
    private _router: Router) { }

  ngOnInit() {
    this.getProductsWithPromotion();
  }

  getProductsWithPromotion() {
    this._productService.getProductsWithPromotion().subscribe(
      (x: IProductWithPromotionViewModel[]) => {
        this.products = x;
        console.log(this.products);
      },
      (e: any) => {
        console.log("Error to get products with promotion");
        this.products = [];
      }
    )
  }

  changeQuantityProduct(e: any, product: IProductViewModel) {
    const quantityByProduct: IQuantityProducts = {
      qty: (+e.target.value <= 0) ? 1 : +e.target.value,
      productId: product.id
    }
    let searchQuantityByProduct = this.quantity.find(x => x.productId === product.id);
    if (!searchQuantityByProduct) {
      this.quantity.push(quantityByProduct)
    } else {
      searchQuantityByProduct.productId = quantityByProduct.productId;
      searchQuantityByProduct.qty = quantityByProduct.qty;
    }
  }

  addCartItem(cartItem: IProductViewModel) {

    if (this.confirmationDialog instanceof MatDialogRef) {
      this.confirmationDialog.close();
    }

    this.confirmationDialog = this._dialog.open(DialogConfirmationComponent, {
      panelClass: 'panelClass',
      width: '500px',
      data: {
        title: 'Go to checkout',
        mensagem: 'Do you want to go to checkout? '
      }
    });

    let searchQuantityByProduct = this.quantity.find(x => x.productId === cartItem.id);

    const quantityByProduct: IQuantityProducts = {
      qty: 1,
      productId: cartItem.id
    }

    if (!searchQuantityByProduct) {
      this.quantity.push(quantityByProduct)
    } else {
      quantityByProduct.qty = searchQuantityByProduct.qty;
    }

    const input: ICheckoutInput = {
      product: {
        id: cartItem.id,
        name: cartItem.name,
        price: cartItem.price
      },
      quantity: quantityByProduct.qty
    }
    this._checkoutService.addItem(input).subscribe(
      (x: ICheckoutViewModel) => {

      },
      (e: any) => {
        console.log(`error to get data checkout.`)
      }
    );


    this.confirmationDialog.afterClosed().subscribe((response: any) => {
      if (typeof response != 'undefined' && response === true) {
        this._router.navigateByUrl('/cart');
      }
    });
  }
}
