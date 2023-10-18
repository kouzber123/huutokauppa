import { useEffect, useState } from "react";

import ProductList from "./ProductList";
import { auction } from "../../app/models/auction";

export default function Catalog() {
  const [auctions, setAuctions] = useState<auction[]>([]);
  useEffect(() => {
    fetch("http://localhost:5009/api/Auction")
      .then(res => res.json())
      .then(data => setAuctions(data));

    console.log(auctions)
  }, []);
  return <ProductList auction={auctions} />;
}
