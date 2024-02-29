using ConverterLib.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib
{
    public class Manager
    {
        public Manager()
        {
            SetValuesList();
        }

        private static List<IValue> _physicValuesList = new List<IValue>();

        /// <summary>
        /// Загрузка и добавление классов
        /// </summary>
        public static void SetValuesList()
        {
            Assembly asm = Assembly.LoadFrom("ConverterLib.dll");           // создание сборки из библиотеки классов
            Type[] types = asm.GetTypes();                                  // выгрузка классов в массив
            foreach (Type type in types)                                    // перебираем классы и интерфейсы
            {
                if ((type.IsInterface == false)
                    && (type.IsAbstract == false)
                    && (type.Name != ("AnyValue"))                          // добавил, чтобы исключить базовый класс
                    && (type.GetInterface("IValue") != null))               // не добавляем абстрактные классы и интерфейсы
                {
                    IValue value = (IValue)Activator.CreateInstance(type);
                    _physicValuesList.Add(value);                           // подгружаем этот класс в писок величин                        
                }
            }
        }

        /// <summary>
        /// Метод для получения названий физ.величин из загруженных классов
        /// </summary>
        public List<string> Get_list_physic_values()
        {
            List<string> values = new List<string>();

            foreach (var value in _physicValuesList)
            {
                values.Add(value.Get_name());
            }
            return values;
        }


        /// Поле для хранения выбранной физической величины
        private IValue _value;


        /// <summary>
        /// Выбранная физ.величина на основе её названия
        /// </summary>
        private void SetIValue(string physicValue)
        {
            foreach (var value in _physicValuesList)
            {
                if (value.Get_name() == physicValue)
                {
                    _value = value;
                }
            }
        }

        /// <summary>
        /// Возвращени списка доступных единиц измерения для выбранной величины
        /// </summary>
        public List<string> get_spisok_mer(string physicValue)
        {
            SetIValue(physicValue);
            List<string> measures = new List<string>();

            foreach (var i in _value.Get_coef_dict())
            {
                measures.Add(i.Key);
            }
            return measures;
        }

        /// <summary>
        /// Метод для конвертации значения из одной единицы измерения в другую
        /// </summary>
        public double Get_converted_value(double num, string valueName, string from, string to)
        {
            SetIValue(valueName);
            num *= _value.Get_coef_dict()[from];
            num /= _value.Get_coef_dict()[to];
            return num;
        }
    }
}