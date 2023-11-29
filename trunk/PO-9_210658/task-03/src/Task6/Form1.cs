using System.Diagnostics;

namespace Task6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string inputFile = openFileDialog.FileName;
                string outputFile = "g.txt";

                // ������ ����� �� ����� f
                int[] numbers = File.ReadAllText(inputFile)
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();

                // ���������� �����
                int[] evenNumbers = numbers.Where(n => n % 2 == 0).ToArray();
                int[] divisibleBy3NotBy7 = numbers.Where(n => n % 3 == 0 && n % 7 != 0).ToArray();
                int[] perfectSquares = numbers.Where(n => IsPerfectSquare(n)).ToArray();

                // ������ ����������� � ���� g
                File.WriteAllText(outputFile, "�)" + string.Join(", ", evenNumbers) + Environment.NewLine);
                File.AppendAllText(outputFile, "�)" + string.Join(", ", divisibleBy3NotBy7) + Environment.NewLine);
                File.AppendAllText(outputFile, "�)" + string.Join(", ", perfectSquares));

                // ����� ����������� � TextBox
                textBox1.Text = "�)" + string.Join(", ", evenNumbers) + Environment.NewLine;
                textBox1.AppendText("�)" + string.Join(", ", divisibleBy3NotBy7) + Environment.NewLine);
                textBox1.AppendText("�)" + string.Join(", ", perfectSquares));

                MessageBox.Show("���������� �������� � ���� g.txt � �������� � TextBox.");
            }

        }
        private bool IsPerfectSquare(int number)
        {
            double squareRoot = Math.Sqrt(number);
            int roundedSquareRoot = (int)squareRoot;
            return roundedSquareRoot * roundedSquareRoot == number;
        }
    }
}