import { Component, OnInit } from '@angular/core';
import { CheckoutService } from 'src/app/services/checkout-service/checkout.service';
import { ICheckoutInput } from 'src/app/services/checkout-service/contracts/icheckout-input';
import { ICheckoutViewModel, IShoppingCartItemViewModel } from 'src/app/services/checkout-service/contracts/icheckout-view-model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  displayedColumns: string[] = ['product', 'quantity', 'price', 'total', 'promotion', 'actions'];
  total: number;
  public dataSource: IShoppingCartItemViewModel[];

  constructor(private _checkoutService: CheckoutService) { }

  ngOnInit() {
    this.getDataCheckout();
  }

  getDataCheckout() {
    this._checkoutService.getCheckout().subscribe(
      (x: ICheckoutViewModel) => {
        this.dataSource = x.products;
        this.total = x.total;
      },
      (e:any) => {
        console.log(`error to get data checkout.`)
      }
    )
  }

  addCartItem(e: any, cartItem: IShoppingCartItemViewModel) {
    const input: ICheckoutInput = {
      product: {
        id: cartItem.product.id,
        name: cartItem.product.name,
        price: cartItem.product.price
      },
      quantity: (+e.target.value <= 0) ? 1 : +e.target.value
    }
    this._checkoutService.addItem(input).subscribe(
      (x: ICheckoutViewModel) => {
        this.dataSource = x.products;
        this.total = x.total;
      },
      (e:any) => {
        console.log(`error to get data checkout.`)
      }
    )
  }

  removeCartItem(productId: number) {
    this._checkoutService.removeItem(productId).subscribe(
      (x: ICheckoutViewModel) => {
        this.dataSource = x.products;
        this.total = x.total;
      },
      (e:any) => {
        console.log(`error to get data checkout.`)
      }
    )
  }

}
