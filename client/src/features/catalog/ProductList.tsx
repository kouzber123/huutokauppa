import { Grid } from "@mui/material";
import ProductCard from "./ProductCard";
import { auction } from '../../app/models/auction';
interface Props {
  auction: auction[];
}
export default function ProductList({ auction }: Props) {
  return (
    <Grid
      container
      spacing={4}
    >
      {auction.map(item => (
        <Grid
          item
          xs={4}
          key={item.id}
        >
          <ProductCard
            key={item.id}
            auction={item}
          />
        </Grid>
      ))}

    </Grid>
  );
}
