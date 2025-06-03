using FontStashSharp;
using System.Drawing;

using Prowl.PaperUI;
using Prowl.Vector;
using System.Reflection;
using Shared.ComponentDemos;

namespace Shared
{
    public class ComponentDemo
    {
        public static FontSystem fontSystem;
        public static SpriteFontBase fontSmall;
        public static SpriteFontBase fontMedium;
        public static SpriteFontBase fontLarge;
        public static SpriteFontBase fontTitle;

        // Track state for interactive elements
        double sliderValue = 0.5f;
        int selectedTabIndex = 0;
        Vector2 chartPosition = new Vector2(0, 0);
        double zoomLevel = 1.0f;
        bool[] toggleState = { true, false, true, false, true };

        // Sample data for visualization
        double[] dataPoints = { 0.2f, 0.5f, 0.3f, 0.8f, 0.4f, 0.7f, 0.6f };
        readonly string[] tabNames = { "Dashboard", "Analytics", "Profile", "Settings", "Windows" };

        //Theme
        public static Color backgroundColor;
        public static Color cardBackground;
        public static Color primaryColor;
        public static Color secondaryColor;
        public static Color textColor;
        public static Color lightTextColor;
        public static Color[] colorPalette;
        bool isDark;

        double time = 0;

        string searchText = "";
        bool searchFocused = false;

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
        }

        public void RenderUI()
        {
            // Update time for animations
            time += 0.016f; // Assuming ~60fps

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

        private void RenderTopNavBar()
        {

        }
        private void RenderSidebar()
        {
        }

        private void RenderMainContent()
        {
            ButtonDemo.Render();
        }

        private void RenderFooter()
        {

        }

        private void ToggleTheme()
        {
            isDark = !isDark;

            if (isDark)
            {
                //Dark
                backgroundColor = Color.FromArgb(255, 18, 18, 23);
                cardBackground = Color.FromArgb(255, 30, 30, 46);
                primaryColor = Color.FromArgb(255, 94, 104, 202);
                secondaryColor = Color.FromArgb(255, 162, 155, 254);
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

            // Redefine styles with new theme colors
            DefineStyles();
        }

        private void DefineStyles()
        {
            // Sidebar styles
            Paper.DefineStyle("sidebar")
                .BackgroundColor(cardBackground)
                .Rounded(8)
                .Width(75);

            // Expanded sidebar
            Paper.DefineStyle("sidebar.expanded")
                .Width(240)
                .BorderColor(primaryColor)
                .BorderWidth(3)
                .Rounded(16);

            // Button
            Paper.DefineStyle("button")
                .Height(40)
                .Rounded(8);

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
    }
}
