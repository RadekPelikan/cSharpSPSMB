import { useEffect, useState } from "react";
import * as signalR from "@microsoft/signalr";
import { SignalRContext } from "../context/signalRContext";

function generateUuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

export const useSignalR = () => {
    const _connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5190/chat", { withCredentials: true, })
        .configureLogging(signalR.LogLevel.Information)
        .build();

    const [connection, setConection] = useState(_connection)

    const start = () => {
        connection.start()
            .then(() => connection.invoke("Connect", generateUuidv4()));
    }

    return { start, connection }
}

let isSetup = false
export const useChat = (initData) => {
    const { start, connection } = useSignalR()
    const [messages, setMessages] = useState(initData ?? [])

    const setupHandlers = () => {
        if (isSetup)
            return
        connection.on("LoadMessages", messages => {
            setMessages(messages)
        });

        connection.on("ReceiveMessage", message => {
            console.log("recieve", message)

            setMessages(prev => [...prev, message])
        });
        isSetup = true
    }

    useEffect(() => {
        setupHandlers()

        start()
    }, [])

    const sendMessage = (chatMessage) => {
        console.log("send", chatMessage)

        connection.invoke("SendMessage", chatMessage)
    }
    return { messages, sendMessage }
}