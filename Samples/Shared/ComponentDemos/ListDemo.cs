using Prowl.PaperUI;
using System.Drawing;

namespace Shared.ComponentDemos;

internal class ListDemo : IDemo
{
    public void DefineStyles()
    {

    }

    public void Render()
    {
        using (Paper.Box("ScrollTest")
            .BackgroundColor(ComponentDemo.cardBackground)
            //.Style(BoxStyle.SolidRounded(cardBackground, 8f))
            .Margin(15 / 2, 0, 15, 0)
            .Enter())
        {
            // Dynamic content amount based on time
            int amount = (int)(Math.Abs(Math.Sin(ComponentDemo.time * 0.25)) * 25) + 10;

            // Create a grid layout for items
            using (Paper.Row("GridContainer")
                .Enter())
            {
                // Left column - cards
                using (Paper.Column("LeftColumn")
                    .Width(Paper.Stretch(0.6))
                    .SetScroll(Scroll.ScrollY)
                    .Enter())
                {
                    double scrollState = Paper.GetElementStorage<ScrollState>(Paper.CurrentParent, "ScrollState", new ScrollState()).Position.y;

                    for (int i = 0; i < 20; i++)
                    {
                        // Custom icon for each card
                        string icon = Icons.GetRandomIcon(i);

                        using (Paper.Box($"Card_{i}")
                            .Height(70)
                            .Margin(10, 10, 5, 5)
                            //.BackgroundColor(Color.FromArgb(230, itemColor))
                            .BorderColor(ComponentDemo.isDark ? Color.FromArgb(50, 255, 255, 255) : Color.FromArgb(50, 0, 0, 0))
                            .BorderWidth(1)
                            .Rounded(12)
                            .Enter())
                        {
                            using (Paper.Row("CardContent")
                                .Margin(10)
                                .Enter())
                            {
                                // Icon
                                using (Paper.Box($"CardIcon_{i}")
                                    .Width(50)
                                    .Height(50)
                                    .Rounded(25)
                                    .BackgroundColor(Color.FromArgb(60, 255, 255, 255))
                                    .Text(Text.Center(icon, ComponentDemo.fontMedium, ComponentDemo.textColor))
                                    .Enter()) { }

                                // Content
                                using (Paper.Column($"CardTextColumn_{i}")
                                    .Margin(10, 0, 0, 0)
                                    .Enter())
                                {
                                    using (Paper.Box($"CardTitle_{i}")
                                        .Height(25)
                                        .Text(Text.Left($"Item {i}", ComponentDemo.fontMedium, ComponentDemo.textColor))
                                        .Enter()) { }

                                    using (Paper.Box($"CardDescription_{i}")
                                        .Text(Text.Left($"Interactive card with animations", ComponentDemo.fontSmall,
                                            Color.FromArgb(200, ComponentDemo.textColor)))
                                        .Enter()) { }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
