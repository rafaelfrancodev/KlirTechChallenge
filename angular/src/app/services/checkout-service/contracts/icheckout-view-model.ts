import { IProductViewModel } from "../../products-service/contracts/iproduct-with-promotio-view-model";

export interface ICheckoutViewModel {
  id: string;
  products: IShoppingCartItemViewModel[];
  total: number;
}

export interface IShoppingCartItemViewModel {
  id: string;
  checkoutId: string;
  product: IProductViewModel;
  quantity: number;
  price: number;
  total: number;
}
