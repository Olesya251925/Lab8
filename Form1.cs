using System;
using System.Windows.Forms;

namespace FileSyncApp
{
    public partial class Form1 : Form, IFileSyncView
    {
        public event EventHandler SyncRequested;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Подписываемся на событие нажатия кнопки
            syncButton.Click += syncButton_Click;
        }

        private void syncButton_Click(object sender, EventArgs e)
        {
            // Вызываем событие синхронизации
            SyncRequested?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayStatus(string status)
        {
            // Отображаем информацию в текстовом поле
            statusTextBox.AppendText(status + Environment.NewLine);
        }
    }
}



