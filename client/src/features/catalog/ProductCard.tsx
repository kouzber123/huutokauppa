import { ListItem, ListItemAvatar, Avatar, ListItemText, Button } from "@mui/material";
import { Product } from "../../app/models/product";
interface Props {
  product: Product;
}
export default function ProductCard({ product }: Props) {
  return (
    <ListItem key={product.id}>
      <ListItemAvatar>
        <Avatar
          src={product.image}
          variant="square"
        />
      </ListItemAvatar>
      <ListItemText>
        {product.name} - {product.price}
      </ListItemText>
      <ListItemText>Huutokaupan pitäjä - {product.ownerName} </ListItemText>

      <Button variant="contained">Katso</Button>
    </ListItem>
  );
}
