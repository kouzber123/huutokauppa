import { useEffect, useState } from "react";
import * as signalR from "@microsoft/signalr";
import { chatMessage } from "../app/models/chatMessage";

export default function Chat() {
  const [connection, setConnection] = useState<signalR.HubConnection | null>(null);
  const [messages, setMessages] = useState<string[]>([]);
  const [user, setUser] = useState("");
  const [message, setMessage] = useState("");

  // const [loadComments, setLoadComments] = useState<chatMessage[]>([]);
  // const [messageObj, setMessageObj] = useState<chatMessage>({
  //   sender: "",
  //   content: "",
  // });

  const loadComments = [
    {
      sender: "Sender1",
      content: "Comment 1",
      timestamp: new Date(),
    },
    {
      sender: "Sender2",
      content: "Comment 2",
      timestamp: new Date(),
    },
    {
      sender: "Sender3",
      content: "Comment 3",
      timestamp: new Date(),
    },
    // Add more comments as needed
  ];
  useEffect(() => {
    fetch("http://localhost:5009/api/Message/commentList")
      .then(data => data.json())
      .then((response: chatMessage[]) => {
        const mapped = response.map(item => `${item.sender} ${item.content}`);

        console.log(mapped);
        setMessages(mapped);
      });
  }, []);

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

    // Make a request to the server to retrieve comments when the component mount

    newConnection.on("LoadComments", (message: chatMessage[]) => {
      setMessages(prevMessages => [...prevMessages, ...message.map(msg => `${msg.sender} :  ${msg.content}`)]);
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
  // : Promise<chatMessage[]>

  const sendMessage = () => {
    if (connection) {
      connection.invoke("SendProductComments", loadComments);
      console.log(loadComments.length);
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
        {/* <button onClick={sendMessage}>Send</button> */}
        <button onClick={sendMessage}>LoadComments</button>
      </div>
      <div>
        {messages.map((msg, index) => (
          <div key={index}>{msg}</div>
        ))}
      </div>
    </div>
  );
}
