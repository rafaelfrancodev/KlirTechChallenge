export interface IProductWithPromotionViewModel {
  id: number;
  name: string;
  price: number;
  promotion: IPromotionViewModel
}

export interface IPromotionViewModel {
  id: number;
  description: string;
}

export interface IProductViewModel {
  id: number;
  name: string;
  price: number;
}
