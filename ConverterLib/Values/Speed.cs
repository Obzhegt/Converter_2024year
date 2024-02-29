using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    internal class Speed : IValue
    {
        /// Наименование единицы измерения
        private string _name = "Скорость";

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
            { "Микрометров",         0.000001 },
            { "Милиметров",          0.001 },
            { "Сантиметров",         0.01 },
            { "Дециметров",          0.1 },
            { "Метров",              1 },
            { "Километров",          1000 }
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
