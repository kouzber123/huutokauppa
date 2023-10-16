import Box from "@mui/joy/Box";
import Card from "@mui/joy/Card";
import CardContent from "@mui/joy/CardContent";
import Typography from "@mui/joy/Typography";
import { useEffect, useState } from "react";
import { chatMessage } from "../../app/models/chatMessage";

export default function CommentList() {
  const [messages, setMessages] = useState<chatMessage[]>([]);
  useEffect(() => {
    fetch("http://localhost:5009/api/Message/commentList")
      .then(data => data.json())
      .then((response: chatMessage[]) => {
        setMessages([...response]);
      });
  }, []);
  useEffect(() => {
    console.log(messages);
  }, [messages]);
  return (
    <Box
      sx={{
        width: "100%",
        maxWidth: 400,
        display: "grid",
        gridTemplateColumns: "repeat(auto-fill, minmax(180px, 1fr))",
        gap: 2,
      }}
    >
      {messages.map(item => (
        <Card variant="solid">
          <CardContent>
            <Typography
              level="title-md"
              textColor="inherit"
            >
              {item.sender}
            </Typography>
            <Typography textColor="inherit">{item.content}</Typography>
          </CardContent>
        </Card>
      ))}
    </Box>
  );
}
