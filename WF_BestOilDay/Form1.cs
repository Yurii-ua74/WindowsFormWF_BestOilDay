namespace WF_BestOilDay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Anime();
        }
        async void Anime()
        {
            while (true)
            {
                for (byte r = 70, g = 130, b = 180; r <= 135 & g <= 205 & b <= 250; r += 2, g += 3, b += 3, await Task.Delay(70))  
                {
                    label1.ForeColor = Color.FromArgb(r, g, b);
                }
                for (byte r = 135, g = 205, b = 250; r >= 70 & g >= 130 & b >= 180; r -= 2, g -= 3, b -= 3, await Task.Delay(70))  
                {
                    label1.ForeColor = Color.FromArgb(r, g, b);
                }
            }
        }      
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form Form2 = new Form2();
            Form2.Show();
            this.Hide();
        }
    }
}