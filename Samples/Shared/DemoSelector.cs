using FontStashSharp;
using System.Drawing;
using Prowl.PaperUI;
using Prowl.Vector;
using System.Reflection;
using Shared.ComponentDemos;

namespace Shared
{
    public class DemoSelector
    {
        FontSystem fontSystem;
        SpriteFontBase fontSmall;
        SpriteFontBase fontMedium;
        SpriteFontBase fontLarge;
        SpriteFontBase fontTitle;

        //Theme
        Color backgroundColor;
        Color cardBackground;
        Color thumbBackground;
        Color primaryColor;
        Color secondaryColor;
        Color tertiaryColor;
        Color textColor;
        Color lightTextColor;
        Color[] colorPalette;
        bool isDark;

        IDemoThumbnail[] demos;
        int selectedDemo = -1;

        double time = 0;

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

            demos = new IDemoThumbnail[]
            {
                new PaperDemo(),
                new ComponentDemo(),
            };
        }

        public void RenderUI()
        {
            // Update time for animations
            time += 0.016f; // Assuming ~60fps

            DefineStyles();

            using (Paper.Column("MainContainer").BackgroundColor(backgroundColor).Enter())
            {
                using (Paper.Row("ContentArea").Enter())
                {
                    RenderMainContent();
                }

                RenderFooter();
            }
        }

        private void RenderMainContent()
        {
            if (selectedDemo > -1)
            {
                demos[selectedDemo].DefineStyles();
                demos[selectedDemo].Render();
                return;
            }

            using (Paper.Row("demoGrid")
            .Style("demoGrid")

            .Enter())
            {
                for (int i = 0; i < demos.Length; i++)
                {
                    var demo = demos[i];
                    var index = i;
                    var demoName = demo.GetType().Name;
                    using (Paper.Box(demoName)
                        .Style("demoCard")
                        .OnClick((x) =>
                        {
                            demos[index].Initialize();
                            selectedDemo = index;
                        })
                        .Enter())
                    {
                        demo.DefineStyles();

                        using (Paper.Box(demoName)
                          .Style("demoThumb")
                          .Enter())
                        {
                            demo.RenderThumbnail();
                        }
                        Paper.Box("DemoName").Height(60).Text(Text.Center(demoName, fontMedium, textColor));
                    }
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

        private void DefineStyles()
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
                thumbBackground = Color.FromArgb(255, 200, 200, 200);
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

            Paper.DefineStyle("demoCard")
                .Margin(15)
                .Rounded(10)
                .Height(300)
                .BackgroundColor(cardBackground);

            Paper.DefineStyle("demoGrid")
                .Margin(15)
                .BackgroundColor(backgroundColor);


            Paper.DefineStyle("demoThumb")
                .Margin(8)
                .Rounded(10)
                .BackgroundColor(primaryColor);
        }
    }
}
