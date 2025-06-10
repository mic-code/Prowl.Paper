using FontStashSharp;
using System.Drawing;
using Prowl.PaperUI;
using System.Reflection;
using Shared.ComponentDemos;

namespace Shared
{
    public class ComponentDemo : IDemoThumbnail
    {
        public static FontSystem fontSystem;
        public static SpriteFontBase fontSmall;
        public static SpriteFontBase fontMedium;
        public static SpriteFontBase fontLarge;
        public static SpriteFontBase fontTitle;

        int selectedTabIndex = 0;

        //Theme
        public static Color backgroundColor;
        public static Color cardBackground;
        public static Color primaryColor;
        public static Color secondaryColor;
        public static Color tertiaryColor;
        public static Color textColor;
        public static Color lightTextColor;
        public static Color[] colorPalette;
        public static bool isDark;
        public static double time = 0;

        static IDemo[] demos;

        public void Initialize()
        {
            ToggleTheme();
            fontSystem = new FontSystem();

            // Load fonts with different sizes
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream? stream = assembly.GetManifestResourceStream("Shared.EmbeddedResources.font.ttf"))
            {
                if (stream == null) throw new Exception("Could not load font resource");
                fontSystem.AddFont(stream);
            }
            using (Stream? stream = assembly.GetManifestResourceStream("Shared.EmbeddedResources.fa-regular-400.ttf"))
            {
                if (stream == null) throw new Exception("Could not load font resource");
                fontSystem.AddFont(stream);
            }
            using (Stream? stream = assembly.GetManifestResourceStream("Shared.EmbeddedResources.fa-solid-900.ttf"))
            {
                if (stream == null) throw new Exception("Could not load font resource");
                fontSystem.AddFont(stream);
            }

            fontSmall = fontSystem.GetFont(19);
            fontMedium = fontSystem.GetFont(26);
            fontLarge = fontSystem.GetFont(32);
            fontTitle = fontSystem.GetFont(40);
            DefineStyles();

            demos = new IDemo[]
            {
                new ButtonDemo(),
                new ToggleDemo(),
                new SliderDemo(),
                new ListDemo(),
            };
        }

        public void DefineStyles()
        {
            if (isDark)
            {
                //Dark
                backgroundColor = Color.FromArgb(255, 18, 18, 23);
                cardBackground = Color.FromArgb(255, 30, 30, 46);
                primaryColor = Color.FromArgb(255, 94, 104, 202);
                secondaryColor = Color.FromArgb(255, 162, 155, 254);
                tertiaryColor = Color.FromArgb(255, 255, 255, 0);
                textColor = Color.FromArgb(255, 226, 232, 240);
                lightTextColor = Color.FromArgb(255, 148, 163, 184);
                colorPalette = [
                    Color.FromArgb(255, 94, 234, 212),   // Cyan
                    Color.FromArgb(255, 162, 155, 254),  // Purple  
                    Color.FromArgb(255, 249, 115, 22),   // Orange
                    Color.FromArgb(255, 248, 113, 113),  // Red
                    Color.FromArgb(255, 250, 204, 21)    // Yellow
                ];
            }
            else
            {

                //Light
                backgroundColor = Color.FromArgb(255, 243, 244, 246);
                cardBackground = Color.FromArgb(255, 255, 255, 255);
                primaryColor = Color.FromArgb(255, 59, 130, 246);
                secondaryColor = Color.FromArgb(255, 16, 185, 129);
                tertiaryColor = Color.FromArgb(255, 255, 255, 0);
                textColor = Color.FromArgb(255, 31, 41, 55);
                lightTextColor = Color.FromArgb(255, 107, 114, 128);
                colorPalette = [
                    Color.FromArgb(255, 59, 130, 246),   // Blue
                    Color.FromArgb(255, 16, 185, 129),   // Teal  
                    Color.FromArgb(255, 239, 68, 68),    // Red
                    Color.FromArgb(255, 245, 158, 11),   // Amber
                    Color.FromArgb(255, 139, 92, 246)    // Purple
                ];
            }

            Paper.DefineStyle("mainContent")
                .BackgroundColor(cardBackground)
                .Rounded(8);

            // Sidebar styles
            Paper.DefineStyle("sidebar")
                .BackgroundColor(cardBackground)
                .Rounded(8)
                .Width(240);

            // Expanded sidebar
            Paper.DefineStyle("sidebar.expanded")
                .BorderColor(primaryColor)
                .BorderWidth(1);

            // Button
            //Paper.DefineStyle("button")
            //    .Height(40)
            //    .Rounded(8);

            // Primary button
            Paper.DefineStyle("button.primary")
                .BackgroundColor(primaryColor);

            // Toggle switch
            Paper.DefineStyle("toggle")
                .Width(60)
                .Height(30)
                .Rounded(20);

            // Toggle on
            Paper.DefineStyle("toggle.on", "toggle")
                .BackgroundColor(secondaryColor);

            // Toggle off
            Paper.DefineStyle("toggle.off", "toggle")
                .BackgroundColor(Color.FromArgb(100, lightTextColor));

            // Toggle dot
            Paper.DefineStyle("toggle.dot")
                .Width(24)
                .Height(24)
                .Rounded(20)
                .BackgroundColor(Color.White);

            Paper.DefineStyle("separator")
                .Height(1)
                .Margin(15, 15, 0, 0)
                .BackgroundColor(Color.FromArgb(30, 0, 0, 0));
        }

