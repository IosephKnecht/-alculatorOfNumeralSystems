using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalculatorSS
{
    public partial class MainView : Form
    {
        /// <summary>
        /// Экземпляр класса инициатора...
        /// </summary>
        private Invoker inv;

        public MainView()
        {
            InitializeComponent();
            inv = new Invoker();
        }

        /// <summary>
        /// Вообще не помню,чтобы такое писал,но возможно это что-то важное...
        /// </summary>
        /// <param name="result"></param>
        private void leftResult(string result)
        {
            storyBox.Items.Add(result);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Единый метод для всех кнопок с функцией ввода...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            noteBox.Text += button.Text;
        }

        /// <summary>
        /// Так делать плохо,но все же это единый метод для все знаков...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plusButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            TransView form = new TransView(noteBox.Text);

            form.ShowDialog();

            string digit = form.Conv_out;

            form.Dispose();

            try
            {
                storyBox.Items.Add(Receiver.Instance().Current + button.Text + digit);
                inv.Compute(Convert.ToChar((button.Text)), Convert.ToInt32(digit));
            }
            catch
            {
                storyBox.Items.Add(Receiver.Instance().Current + button.Text + "0");
                inv.Compute(Convert.ToChar((button.Text)),0);
            }

            ResultView form1 = new ResultView(Receiver.Instance().Current.ToString());
            form1.ShowDialog();

            string conv_result = form1.Conv_out;

            form1.Dispose();

            storyBox.Items[storyBox.Items.Count - 1] += "=" + conv_result;
            noteBox.Clear();
        }

        
        private void currentResult(string result)
        {
            noteBox.Text = result;
        }

        /// <summary>
        /// Команды отмены....
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoButton_Click(object sender, EventArgs e)
        {
            inv.Undo(1);
            
        }

        /// <summary>
        /// Команда вперед...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redoButton_Click(object sender, EventArgs e)
        {
            inv.Redo(1);
        }
    }
}
