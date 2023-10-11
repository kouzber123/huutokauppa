import { useEffect, useState } from "react";
import CssBaseline from "@mui/material/CssBaseline";

import { Product } from "../models/product";
import "./style.css";
import Catalog from "../../features/catalog/Catalog";
import Header from "./Header";
import { Container } from "@mui/material";
function App() {
  const [products, setProducts] = useState<Product[]>([]);
  useEffect(() => {
    fetch("http://localhost:5009/api/Product/List")
      .then(res => res.json())
      .then(data => setProducts(data));
  }, []);
  return (
    <>
      <CssBaseline />
      <Header />
      <Container>
        <Catalog products={products} />
      </Container>
    </>
  );
}

export default App;
