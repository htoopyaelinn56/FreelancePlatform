using System.Drawing.Text;
using System.Reflection;

namespace FreelancePlatform.src
{
    public static class FontHelper
    {
        private static PrivateFontCollection? privateFonts;

        public static FontFamily LoadFontFamily(string resourceName)
        {
            if (privateFonts == null)
                privateFonts = new PrivateFontCollection();

            var assembly = Assembly.GetExecutingAssembly();

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            using (Stream fontStream = assembly.GetManifestResourceStream(resourceName))
            {
                if (fontStream == null)
                    throw new Exception($"Font resource '{resourceName}' not found.");

                // Copy font data to memory
                byte[] fontData = new byte[fontStream.Length];
                fontStream.Read(fontData, 0, (int)fontStream.Length);

                unsafe
                {
                    fixed (byte* pFontData = fontData)
                    {
                        privateFonts.AddMemoryFont((nint)pFontData, fontData.Length);
                    }
                }
            }
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            return privateFonts.Families[0];
        }
    }
}
