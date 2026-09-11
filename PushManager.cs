using System.Threading.Tasks;
using Altairis.Pushover.Client;

public static class PushManager {
    private static readonly string? API_TOKEN = null;

    private static readonly string? USER_TOKEN = null;
    public static async Task PushToPhone(string title, string body) {
        if(API_TOKEN is null) {
            "API Token for Pushover is not supplied".Warn();
            return;
        }
        if(USER_TOKEN is null) {
            "User Token for Pushover is not supplied".Warn();
            return;
        }

        var client = new PushoverClient(API_TOKEN);
    
        var msg = new PushoverMessage(USER_TOKEN, title) {
            Message = body,
        };

        var res = await client.SendMessage(msg);

        if(!res.Status) {
            "Could not send message to phone".Warn();
        }
    }
}