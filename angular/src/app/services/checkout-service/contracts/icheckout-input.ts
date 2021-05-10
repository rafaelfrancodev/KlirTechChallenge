import { IProductViewModel } from "../../products-service/contracts/iproduct-with-promotio-view-model";

export interface ICheckoutInput {
  product: IProductViewModel;
  quantity: number;
}
