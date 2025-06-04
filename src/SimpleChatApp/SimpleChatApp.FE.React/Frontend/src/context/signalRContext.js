import { createContext } from "react";
import { useChat, useSignalR } from "../hooks/useSignalR";

export const SignalRContext = createContext(null);

export const ChatContext = createContext(null);