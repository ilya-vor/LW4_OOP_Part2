namespace LW4_OOP_Part2
{
    public partial class Form1 : Form
    {
        private Model model;
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.DataChanged += new EventHandler(update_from_model);
            this.update_from_model(this, null);
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (sender == textBox_A)
                model.A = int.Parse(textBox_A.Text);
            else if (sender == textBox_B)
                model.B = int.Parse(textBox_B.Text);
            else
                model.C = int.Parse(textBox_C.Text);
        }
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (sender == numericUpDown_A)
                model.A = Decimal.ToInt32(numericUpDown_A.Value);
            else if (sender == numericUpDown_B)
                model.B = Decimal.ToInt32(numericUpDown_B.Value);
            else
                model.C = Decimal.ToInt32(numericUpDown_C.Value);
        }
        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            if (sender == trackBar_A)
                model.A = Decimal.ToInt32(trackBar_A.Value);
            else if (sender == trackBar_B)
                model.B = Decimal.ToInt32(trackBar_B.Value);
            else
                model.C = Decimal.ToInt32(trackBar_C.Value);
        }
        public void update_from_model(object sender, EventArgs e)
        {
            textBox_A.Text = model.A.ToString();
            textBox_B.Text = model.B.ToString();
            textBox_C.Text = model.C.ToString();
            numericUpDown_A.Value = model.A;
            numericUpDown_B.Value = model.B;
            numericUpDown_C.Value = model.C;
            trackBar_A.Value = model.A;
            trackBar_B.Value = model.B;
            trackBar_C.Value = model.C;
        }
    }
    class Model
    {
        public System.EventHandler DataChanged;
        private int _A;
        private int _B;
        private int _C;
        public int A
        {
            get{ return _A; }
            set
            {
                selectedValueInRange(ref value);
                if (value > B) _A = B;
                else _A = value;
                DataChanged?.Invoke(this, null);
            }
        }
        public int B
        {
            get
            { return _B; }
            set
            {
                selectedValueInRange(ref value);
                if (value <= C && value >= A) _B = value;
                DataChanged?.Invoke(this, null);
            }
        }
        public int C
        {
            get { return _C; }
            set
            {
                selectedValueInRange(ref value);
                if (value < B) _C = B;
                else _C = value;
                DataChanged?.Invoke(this, null);
            }
        }
        public int selectedValueInRange(ref int value)
        {
            if (value < 0) value = 0;
            else if (value > 100) value = 100;
            return value;
        }
        public Model()
        {
            C = 100; B = 50; A = 10;
        }
    }
}