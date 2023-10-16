import { useEffect, useState } from "react";
import { Product } from "../../app/models/product";
import ProductList from "./ProductList";

export default function Catalog() {
  const [products, setProducts] = useState<Product[]>([]);
  useEffect(() => {
    fetch("http://localhost:5009/api/Product/List")
      .then(res => res.json())
      .then(data => setProducts(data));
  }, []);
  return <ProductList products={products} />;
}
