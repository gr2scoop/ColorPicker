using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorPicker
{
    public partial class Form1 : Form
    {
        private Timer colorTimer;
        private TextBox rgbTextBox;
        private TextBox hexTextBox;
        private Button copyHexButton;
        private Panel colorPreview;
        private Color currentColor;

        public Form1()
        {
            InitializeComponent();

            // 폼 설정
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - 270, 800);
            this.Size = new Size(260, 150);
            this.Text = "ColorPicker";

            // RGB 텍스트박스
            rgbTextBox = new TextBox
            {
                Location = new Point(10, 10),
                Width = 230,
                ReadOnly = true
            };
            this.Controls.Add(rgbTextBox);

            // HEX 텍스트박스
            hexTextBox = new TextBox
            {
                Location = new Point(10, 40),
                Width = 160,
                ReadOnly = true
            };
            this.Controls.Add(hexTextBox);

            // [복사] 버튼
            copyHexButton = new Button
            {
                Location = new Point(180, 39),
                Size = new Size(60, 24),
                Text = "복사"
            };
            copyHexButton.Click += CopyHexButton_Click;
            this.Controls.Add(copyHexButton);

            // 색상 미리보기
            colorPreview = new Panel
            {
                Location = new Point(10, 70),
                Size = new Size(40, 30),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(colorPreview);

            // 타이머 설정
            colorTimer = new Timer();
            colorTimer.Interval = 100;
            colorTimer.Tick += ColorTimer_Tick;
            colorTimer.Start();

            // 폼 활성 상태 감지
            this.Activated += (s, e) => colorTimer.Start();
            this.Deactivate += (s, e) => colorTimer.Stop();
        }

        private void ColorTimer_Tick(object sender, EventArgs e)
        {
            Point cursorPos = Cursor.Position;

            using (Bitmap bmp = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(cursorPos, Point.Empty, new Size(1, 1));
                currentColor = bmp.GetPixel(0, 0);
            }

            string rgb = $"RGB: ({currentColor.R}, {currentColor.G}, {currentColor.B})";
            string hex = $"#{currentColor.R:X2}{currentColor.G:X2}{currentColor.B:X2}";

            rgbTextBox.Text = rgb;
            hexTextBox.Text = hex;
            colorPreview.BackColor = currentColor;
        }

        private void CopyHexButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hexTextBox.Text))
            {
                Clipboard.SetText(hexTextBox.Text);
            }
        }
    }
}
