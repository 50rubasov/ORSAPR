using System;
using System.Windows.Forms;
using KompasAPIModel;
namespace KompasAPIView
{
    public partial class MainForm : Form
    {
        private KompasConnector _kompasConnector = new KompasConnector();

        /// <summary>
        /// Создание объекта для конструирования детали
        /// </summary>
        private Builder _builder =
            new Builder();
        /// <summary>
        /// Создание объекта параметров сабвуфера
        /// </summary>
        private BodyParams _bodyparamsClass =
            new BodyParams();

        public MainForm()
        {
            InitializeComponent();
            _bodyparamsClass.SubDiameter = 15;
            _bodyparamsClass.PortDiameter = 7;
            _bodyparamsClass.NumberOfHoles = 1;
            _bodyparamsClass.Height = 21;
            _bodyparamsClass.Lenght = 45;
            _bodyparamsClass.Width = 33;
            _bodyparamsClass.Thickness = 2;
        }

        private void ButtonBuild_Click(object sender, EventArgs e)
        {

            _builder.ProgramKompasClassParamMethod
                    (_bodyparamsClass);

            _builder.Build(_kompasConnector);

        }

        private void KompasCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (KompasCheckBox.Checked)
            {
                _kompasConnector.OpenKompas3D();
            }
            else 
            { 
                _kompasConnector.CloseKompas3D();
            }

        }

        private void NumberOfHolesTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.NumberOfHoles = Convert.ToInt32(NumberOfHolesTextBox.Value);
            }
            catch (ArgumentOutOfRangeException)
            {
                SelectedCloseTexBox
                      (SubDiameterTextBox,
                     "Вводимое число должно быть в диапазоне от 1 до 2");
            }
        }


        private void LengthTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.Lenght = Convert.ToInt32(LengthTextBox.Value);
            }
            catch (ArgumentOutOfRangeException)
            {
                SelectedCloseTexBox
                      (LengthTextBox,
                     "Вводимое число должно быть больше диаметра сабвуфера*число отверстий+толщина и меньше 90");
            }
        }

        private void WidthTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.Width = Convert.ToInt32(WidthTextBox.Value);
            }
            catch (ArgumentOutOfRangeException)
            {
                SelectedCloseTexBox
                      (WidthTextBox,
                     "Вводимое число должно быть больше диаметра сабвуфера+толщины и меньше длинны короба");
            }
        }

        private void HeightTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.Height = Convert.ToInt32(HeightTextBox.Value);
            }
            catch (ArgumentOutOfRangeException)
            {
                SelectedCloseTexBox
                      (HeightTextBox,
                     "Вводимое число должно быть больше диаметра сабвуфера+толщины и меньше 55ти");
            }
        }

        private void PortDiameterTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.PortDiameter = Convert.ToInt32(PortDiameterTextBox.Value);
            }
            catch (ArgumentOutOfRangeException)
            {
                SelectedCloseTexBox
                      (PortDiameterTextBox,
                     "Вводимое число должно быть больше 1го и меньше половины диаметра сабвуфера");
            }
        }

        private void SubDiameterTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.SubDiameter = Convert.ToInt32(SubDiameterTextBox.Value);
            }
            catch (ArgumentOutOfRangeException)
            {
                SelectedCloseTexBox
                      (SubDiameterTextBox,
                     "Вводимое число должно быть больше 14ти и меньше 45х");
            }
        }

        private void ThicknessTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.Thickness = Convert.ToInt32(ThicknessTextBox.Value);
            }
            catch (ArgumentOutOfRangeException)
            {
                SelectedCloseTexBox
                      (ThicknessTextBox,
                     "Вводимое число должно быть больше 0 и меньше 5ти");
            }
        }

        /// <summary>
        /// Метод свойства для вывода сообщения и выделение,удаление
        /// в текстбоксе информации
        /// </summary>
        /// <param name="textBox">Текстбокс</param>
        /// <param name="message">Сообщение</param>
        private void SelectedCloseTexBox(NumericUpDown textBox, string message)
        {
            MessageBox.Show(message, "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox.Select();
        }
    }
}
