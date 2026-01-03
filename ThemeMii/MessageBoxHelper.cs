using System.Threading.Tasks;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace ThemeMii;

public class MessageBoxHelper
{
    public static async Task DisplayErrorMessage(string message)
    {
        var errorMessage = MessageBoxManager.GetMessageBoxStandard("Error", message, ButtonEnum.Ok,
            Icon.Error);
        await errorMessage.ShowAsync();
    }

    public static async Task DisplayInfoBox(string message)
    {
        var infoMessage =
            MessageBoxManager.GetMessageBoxStandard("Info", message, ButtonEnum.Ok, Icon.Info);
        await infoMessage.ShowAsync();
    }

    public static async Task DisplayWarningBox(string message)
    {
        var infoMessage =
            MessageBoxManager.GetMessageBoxStandard("Warning", message, ButtonEnum.Ok, Icon.Warning);
        await infoMessage.ShowAsync();
    }

}