using BicycleApp_Lab6;
using BicycleApp_Lab6.BicycleApp_Lab6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace BicycleApp_Lab6
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            this.Load += fMain_Load; // Переконайтеся, що подія Load прив'язана
        }


        private void fMain_Load(object sender, EventArgs e)
        {
            gvBicycles.AutoGenerateColumns = false;

            // Створюємо і додаємо колонки
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Main";
            column.Name = "Основа";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Brand";
            column.Name = "Марка";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Model";
            column.Name = "Модель";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Type";
            column.Name = "Тип";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Weight";
            column.Name = "Вага (кг)";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Mileage";
            column.Name = "Пробіг (км)";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Gears";
            column.Name = "Кількість передач";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Distance";
            column.Name = "Відстань (км)";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Time";
            column.Name = "Час (год)";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Speed";
            column.Name = "Швидкість (км/год)";
            gvBicycles.Columns.Add(column);

            // Прив'язуємо BindingSource до DataGridView
            gvBicycles.DataSource = bindSrcBicycles;
        }

        

        private void gvBicycles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindSrcBicycles_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (fVehicleType vehicleTypeForm = new fVehicleType())
            {
                if (vehicleTypeForm.ShowDialog() == DialogResult.OK)
                {
                    fBicycle bicycleForm = new fBicycle();
                    if (bicycleForm.ShowDialog() == DialogResult.OK)
                    {
                        Bicycle newBicycle = (Bicycle)bicycleForm.Tag;
                        newBicycle.Main = vehicleTypeForm.SelectedType; // Зберігаємо обраний тип у властивість Main
                        bindSrcBicycles.Add(newBicycle);
                    }
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvBicycles.CurrentRow != null)
            {
                // Отримуємо обраний велосипед
                Bicycle selectedBicycle = (Bicycle)bindSrcBicycles.Current;

                // Відкриваємо форму вибору типу
                using (fVehicleType vehicleTypeForm = new fVehicleType())
                {
                    if (vehicleTypeForm.ShowDialog() == DialogResult.OK)
                    {
                        // Відкриваємо форму для редагування велосипеда з переданими даними
                        fBicycle bicycleForm = new fBicycle(selectedBicycle);
                        if (bicycleForm.ShowDialog() == DialogResult.OK)
                        {
                            // Оновлюємо обраний велосипед новими даними
                            Bicycle updatedBicycle = (Bicycle)bicycleForm.Tag;
                            updatedBicycle.Main = vehicleTypeForm.SelectedType; // Оновлюємо тип

                            // Замінюємо старий об'єкт новим у BindingSource
                            bindSrcBicycles[bindSrcBicycles.Position] = updatedBicycle;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть велосипед для редагування.");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gvBicycles.CurrentRow != null)
            {
                bindSrcBicycles.RemoveCurrent();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть велосипед для видалення.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            bindSrcBicycles.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenFromText_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] values = line.Split('\t');
                            gvBicycles.Rows.Add(values);
                        }
                    }
                }
            }
        }


        private void btnSaveAsText_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (DataGridViewRow row in gvBicycles.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                var cells = row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value?.ToString() ?? "");
                                writer.WriteLine(string.Join("\t", cells));
                            }
                        }
                    }
                }
            }

        }

        private void btnSaveAsBinary_Click(object sender, EventArgs e)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open("filename.bin", FileMode.Create)))
            {
                foreach (DataGridViewRow row in gvBicycles.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            writer.Write(cell.Value?.ToString() ?? "");
                        }
                    }
                }
            }

        }

        private void btnOpenFromBinary_Click(object sender, EventArgs e)
        {
            int columnCount = gvBicycles.ColumnCount; // Отримуємо кількість стовпців у DataGridView

            using (BinaryReader reader = new BinaryReader(File.Open("filename.bin", FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    string[] values = new string[columnCount]; // Масив для збереження значень кожного рядка
                    for (int i = 0; i < columnCount; i++)
                    {
                        values[i] = reader.ReadString();
                    }
                    gvBicycles.Rows.Add(values); // Додаємо прочитаний рядок до таблиці
                }
            }

        }
    }
}
