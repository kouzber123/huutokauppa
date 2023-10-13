import { Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import { Product } from "../../app/models/product";
import "../../app/layouts/style.css";
interface Props {
  product: Product;
}
export default function ProductCard({ product }: Props) {
  return (
    <Card >
      <CardMedia
        sx={{ height: 140 }}
        image={product.image}
        title="green iguana"
      />
      <CardContent>
        <Typography
          gutterBottom
          variant="h5"
          component="div"
        >
          {product.name}
        </Typography>
        <Typography
          variant="body2"
          color="text.secondary"
        >
          kauppaaja - {product.ownerName}
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small">Info</Button>
      </CardActions>
    </Card>
  );
}
