using System.Drawing;
using Prowl.PaperUI;

namespace Shared.ComponentDemos;

public class SliderDemo : IDemo
{
    double sliderValue;

    public void DefineStyles()
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
        using (Paper.Column("SliderSection")
                        .Height(100)
                        .Margin(20, 20, 0, 0)
                        .Enter())
        {
            using (Paper.Box("SliderLabel")
                .Height(30)
                .Text(Text.Left($"Green Amount: {sliderValue:F2}",ComponentDemo.fontMedium,ComponentDemo.textColor))
                .Enter()) { }

            using (Paper.Box("SliderTrack")
                .Height(20)
                .BackgroundColor(Color.FromArgb(30, 0, 0, 0))
                //.Style(BoxStyle.SolidRounded(Color.FromArgb(30, 0, 0, 0), 10f))
                .Margin(0, 0, 20, 0)
                .OnHeld((e) => {
                    double parentWidth = e.ElementRect.width;
                    double pointerX = e.PointerPosition.x - e.ElementRect.x;

                    // Calculate new slider value based on pointer position
                    sliderValue = Math.Clamp(pointerX / parentWidth, 0f, 1f);
                })
                .Enter())
            {
                // Filled part of slider
                using (Paper.Box("SliderFill")
                    .Width(Paper.Percent(sliderValue * 100))
                    .BackgroundColor(ComponentDemo.primaryColor)
                    //.Style(BoxStyle.SolidRounded(primaryColor, 10f))
                    .Enter())
                {
                    // Slider handle
                    using (Paper.Box("SliderHandle")
                        .Left(Paper.Percent(100, -10))
                        .Width(20)
                        .Height(20)
                        .BackgroundColor(ComponentDemo.textColor)
                        //.Style(BoxStyle.SolidRounded(textColor, 10f))
                        .PositionType(PositionType.SelfDirected)
                        .Enter()) { }
                }
            }
        }
    }
}
