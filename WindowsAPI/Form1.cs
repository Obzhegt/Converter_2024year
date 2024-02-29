using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ConverterLib;



namespace WindowsAPI
{
    public partial class VisualForm : Form
    {
        Manager cm = new Manager();
        public VisualForm()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(cm.Get_list_physic_values().ToArray());
            comboBox1.SelectedIndex = 0;
        }

        /////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Проверка на ввод цифр (Запрет ввода букв)
        /// </summary>
        private void Input_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ///если символ является числом, вернем true
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.')
            {
                return;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                return;
            }

            else
            {
                e.Handled = true;
                Input_textBox.Clear();

            }
        }

        /// <summary>
        /// Проверка на запятые в окне ввода
        /// </summary>
        private void Input_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Input_textBox.Text.Contains("."))
            {
                Input_textBox.Text = Input_textBox.Text.Replace(".", ",");
                Input_textBox.SelectionStart = Input_textBox.Text.Length;
            }

            int commaCount = Input_textBox.Text.Split(',').Length - 1;
            if (commaCount > 1)
            {
                Input_textBox.Text = Input_textBox.Text.Remove(Input_textBox.Text.Length - 1);
                Input_textBox.SelectionStart = Input_textBox.Text.Length;
            }

            if (Input_textBox.Text == ",")
            {
                Input_textBox.Clear();
            }

            //Добавить проверку на 2-а 0-я и более

        }

        /// <summary>
        /// Основа плейсхолдера
        /// </summary>
        private string placeholderText = "Введите число";
        private void Form1_Load(object sender, EventArgs e)
        {
            Input_textBox.Text = placeholderText;
        }

        /// <summary>
        /// Вход в поле ввода (Плейсхолдер)
        /// </summary>
        private void Input_textBox_Enter(object sender, EventArgs e)
        {
            if (Input_textBox.Text == placeholderText)
            {
                Input_textBox.Text = "";
                Input_textBox.ForeColor = Color.White;
            }
        }

        /// <summary>
        /// Выход из поле ввода (Плейсхолдер)
        /// </summary>
        private void Input_textBox_Leave(object sender, EventArgs e)
        {
            if (Input_textBox.Text == "")
            {
                Input_textBox.Text = placeholderText;
                Input_textBox.ForeColor = ColorTranslator.FromHtml("#505050");
            }
        }

        /// <summary>
        /// Проверка на ввод в поле вывода (Запрет менять символы)
        /// </summary>
        private void Output_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Output_textBox.Text.Contains(Output_textBox.Text))
            {
                Output_textBox.ReadOnly = true;

            }
            else
            {
                Output_textBox.ReadOnly = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Sum_Click(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(Input_textBox.Text);
                string valueName = comboBox1.Text;
                string from = comboBox2.Text;
                string to = comboBox3.Text;

                Output_textBox.Text = cm.Get_converted_value(num, valueName, from, to).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(cm.get_spisok_mer(comboBox1.Text).ToArray());
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(cm.get_spisok_mer(comboBox1.Text).ToArray());
            comboBox3.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Output_textBox.Text);
        }

    }
}
