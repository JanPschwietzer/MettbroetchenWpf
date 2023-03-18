using System;
using Microsoft.Toolkit.Uwp.Notifications;

namespace MettbrötchenWpf;

public static class ToastWindow
{
    public static void Show(bool value)
    {
        new ToastContentBuilder()
            .AddText("Achtung!")
            .AddText(value ? "Du kannst jetzt Mettbrötchen bestellen!" : "Anmeldeschluss ist erreicht!")
            .AddText(value ? String.Empty : "Guten Appetit!")
            .SetToastDuration(ToastDuration.Short)
            .Show();
    }
}