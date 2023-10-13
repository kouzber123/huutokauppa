import { useEffect, useState } from "react";
import * as signalR from "@microsoft/signalr";
import { chatMessage } from "../app/models/chatMessage";

export default function Chat() {
  const [connection, setConnection] = useState<signalR.HubConnection | null>(null);
  const [messages, setMessages] = useState<string[]>([]);
  const [user, setUser] = useState("");
  const [message, setMessage] = useState("");
  const [messageObj, setMessageObj] = useState<chatMessage>({
    sender: "",
    content: "",
  });
  useEffect(() => {
    const newConnection = new signalR.HubConnectionBuilder()
      .withUrl("http://localhost:5009/chatHub")
      .withAutomaticReconnect()
      .build();

    newConnection
      .start()
      .then(() => {
        setConnection(newConnection);
      })
      .catch(err => console.log(err));
    //receivemessage is client side method > this comes from server
    newConnection.on("ReceiveMessage", (message: chatMessage) => {
      setMessages([...messages, `${message.sender} :  ${message.content} `]);
    });

    newConnection.onreconnecting(() => {
      console.log("Reconnecting...");
    });

    newConnection.onreconnected(() => {
      console.log("Reconnected!");
    });
    return () => {
      newConnection.stop();
    };
  }, [messages]);
  useEffect(() => {
    setMessageObj({
      sender: user,
      content: message,
    });
  }, [message, user]);
  const sendMessage = () => {
    if (connection) {
      //   const messageObj = { sender: user, content: message };
      connection.invoke("SendMessage", messageObj); //invokes method in serverside this sends to server
      setMessage("");
    }
  };

  return (
    <div>
      <div>
        <input
          placeholder="User"
          value={user}
          onChange={e => setUser(e.target.value)}
        />
      </div>

      <div>
        <input
          placeholder="Message"
          value={message}
          onChange={e => setMessage(e.target.value)}
        />
        <button onClick={sendMessage}>Send</button>
      </div>
      <div>
        {messages.map((msg, index) => (
          <div key={index}>{msg}</div>
        ))}
      </div>
    </div>
  );
}
