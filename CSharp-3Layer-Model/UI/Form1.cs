namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // יצירת מופע של המסך החדש
            FromManagerMenu menu = new FromManagerMenu();
            // הצגת המסך
            menu.Show();
            // (אופציונלי) הסתרת המסך הנוכחי
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
