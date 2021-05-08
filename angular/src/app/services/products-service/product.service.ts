import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UrlBaseService } from '../url-base-service/url-base.service';
import { IProductWithPromotionViewModel } from './contracts/iproduct-with-promotio-view-model';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends UrlBaseService {

  constructor(private _http: HttpClient) {
    super()
   }

   getProductsWithPromotion(): Observable<IProductWithPromotionViewModel[]>
   {
      return this._http.get<IProductWithPromotionViewModel[]>(`${this.url}products`);
   }
}
