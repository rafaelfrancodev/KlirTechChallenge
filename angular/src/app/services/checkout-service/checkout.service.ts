import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UrlBaseService } from '../url-base-service/url-base.service';
import { ICheckoutInput } from './contracts/icheckout-input';
import { ICheckoutViewModel } from './contracts/icheckout-view-model';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService extends UrlBaseService {

  constructor(private _http: HttpClient) {
    super()
   }

   getCheckout(): Observable<ICheckoutViewModel>
   {
      return this._http.get<ICheckoutViewModel>(`${this.url}checkout`);
   }

   addItem(input: ICheckoutInput): Observable<ICheckoutViewModel>
   {
      return this._http.post<ICheckoutViewModel>(`${this.url}checkout`, input);
   }

   removeItem(productId: number): Observable<ICheckoutViewModel>
   {
      return this._http.delete<ICheckoutViewModel>(`${this.url}checkout/${productId}`);
   }
}
