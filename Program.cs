using Telegram.Bot;
using Telegram.Bot.Types;

var botClient = new TelegramBotClient("5276823851:AFF3LjRMF7DOir1eeIgwINI6oyYJpIjCQuM");

var me = await botClient.GetMeAsync();

while (true)
{
    var updates = await botClient.GetUpdatesAsync();
    for (int i = 0; i < updates.Count(); i++)
    {
        switch(updates[i].Type)
        {
            case Telegram.Bot.Types.Enums.UpdateType.Message: {
                UpdateHandle(updates[i].Message!);
                updates = await botClient.GetUpdatesAsync(updates[^1].Id + 1);
                break;
            }
        }
    }
}

async void UpdateHandle(Message message){
    await botClient!.SendTextMessageAsync(message.Chat.Id, $"{message.From.Username} Ты мне написал {message.Text}?");
}
