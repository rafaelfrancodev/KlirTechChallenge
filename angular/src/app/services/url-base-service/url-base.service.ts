import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UrlBaseService {

  private urlBase: string;

  constructor() {
    this.urlBase = `${environment.apiUrl}`;
  }

  get url(): string {
    return `${this.urlBase}api/v1/`;
  }

}
