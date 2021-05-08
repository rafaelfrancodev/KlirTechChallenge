import { Component, OnInit } from '@angular/core';
import { IProductWithPromotionViewModel } from 'src/app/services/products-service/contracts/iproduct-with-promotio-view-model';
import { ProductService } from 'src/app/services/products-service/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  public products : Array<IProductWithPromotionViewModel> = new Array<IProductWithPromotionViewModel>();

  constructor(private _productService: ProductService) { }

  ngOnInit() {
    this.getProductsWithPromotion();
  }

  getProductsWithPromotion()
  {
    this._productService.getProductsWithPromotion().subscribe(
      (x: IProductWithPromotionViewModel[]) =>
      {
        this.products = x;
        console.log(this.products);
      },
      (e: any) => {
        console.log("Error to get products with promotion");
        this.products = [];
      }
    )
  }

}
