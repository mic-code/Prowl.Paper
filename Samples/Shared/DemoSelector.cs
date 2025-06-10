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
        public static FontSystem fontSystem;
        public static SpriteFontBase fontSmall;
        public static SpriteFontBase fontMedium;
        public static SpriteFontBase fontLarge;
        public static SpriteFontBase fontTitle;

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

        static IDemoThumbnail[] demos;

        public static double time = 0;

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
            using (Paper.Column("MainContent")
            .Style("mainContent")
            .Transition(GuiProp.Width, 0.25f, Paper.Easing.EaseIn)
            .Transition(GuiProp.BorderColor, 0.75f)
            .Transition(GuiProp.BorderWidth, 0.75f)
            .Transition(GuiProp.Rounded, 0.25f)
            .Margin(15)
            .Enter())
            {
                foreach (var demo in demos)
                {
                    Paper.Box("Header").Height(60).Text(Text.Center(demo.GetType().Name, fontMedium, textColor));
                    demo.DefineStyles();
                    demo.RenderThumbnail();
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
        }
    }
}
