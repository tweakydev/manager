using System.Threading.Tasks;
using Altairis.Pushover.Client;

public static class PushManager {
    public static async Task PushToPhone(string title, string body) {
        var api_key = Environment.GetEnvironmentVariable("API_KEY");
        var user_key = Environment.GetEnvironmentVariable("USER_KEY");
        if(api_key is null) {
            "API Token for Pushover is not supplied".Warn();
            return;
        }
        if(user_key is null) {
            "User Token for Pushover is not supplied".Warn();
            return;
        }

        var client = new PushoverClient(api_key);
    
        var msg = new PushoverMessage(user_key, title) {
            Message = body,
        };

        var res = await client.SendMessage(msg);

        if(!res.Status) {
            "Could not send message to devicee".Warn();
        }
    }
}