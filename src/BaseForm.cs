using FreelancePlatform.src;

namespace FreelancePlatform
{
    public partial class BaseForm : Form
    {
        public static Font GlobalFont;
        static BaseForm()
        {
            var fontFamily = FontHelper.LoadFontFamily("FreelancePlatform.src.JetBrainsMono-Medium.ttf");
            GlobalFont = new Font(fontFamily, 10f, FontStyle.Regular);
        }

        public BaseForm()
        {
            InitializeComponent();
            ApplyFontRecursively(this, GlobalFont);
        }

        private void ApplyFontRecursively(Control control, Font font)
        {
            control.Font = font;
            foreach (Control child in control.Controls)
                ApplyFontRecursively(child, font);
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
