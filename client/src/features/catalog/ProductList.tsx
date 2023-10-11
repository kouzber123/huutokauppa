import { List } from "@mui/material";
import { Product } from "../../app/models/product";
import ProductCard from "./ProductCard";
interface Props {
  products: Product[];
}
export default function ProductList({ products }: Props) {
  return (
    <List className="auctionList">
      {products.map(item => (
        <ProductCard
          key={item.id}
          product={item}
        />
      ))}
    </List>
  );
}
