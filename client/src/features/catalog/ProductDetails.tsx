import {
  Box,
  Button,
  CardContent,
  Divider,
  Grid,
  Input,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableRow,
  Typography,
} from "@mui/material";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import { Product } from "../../app/models/product";
import CommentBox from "../comment/CommentBox";
import CommentList from "../comment/CommnetList";


export default function ProductDetails() {
  const { id } = useParams<{ id: string }>();

  //component mounts
  const [product, setProduct] = useState<Product | null>(null);

  const [loading, setLoading] = useState(true);
  useEffect(() => {
    axios
      .get(`http://localhost:5009/api/Product/${id}`)
      .then(response => setProduct(response.data))
      .catch(err => console.log(err))
      .finally(() => setLoading(false));
  }, [id]);

  if (loading) return <h3>Loading...</h3>;

  if (!product) return <h3>Product not found</h3>;
  //http://localhost:5009/api/Product/1
  return (
    <Grid
      container
      spacing={3}
    >
      <Grid
        item
        xs={4}
      >
        <img
          src={product.image}
          alt={product.name}
          style={{ width: "100%" }}
        />

        <TableContainer>
          <Table>
            <TableBody>
              <TableRow>
                <TableCell>Name</TableCell>
                <TableCell>{product.name}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Description</TableCell>
                <TableCell>Luo description tuotteelle</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Type</TableCell>
                <TableCell>Luo tyyppi kategoria tuotteelle</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Quantity in stock</TableCell>
                <TableCell>Luo kpl määrä tuotteelle</TableCell>
              </TableRow>
            </TableBody>
          </Table>
        </TableContainer>
      </Grid>
      <Grid
        item
        xs={4}
      >
        <Typography variant="h3">{product.name}</Typography>
        <Divider sx={{ mb: 2 }} />
        <Typography
          variant="h4"
          color={"secondary"}
          sx={{ mb: 3 }}
        >
          Current Price ${(product.price / 100).toFixed(2)}
        </Typography>
        <Input placeholder="summa" />
        <Button
          size="small"
          variant="contained"
          color="success"
          sx={{ marginLeft: 1 }}
        >
          Korota
        </Button>
      </Grid>
      <Grid
        item
        xs={4}
      >
        <Box sx={{ width: "max(400px, 60%)", mb: 2 }}>
          <CommentBox />
          <CardContent>
            <CommentList />
          </CardContent>
        </Box>
      </Grid>
    </Grid>
  );
}
