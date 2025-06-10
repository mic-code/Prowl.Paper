using System.Drawing;
using Prowl.PaperUI;

namespace Shared.ComponentDemos;

public class ButtonDemo : IDemo
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
            .RoundedTop(8);

        Paper.DefineStyle("button.rounded3")
            .BackgroundColor(ComponentDemo.primaryColor)
            .RoundedBottom(8);

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
        using (Paper.Box("Button")
                           .Style("button")
                           .Transition(GuiProp.BackgroundColor, 0.25f, Paper.Easing.EaseIn)
                           .Focused.Style("button.focused").End()
                           .Active.Style("button.active").End()
                           .Hovered.Style("button.hover").End()
                           .Text(Text.Center("Round Button", ComponentDemo.fontMedium, Color.White))
                           .OnClick((rect) => Console.WriteLine("Clicked"))
                           .Enter()) { }

        using (Paper.Box("Button")
                          .Style("button")
                          .Style("button.rounded")
                          .Transition(GuiProp.BackgroundColor, 0.25f, Paper.Easing.EaseIn)
                           .Focused.Style("button.focused").End()
                           .Active.Style("button.active").End()
                           .Hovered.Style("button.hover").End()
                          .Text(Text.Center("Rect Button", ComponentDemo.fontMedium, Color.White))
                          .OnClick((rect) => Console.WriteLine("Clicked"))
                          .Enter()) { }

        using (Paper.Box("Button")
                          .Style("button")
                          .Style("button.rounded2")
                          .Transition(GuiProp.BackgroundColor, 0.25f, Paper.Easing.EaseIn)
                           .Focused.Style("button.focused").End()
                           .Active.Style("button.active").End()
                           .Hovered.Style("button.hover").End()
                          .Text(Text.Center("Top Round Button", ComponentDemo.fontMedium, Color.White))
                          .OnClick((rect) => Console.WriteLine("Clicked"))
                          .Enter()) { }


        using (Paper.Box("Button")
                          .Style("button")
                          .Style("button.rounded3")
                          .Transition(GuiProp.BackgroundColor, 0.25f, Paper.Easing.EaseIn)
                           .Focused.Style("button.focused").End()
                           .Active.Style("button.active").End()
                           .Hovered.Style("button.hover").End()
                          .Text(Text.Center("Bottom Round Button", ComponentDemo.fontMedium, Color.White))
                          .OnClick((rect) => Console.WriteLine("Clicked"))
                          .Enter()) { }
    }
}
