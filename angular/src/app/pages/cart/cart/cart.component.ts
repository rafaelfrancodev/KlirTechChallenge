import { Component, OnInit } from '@angular/core';
import { CheckoutService } from 'src/app/services/checkout-service/checkout.service';
import { ICheckoutViewModel, IShoppingCartItemViewModel } from 'src/app/services/checkout-service/contracts/icheckout-view-model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  displayedColumns: string[] = ['product', 'quantity', 'price', 'total', 'promotion'];
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

}
