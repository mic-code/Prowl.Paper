using System.Drawing;

using Prowl.PaperUI;

namespace Shared.ComponentDemos;

public class ToggleDemo : IDemo
{
    bool isOn = false;

    public void DefineStyles()
    {

        Paper.DefineStyle("row")
            .Height(60)
            .Margin(20, 20, 0, 5);

        Paper.DefineStyle("toggle")
            .Width(60)
            .Height(30);

        Paper.DefineStyle("toggle.rounded")
            .Rounded(20);

        Paper.DefineStyle("toggle.on", "toggle")
            .BackgroundColor(ComponentDemo.secondaryColor);

        Paper.DefineStyle("toggle.off", "toggle")
            .BackgroundColor(Color.FromArgb(100, ComponentDemo.lightTextColor));

        Paper.DefineStyle("toggle.dot")
            .Width(24)
            .Height(24)
            .BackgroundColor(Color.White);
    }

    public void Render()
    {
        using (Paper.Row($"Setting").Style("row").Enter())
        {
            using (Paper.Box($"SettingLabel")
                             .Text(Text.Left("Round Toggle", ComponentDemo.fontMedium, ComponentDemo.textColor))
                             .Enter()) { }

            using (Paper.Box($"ToggleSwitch")
                .Style(isOn ? "toggle.on" : "toggle.off")
                .Style("toggle.rounded")
                .Transition(GuiProp.BackgroundColor, 0.25f, Paper.Easing.CubicInOut)
                .OnClick((rect) => { isOn = !isOn; })
                .Enter())
            {
                using (Paper.Box($"ToggleDot")
                    .Style("toggle.dot")
                    .Style("toggle.rounded")
                    .Transition(GuiProp.Left, 0.25f, Paper.Easing.CubicInOut)
                    .PositionType(PositionType.SelfDirected)
                    .Left(Paper.Pixels(isOn ? 32 : 4))
                    .Top(Paper.Pixels(3))
                    .Enter()) { }
            }
        }

        using (Paper.Row($"Setting").Style("row").Enter())
        {
            using (Paper.Box($"SettingLabel")
                             .Text(Text.Left("Rect Toggle", ComponentDemo.fontMedium, ComponentDemo.textColor))
                             .Enter()) { }

            using (Paper.Box($"ToggleSwitch")
                .Style(isOn ? "toggle.on" : "toggle.off")
                .Transition(GuiProp.BackgroundColor, 0.25f, Paper.Easing.CubicInOut)
                .OnClick((rect) => { isOn = !isOn; })
                .Enter())
            {
                using (Paper.Box($"ToggleDot")
                    .Style("toggle.dot")
                    .Transition(GuiProp.Left, 0.25f, Paper.Easing.CubicInOut)
                    .PositionType(PositionType.SelfDirected)
                    .Left(Paper.Pixels(isOn ? 32 : 4))
                    .Top(Paper.Pixels(3))
                    .Enter()) { }
            }
        }
    }
}
