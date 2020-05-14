using System;
using System.Windows.Forms;
using KompasAPIModel;
using System.Collections.Generic;


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
        
        /// <summary>
        /// Словарь хранящий текстбоксы и названия параметров
        /// </summary>
        private Dictionary<NumericUpDown,string> _elements = new Dictionary<NumericUpDown, string>();

        public MainForm()
        {
          

            InitializeComponent();
            ButtonBuild.Visible = false;

            _elements.Add(NumberOfHolesTextBox, "NumberOfHoles");
            _elements.Add(SubDiameterTextBox, "SubDiameter");
            _elements.Add(LengthTextBox, "Length");
            _elements.Add(WidthTextBox, "Width");
            _elements.Add(HeightTextBox, "Height");
            _elements.Add(PortDiameterTextBox, "PortDiameter");
            _elements.Add(ThicknessTextBox, "Thickness");

            _bodyparamsClass.NumberOfHoles = 1;
            _bodyparamsClass.SubDiameter = 15;
            UploadDimensions(_bodyparamsClass.SubDiameter);
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

        /// <summary>
        /// Обработчик события при изменении значения текстбокса
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Действие</param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            var textBox = sender as NumericUpDown;
            
            try
            {

                switch (_elements[textBox])
                {
                    case "NumberOfHoles":
                        _bodyparamsClass.NumberOfHoles = Convert.ToInt32(textBox.Value);
                        break;
                    case "SubDiameter":
                        {
                            _bodyparamsClass.SubDiameter = Convert.ToInt32(textBox.Value);
                            UploadDimensions(Convert.ToInt32(textBox.Value));
                        }
                        break;
                    case "Length":
                        _bodyparamsClass.Lenght = Convert.ToInt32(textBox.Value);
                        break;
                    case "Width":
                        _bodyparamsClass.Width = Convert.ToInt32(textBox.Value);
                        break;
                    case "Height":
                        _bodyparamsClass.Height = Convert.ToInt32(textBox.Value);
                        break;
                    case "PortDiameter":
                        _bodyparamsClass.PortDiameter = Convert.ToInt32(textBox.Value);
                        break;
                    case "Thickness":
                        _bodyparamsClass.Thickness = Convert.ToInt32(textBox.Value);
                        break;
                }
                    
            }
            catch (ArgumentException Exception)
            {
                SelectedCloseTextBox
                    (textBox, Exception.Message);
            }
        }

        
       
        /// <summary>
        /// Автоматическая установка значений при стандартных значениях диаметра.
        /// </summary>
        /// <param name="SubDiameter">Диаметр Сабвуфера.</param>
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
                        SetDimensions(85, 44, 46, 20);
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

        private void SetDimensions(int Lenght, int Width, int Height, int PortDiameter)
        {
            _bodyparamsClass.Lenght = Lenght;
            _bodyparamsClass.Width = Width;
            _bodyparamsClass.Height = Height;
            _bodyparamsClass.PortDiameter = PortDiameter;
            LengthTextBox.Value = _bodyparamsClass.Lenght;
            WidthTextBox.Value = _bodyparamsClass.Width;
            HeightTextBox.Value = _bodyparamsClass.Height;
            PortDiameterTextBox.Value = _bodyparamsClass.PortDiameter;
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
