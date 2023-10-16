export interface chatMessage {
  id?: string;
  content: string | null;
  sender: string | null;
  timestamp?: Date;
}
