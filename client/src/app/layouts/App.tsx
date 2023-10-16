import CssBaseline from "@mui/material/CssBaseline";

import "./style.css";
import Header from "./Header";
import { Container } from "@mui/material";
import { Outlet } from "react-router-dom";
function App() {
  return (
    <>
      <CssBaseline />
      <Header />
      <Container>
        <Outlet />
      </Container>
    </>
  );
}

export default App;
