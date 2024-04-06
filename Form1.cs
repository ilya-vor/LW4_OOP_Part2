namespace LW4_OOP_Part2
{
    public partial class Form1 : Form
    {
        private Model model;
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.observers += new EventHandler(update_from_model);
            this.update_from_model(this, null);
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            int previous_number = model.getB();
            if (sender == textBox_A)
                model.setA(int.Parse(textBox_A.Text));
            else if (sender == textBox_B)
                model.setB(int.Parse(textBox_B.Text), previous_number);
            else
                model.setC(int.Parse(textBox_C.Text));
        }
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int previous_number = model.getB();
            if (sender == numericUpDown_A)
                model.setA(Decimal.ToInt32(numericUpDown_A.Value));
            else if (sender == numericUpDown_B)
                model.setB(Decimal.ToInt32(numericUpDown_B.Value), previous_number);
            else
                model.setC(Decimal.ToInt32(numericUpDown_C.Value));
        }
        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            int previous_number = model.getB();
            if (sender == trackBar_A)
                model.setA(Decimal.ToInt32(trackBar_A.Value));
            else if (sender == trackBar_B)
                model.setB(Decimal.ToInt32(trackBar_B.Value), previous_number);
            else
                model.setC(Decimal.ToInt32(trackBar_C.Value));
        }
        public void update_from_model(object sender, EventArgs e)
        {
            textBox_A.Text = model.getA().ToString();
            textBox_B.Text = model.getB().ToString();
            textBox_C.Text = model.getC().ToString();
            numericUpDown_A.Value = model.getA();
            numericUpDown_B.Value = model.getB();
            numericUpDown_C.Value = model.getC();
            trackBar_A.Value = model.getA();
            trackBar_B.Value = model.getB();
            trackBar_C.Value = model.getC();
        }
    }
    class Model
    {
        private int A;
        private int B;
        private int C;
        public System.EventHandler observers;
        public int selectedValueInRange(ref int value)
        {
            if (value < 0) value = 0;
            else if (value > 100) value = 100;
            return value;
        }
        public Model()
        {
            A = 10; B = 50; C = 100;
        }
        public void setA(int value)
        {
            selectedValueInRange(ref value);
            if (value > B) A = B;
            else A = value;
            observers.Invoke(this, null);
        }
        public void setC(int value)
        {
            selectedValueInRange(ref value);
            if (value < B) C = B;
            else C = value;
            observers.Invoke(this, null);
        }
        public void setB(int value, int previous_number)
        {
            selectedValueInRange(ref value);
            if (value > C || value < A) B = previous_number;
            else B = value;
            observers.Invoke(this, null);
        }
        public int getA() { return A; }
        public int getB() { return B; }
        public int getC() { return C; }
    }
}