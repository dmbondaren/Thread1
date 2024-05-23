using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace ptotoku
{
    public partial class Form1 : Form
    {
        private Thread button1Thread;
        private Thread button2Thread;
        private List<string> keyLogs = new List<string>();

        public Form1()
        {
            InitializeComponent();

            // Створення і запуск потоків
            button1Thread = new Thread(MoveButton1);
            button2Thread = new Thread(MoveButton2);

            button1Thread.SetApartmentState(ApartmentState.STA);
            button2Thread.SetApartmentState(ApartmentState.STA);

            button1Thread.Start();
            button2Thread.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Завершення потоків при закритті форми
            button1Thread.Abort();
            button2Thread.Abort();
        }

        private void MoveButton1()
        {
            while (true)
            {
                if (Keyboard.IsKeyDown(Key.W))
                {
                    Invoke(new Action(() => button1.Top -= 1));
                    keyLogs.Add("W");
                }
                if (Keyboard.IsKeyDown(Key.S))
                {
                    Invoke(new Action(() => button1.Top += 1));
                    keyLogs.Add("S");
                }
                if (Keyboard.IsKeyDown(Key.A))
                {
                    Invoke(new Action(() => button1.Left -= 1));
                    keyLogs.Add("A");
                }
                if (Keyboard.IsKeyDown(Key.D))
                {
                    Invoke(new Action(() => button1.Left += 1));
                    keyLogs.Add("D");
                }
                Thread.Sleep(50); // Delay for controlling speed
            }
        }

        private void MoveButton2()
        {
            while (true)
            {
                if (Keyboard.IsKeyDown(Key.Up))
                {
                    Invoke(new Action(() => button2.Top -= 1));
                    keyLogs.Add("Up");
                }
                if (Keyboard.IsKeyDown(Key.Down))
                {
                    Invoke(new Action(() => button2.Top += 1));
                    keyLogs.Add("Down");
                }
                if (Keyboard.IsKeyDown(Key.Left))
                {
                    Invoke(new Action(() => button2.Left -= 1));
                    keyLogs.Add("Left");
                }
                if (Keyboard.IsKeyDown(Key.Right))
                {
                    Invoke(new Action(() => button2.Left += 1));
                    keyLogs.Add("Right");
                }
                Thread.Sleep(50); // Delay for controlling speed
            }
        }
}

}
