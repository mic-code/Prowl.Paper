using System.Drawing;
using Prowl.PaperUI;

namespace Shared.ComponentDemos;

public class ToggleDemo : IDemo
{
    public void DefineStyle()
    {
        Paper.DefineStyle("button")
            .BackgroundColor(ComponentDemo.primaryColor)
            .Margin(10, 0, 10, 0)
            .Width(200)
            .Height(40);

        Paper.DefineStyle("button.rounded")
            .BackgroundColor(ComponentDemo.primaryColor)
            .Rounded(8);

        Paper.DefineStyle("button.rounded2")
            .BackgroundColor(ComponentDemo.primaryColor)
            .Rounded(8, 8, 0, 0);

        Paper.DefineStyle("button.hover")
            .BackgroundColor(ComponentDemo.secondaryColor);

        Paper.DefineStyle("button.active")
            .BackgroundColor(ComponentDemo.secondaryColor)
            .BorderColor(ComponentDemo.tertiaryColor)
            .BorderWidth(3);

        Paper.DefineStyle("button.focused")
            .BorderColor(ComponentDemo.tertiaryColor)
            .BorderWidth(1);
    }

    public void Render()
    {
        //Paper.Box("Header").Height(60).Text(Text.Center("Button", ComponentDemo.fontMedium, ComponentDemo.textColor));

        using (Paper.Box("Button")
                           .Style("button")
                           .Transition(GuiProp.BackgroundColor, 0.25f, Paper.Easing.EaseIn)
                           .Focused.Style("button.focused").End()
                           .Active.Style("button.active").End()
                           .Hovered.Style("button.hover").End()
                           .Text(Text.Center("Button", ComponentDemo.fontMedium, Color.White))
                           .OnClick((rect) => Console.WriteLine("Clicked"))
                           .Enter()) { }

        using (Paper.Box("Button")
                          .Style("button")
                          .Style("button.rounded")
                          .Transition(GuiProp.BackgroundColor, 0.25f, Paper.Easing.EaseIn)
                           .Focused.Style("button.focused").End()
                           .Active.Style("button.active").End()
                           .Hovered.Style("button.hover").End()
                          .Text(Text.Center("Button", ComponentDemo.fontMedium, Color.White))
                          .OnClick((rect) => Console.WriteLine("Clicked"))
                          .Enter()) { }

        using (Paper.Box("Button")
                          .Style("button")
                          .Style("button.rounded2")
                          .Transition(GuiProp.BackgroundColor, 0.25f, Paper.Easing.EaseIn)
                           .Focused.Style("button.focused").End()
                           .Active.Style("button.active").End()
                           .Hovered.Style("button.hover").End()
                          .Text(Text.Center("Button", ComponentDemo.fontMedium, Color.White))
                          .OnClick((rect) => Console.WriteLine("Clicked"))
                          .Enter()) { }
    }
}
