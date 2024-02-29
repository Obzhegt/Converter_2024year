using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib
{
    internal class Time : IValue
    {
        /// Наименование единицы измерения
        private string _name = "Время";

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
            { "Милисекунды",    0.001 },
            { "Секунды",        1 },
            { "Минуты",         60 },
            { "Часы",           60*60 }
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
