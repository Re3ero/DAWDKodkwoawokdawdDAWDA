using System;
using System.Windows.Forms;

namespace Password_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt",
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            ManagerParole.LocatieFisier = openFileDialog.FileName;
            MainPasswordForm PasswordForm = new MainPasswordForm
            {
                title = "Ввод пароля"
            };
            PasswordForm.ShowDialog();

            if (ManagerParole.MainPassword.Length == 0)
                return;

            if (ManagerParole.CitesteConturi(ManagerParole.LocatieFisier, ManagerParole.MainPassword))
            {
                this.Close();
                Program.CorrectPassword = true;
            }
            else
            {
                MessageBox.Show("Password is wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void Create_Click(object sender, EventArgs e)
        {
            MainPasswordForm PasswordForm = new MainPasswordForm
            {
                title = "Создание пароля"
            };
            PasswordForm.ShowDialog();

            if (ManagerParole.MainPassword.Length == 0)
                return;

            ManagerParole.AdaugaExemple(1);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt",
                DefaultExt = ManagerParole.Extensie,
                AddExtension = true,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                ManagerParole.SalveazaParolele(saveFileDialog.FileName, ManagerParole.MainPassword);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Select();
        }
    }
}