        public void Render()
        {
            // Update time for animations
            time += 0.016f; // Assuming ~60fps

            //set style every frame to allow hotreload to work
            DefineStyles();

            using (Paper.Column("MainContainer").BackgroundColor(backgroundColor).Enter())
            {
                RenderTopNavBar();

                using (Paper.Row("ContentArea").Enter())
                {
                    RenderSidebar();
                    RenderMainContent();
                }

                RenderFooter();
            }
        }

        public void RenderThumbnail()
        {

        }

        private void RenderTopNavBar()
        {

        }

        private void RenderSidebar()
        {
            using (Paper.Column("Sidebar")
             .Style("sidebar")
             .Hovered.Style("sidebar.expanded").End()
             .Transition(GuiProp.Width, 0.25f, Paper.Easing.EaseIn)
             .Transition(GuiProp.BorderColor, 0.75f)
             .Transition(GuiProp.BorderWidth, 0.75f)
             .Transition(GuiProp.Rounded, 0.25f)
             .Margin(15)
             .Enter())
            {
                // Menu header
                Paper.Box("MenuHeader").Height(60).Text(Text.Center("Menu", fontMedium, textColor));
                string[] menuIcons = { Icons.House, Icons.ChartBar, Icons.User, Icons.Gear, Icons.WindowMaximize };

                for (int i = 0; i < demos.Length; i++)
                {
                    int index = i;

                    using (Paper.Box($"MenuItemContainer_{i}")
                        .Height(50)
                        .Margin(10, 10, 5, 5)
                        .Rounded(8)
                        .BorderColor(primaryColor)
                        .BorderWidth(selectedTabIndex == index ? 2 : 0)
                        .OnClick((rect) => selectedTabIndex = index)
                        .Hovered
                            .BackgroundColor(Color.FromArgb(20, primaryColor))
                            //.BorderWidth(2)
                            .End()
                        //.Transition(GuiProp.BackgroundColor, 0.05f)
                        .Transition(GuiProp.BorderWidth, 0.1f)
                        .Clip()
                        .Enter()
                        )
                    {
                        var icon = Paper.Box($"MenuItemIcon_{i}")
                            .Width(55)
                            .Height(50)
                            .Text(Text.Center(menuIcons[i], fontSmall, textColor));

                        var but = Paper.Box($"MenuItem_{i}")
                            .Width(100)
                            .PositionType(PositionType.SelfDirected)
                            .Left(50 + 15)
                            .Text(Text.Center($"{demos[i].GetType().Name.Replace("Demo", "")}", fontSmall, textColor));
                    }
                }
            }
        }

        private void RenderMainContent()
        {
            using (Paper.Column("MainContent")
            .Style("mainContent")
            .Transition(GuiProp.Width, 0.25f, Paper.Easing.EaseIn)
            .Transition(GuiProp.BorderColor, 0.75f)
            .Transition(GuiProp.BorderWidth, 0.75f)
            .Transition(GuiProp.Rounded, 0.25f)
            .Margin(0, 15, 15, 15)
            .Enter())
            {
                if (selectedTabIndex < demos.Length)
                {
                    var demo = demos[selectedTabIndex];
                    Paper.Box("Header").Height(60).Text(Text.Center(demo.GetType().Name, fontMedium, textColor));
                    demo.DefineStyles();
                    demo.Render();
                }
            }
        }

        private void RenderFooter()
        {

        }

        private void ToggleTheme()
        {
            isDark = !isDark;

            DefineStyles();
        }
    }
}
