import { Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import "../../app/layouts/style.css";
import { Link } from "react-router-dom";
import { auction } from '../../app/models/auction';
interface Props {
  auction: auction;
}
export default function ProductCard({ auction }: Props) {
  console.log(auction)
  return (
    <Card >
      <CardMedia
        sx={{ height: 140 }}
        image={auction.product.image}
        title="green iguana"
      />
      <CardContent>
        <Typography
          gutterBottom
          variant="h5"
          component="div"
        >
          {auction.product.name}
        </Typography>
        <Typography
          variant="body2"
          color="text.secondary"
        >
          kauppaaja - {auction.hostName}
        </Typography>
      </CardContent>
      <CardActions>
        <Button component={Link} to={`/catalog/${auction.id}`} size="small">Info</Button>
      </CardActions>
    </Card>
  );
}
