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
            ButtonBuild.Visible = false;
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
            try
            {
                _builder.ProgramKompasClassParamMethod
                    (_bodyparamsClass);

                _builder.Build(_kompasConnector);
            }
            catch (NullReferenceException)
            {
                KompasCheckBox.Checked = false;

                MessageBox.Show("Необходимо открыть компас");

            }

        }

        private void KompasCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (KompasCheckBox.Checked)
            {
                _kompasConnector.OpenKompas3D();
                ButtonBuild.Visible = true;
            }
            else 
            { 
                _kompasConnector.CloseKompas3D();
                ButtonBuild.Visible = false;
            }

        }

        private void NumberOfHolesTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.NumberOfHoles = Convert.ToInt32(NumberOfHolesTextBox.Value);
            }
            catch (ArgumentException Exception)
            {
                SelectedCloseTextBox
                    (NumberOfHolesTextBox, Exception.Message);
            }
        }


        private void LengthTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.Lenght = Convert.ToInt32(LengthTextBox.Value);
            }
            catch (ArgumentException Exception)
            {
                SelectedCloseTextBox
                      (LengthTextBox,
                     Exception.Message);
            }
        }

        private void WidthTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.Width = Convert.ToInt32(WidthTextBox.Value);
            }
            catch (ArgumentException Exception)
            {
                SelectedCloseTextBox
                      (WidthTextBox,Exception.Message
                     );
            }
        }

        private void HeightTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.Height = Convert.ToInt32(HeightTextBox.Value);
            }
            catch (ArgumentException Exception)
            {
                SelectedCloseTextBox
                      (HeightTextBox, Exception.Message
                     );
            }
        }

        private void PortDiameterTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.PortDiameter = Convert.ToInt32(PortDiameterTextBox.Value);
            }
            catch (ArgumentException Exception)
            {
                SelectedCloseTextBox
                      (PortDiameterTextBox, Exception.Message
                     );
            }
        }

        private void SubDiameterTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.SubDiameter = Convert.ToInt32(SubDiameterTextBox.Value);
            }
            catch (ArgumentException Exception)
            {
                SelectedCloseTextBox
                      (SubDiameterTextBox, Exception.Message
                    );
            }
        }

        private void ThicknessTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bodyparamsClass.Thickness = Convert.ToInt32(ThicknessTextBox.Value);
            }
            catch (ArgumentException Exception)
            {
                SelectedCloseTextBox
                      (ThicknessTextBox, Exception.Message
                );
            }
        }

        /// <summary>
        /// Метод свойства для вывода сообщения и выделение,удаление
        /// в текстбоксе информации
        /// </summary>
        /// <param name="textBox">Текстбокс</param>
        /// <param name="message">Сообщение</param>
        private void SelectedCloseTextBox(NumericUpDown textBox, string message)
        {
            textBox.Select();
            MessageBox.Show(message, "Ошибка",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }
}
