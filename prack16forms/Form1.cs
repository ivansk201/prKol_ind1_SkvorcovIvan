using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace prack16forms
{
    public partial class Form1 : Form
    {
        private Queue<Sotrud> allEmployees = new Queue<Sotrud>();
        private Queue<Sotrud> youngEmployees = new Queue<Sotrud>();
        private Queue<Sotrud> oldEmployees = new Queue<Sotrud>();

        public Form1()
        {
            InitializeComponent();
        }

            private void button1_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);

                if (lines.Length == 0)
                {
                    MessageBox.Show("Открываемый файл пуст", "Ошибка");
                    return;
                }
                    Queue<string> youngEmployees = new Queue<string>();
                    Queue<string> otherEmployees = new Queue<string>();

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        int age = int.Parse(parts[4]);
                        if (age < 30)
                        {
                            youngEmployees.Enqueue(line);
                        }
                        else
                        {
                            otherEmployees.Enqueue(line);
                        }
                    }

                    while (youngEmployees.Any())
                    {
                        listBox1.Items.Add(youngEmployees.Dequeue());
                    }

                    while (otherEmployees.Any())
                    {
                        listBox1.Items.Add(otherEmployees.Dequeue());
                    }
                }
            }
        }
    
}

    class Sotrud
    {
        public string lastName;
        public string firstName;
        public string middleName;
        public string gender;
        public int age;
        public decimal salary;

        public override string ToString()
        {
            return string.Format("{0} {1} {2} ({3}), {4} лет, Зарплата {5:C}",
                lastName, firstName, middleName, gender, age, salary);
        }
    }
