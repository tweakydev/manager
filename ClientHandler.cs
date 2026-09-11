using WebSocketSharp.Server;

public static class SocketHandler {
    public static List<WebSocketBehavior> Clients = new();
}



public class ClientHandler {
    private static async Task Broadcast(string msg, WebSocketBehavior origin) {
        SocketHandler.Clients.Where(x => x != origin).ToList().ForEach(x =>
            x.Context.WebSocket.Send(msg)
        );

        await PushManager.PushToPhone("Broadcast", msg);
    }
    public static async void HandleBroadcast(string msg, WebSocketBehavior origin) {
        await Broadcast(msg.Remove(0, 9).Trim(), origin);
    }

    public static void HandleOpen(string msg) {
    } 
}