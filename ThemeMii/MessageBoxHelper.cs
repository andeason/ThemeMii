using System.Threading.Tasks;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace ThemeMii;

public class MessageBoxHelper
{
    public static async Task DisplayErrorMessage(string message)
    {
        var errorMessage = MessageBoxManager.GetMessageBoxStandard("Error", message, ButtonEnum.Ok,
            MsBox.Avalonia.Enums.Icon.Error);
        await errorMessage.ShowAsync();
    }

    public static async Task DisplayInfoBox(string message)
    {
        var infoMessage =
            MessageBoxManager.GetMessageBoxStandard("Info", message, ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Info);
        await infoMessage.ShowAsync();
    }

}