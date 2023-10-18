import { Product } from "./product";

export interface auction {
  id: number
  name: string;
  price: number;
  image: string;
  description: string;
  quantity: number;
  ownerId: number;
  hostName: string;
  product: Product;
  auctioneerId: number;
  region: string;
  auctionDetails: string;
  auctionStart: Date;
  formattedStartDate: string;
  auctionActive: boolean;
  category: string;
}
