using WebSocketSharp.Server;

public static class SocketHandler {
    public static List<WebSocketBehavior> Clients = new();
}



public class ClientHandler {
    private static void Broadcast(string msg) {
        SocketHandler.Clients.ForEach(x =>
            x.Context.WebSocket.Send(msg)
        );
    }
    public static void HandleBroadcast(string msg) {
        Broadcast(msg.Remove(0, 9).Trim());
    }

    public static void HandleOpen(string msg) {
        Broadcast(msg);
    } 
}