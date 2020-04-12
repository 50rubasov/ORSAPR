using System;
namespace KompasAPIModel
{
    /// <summary>
    /// Класс, хранящий параметры объекта.
    /// </summary>
    public class BodyParams
    {
        /// <summary>
        /// Высота.
        /// </summary>
        private int _height;
        /// <summary>
        /// Длинна.
        /// </summary>
        private int _length;
        /// <summary>
        /// Ширина.
        /// </summary>
        private int _width;
        /// <summary>
        /// Количество отверстий сабвуфера.
        /// </summary>
        private int _numberOfHoles;
        /// <summary>
        /// Диаметр порта.
        /// </summary>
        private int _portDiameter;
        /// <summary>
        /// Диаметр Сабвуфера.
        /// </summary>
        private int _subDiameter;
        /// <summary>
        /// Толищина материала.
        /// </summary>
        private int _thickness;

        /// <summary>
        /// Свойство для высоты.
        /// </summary>


        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value < SubDiameter+Thickness|| value > 55)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _height = value;
            }
        }
        public int SubDiameter
        {
            get
            {
                return _subDiameter;
            }
            set
            {
                if (value < 15 || value > 45)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _subDiameter = value;
            }
        }
        public int NumberOfHoles
        {
            get
            {
                return _numberOfHoles;
            }
            set
            {
                if (value < 1 || value > 2)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _numberOfHoles = value;
            }
        }

        public int Lenght
        {
            get
            {
                return _length;
            }
            set
            {
                if (value < NumberOfHoles*SubDiameter+Thickness || value > 90)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _length = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value < SubDiameter+Thickness || value > Lenght)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _width = value;
            }
        }

        public int Thickness
        {
            get
            {
                return _thickness;
            }
            set
            {
                if (value < 2 || value > 4)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _thickness = value;
            }
        }
        public int PortDiameter
        {
            get
            {
                return _portDiameter;
            }
            set
            {
                if (value < 4 || value > SubDiameter/2)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _portDiameter = value;
            }
        }
    }
}
