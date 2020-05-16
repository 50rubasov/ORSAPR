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
        /// Устанавливает и возвращает значение высоты
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
              
                if (value < SubDiameter+2*Thickness|| value > 55)
                {
                    throw new ArgumentException("Вводимое число должно быть больше диаметра сабвуфера+толщина*2 и меньше 55ти");
                }
                _height = value;
            }
        }

        /// <summary>
        /// Устанавливает и возвращает значение диаметра сабвуфера.
        /// </summary>
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
                    throw new ArgumentException("Вводимое число должно быть больше 14ти и меньше 45х");
                }
                _subDiameter = value;
            }
        }

        /// <summary>
        /// Устанавливает и возвращает количество отверстий сабвуфера.
        /// </summary>
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
                    throw new ArgumentException("Вводимое число должно быть в диапазоне от 1 до 2");
                }
                _numberOfHoles = value;
            }
        }
        /// <summary>
        /// Устанавливает и возвращает значение длинны.
        /// </summary>
        public int Lenght
        {
            get
            {
                return _length;
            }
            set
            {
                if (value < NumberOfHoles*SubDiameter+ 2 * Thickness || value > 106)
                {
                    throw new ArgumentException("Вводимое число должно быть в диапазоне ОТ кол. отверстий * диаметр саб. + 2 толщины ДО 106");
                    
                }
                _length = value;
            }
        }
        /// <summary>
        /// Устанавливает и возвращает значение ширины короба
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value < SubDiameter + 2 * Thickness || value > Lenght  )
                {
                    throw new ArgumentException("Вводимое число должно быть больше диаметра сабвуфера+толщина*2 и меньше длинны короба");
                }
                _width = value;
            }
        }
        /// <summary>
        /// Устанавливает и возвращает значение толщины короба
        /// </summary>
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
                    throw new ArgumentException("Вводимое число должно быть больше 2 и меньше 5ти");
                }
                _thickness = value;
            }
        }

        /// <summary>
        /// Устанавливает и возвращает значение диаметра порта.
        /// </summary>
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
                    throw new ArgumentException("Вводимое число должно быть больше 4х и меньше половины диаметра сабвуфера");
                }
                _portDiameter = value;
            }
        }
    }
}
