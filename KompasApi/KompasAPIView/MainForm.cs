using System;
using System.Diagnostics;
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
            _bodyparamsClass.Height = 20;
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
                 UploadDimensions(_bodyparamsClass.SubDiameter);
            }
            catch (ArgumentException Exception)
            {
                SelectedCloseTextBox
                      (SubDiameterTextBox, Exception.Message
                    );
            }
        }
        
        private void SetDimensions(int Lenght, int Width, int Hight, int PortDiameter)
        {
            _bodyparamsClass.Lenght = Lenght;
            _bodyparamsClass.Width = Width;
            _bodyparamsClass.Height = Hight;
            _bodyparamsClass.PortDiameter = PortDiameter;
            LengthTextBox.Value = _bodyparamsClass.Lenght;
            WidthTextBox.Value = _bodyparamsClass.Width;
            HeightTextBox.Value = _bodyparamsClass.Height;
            PortDiameterTextBox.Value = _bodyparamsClass.PortDiameter;
        }
        /// <summary>
        /// Автоматическая установка значений при стандартных значениях диаметра.
        /// </summary>
        /// <param name="SubDiameter"></param>
        private void UploadDimensions(int SubDiameter)
        {
            SubDiameter = _bodyparamsClass.SubDiameter;
            switch (SubDiameter)
            {
                case 15:
                    SetDimensions(45,33,20,7);
                    break;
                    case 20:
                        if (_bodyparamsClass.NumberOfHoles == 1)
                        {
                            SetDimensions(50, 36, 27,10);
                        }
                        else SetDimensions(85, 37, 27,10);
                    break;
                case 25:
                    if (_bodyparamsClass.NumberOfHoles == 1)
                    {
                        SetDimensions(65, 37, 30,12);
                    }
                    else SetDimensions(85, 43, 35,12);
                    break;
                case 30:
                    if (_bodyparamsClass.NumberOfHoles == 1)
                    {
                        SetDimensions(80, 38, 36,15);
                    }
                    else SetDimensions(90, 42, 55,15);
                    break;
                case 40:
                    if (_bodyparamsClass.NumberOfHoles == 1)
                    {
                        SetDimensions(91, 55, 53, 22);
                    }
                    break;
                case 45:
                    if (_bodyparamsClass.NumberOfHoles == 1)
                    {
                        SetDimensions(91, 55, 53, 22);
                    }
                    break;
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
