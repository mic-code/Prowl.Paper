using Prowl.PaperUI;
using System.Drawing;

namespace Shared.ComponentDemos;

internal static class ButtonDemo
{
    internal static void DefineStyle()
    {
        Paper.DefineStyle("button")
            .BackgroundColor(ComponentDemo.primaryColor)
            .Width(200)
            .Height(40)
            .Rounded(8);
    }

    internal static void Render()
    {
        using (Paper.Box("Button")
                           //.PositionType(PositionType.SelfDirected)
                           //.Margin(Paper.Stretch(), 0, Paper.Stretch(), 0)
                           .Style("button")
                           //.Style(BoxStyle.SolidRounded(primaryColor, 8f))
                           //.HoverStyle(BoxStyle.SolidRounded(secondaryColor, 12f))
                           //.ActiveStyle(BoxStyle.SolidRounded(primaryColor, 16f))
                           //.FocusedStyle(BoxStyle.SolidRoundedWithBorder(backgroundColor, textColor, 20f, 1f))
                           .Text(Text.Center("Button", ComponentDemo.fontMedium, Color.White))
                           .Enter()) { }

        using (Paper.Box("Button2")
                          //.Margin(Paper.Stretch(), 0, Paper.Stretch(), 0)
                          .Style("button")
                          .Text(Text.Center("Button2", ComponentDemo.fontMedium, Color.White))
                          .Enter()) { }

        using (Paper.Box("Button3")
                  .Margin(10, 0, 10, 0)
                  .Style("button")
                  .Text(Text.Center("Button3", ComponentDemo.fontMedium, Color.White))
                  .Enter()) { }
    }
}
