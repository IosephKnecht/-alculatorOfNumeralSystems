using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorSS
{
    class Receiver
    {
        /// <summary>
        /// Хранимый результат...
        /// </summary>
        private int curr;

        static Receiver rec;

        protected Receiver() { }

        /// <summary>
        /// Метод реализующий мат.логику...
        /// </summary>
        /// <param name="_operator">Оператор...</param>
        /// <param name="operand">Операнд...</param>
        public void Operation(char _operator, int operand)
        {
            switch (_operator)
            {
                case '+': curr += operand; break;
                case '-': curr -= operand; break;
                case '*': curr *= operand; break;
                case '/': curr /= operand; break;
            }
            
        }

        /// <summary>
        /// Паттерн Jesus во все поля...
        /// </summary>
        /// <returns></returns>
        public static Receiver Instance()
        {
            if (rec == null)
            {
                return rec = new Receiver();
            }

            return rec;
        }

        /// <summary>
        /// Свойство возвращающее результат...
        /// </summary>
        public int Current { get { return curr; } }

    }
}
