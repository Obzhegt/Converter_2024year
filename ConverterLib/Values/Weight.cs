using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    internal class Weight : IValue
    {
        /// Наименование единицы измерения
        private string _name = "Масса";

        /// <summary>
        /// Возвращание названия единицы измерения
        /// </summary>
        public string Get_name()
        {
            return _name;
        }

        /// <summary>
        /// Коэффициенты конвертации для единицы измерения
        /// </summary>
        private Dictionary<string, double> _coefList = new Dictionary<string, double>()
        {
            { "Граммы",         0.001 },
            { "Килограммы",     1 },
            { "Центнеры",       100 },
            { "Тонны",          1000 }
        };

        /// <summary>
        /// Возвращение листа коэффицентов
        /// </summary>
        public Dictionary<string, double> Get_coef_dict()
        {
            return _coefList;
        }
    }
}
