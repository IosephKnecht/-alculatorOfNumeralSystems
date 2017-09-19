using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorSS
{
    class CalculCommand:Command
    {
        char _operator;

        int operand;

        Receiver rec;

        public CalculCommand(Receiver rec, char _operator, int operand)
        {
            this.rec = rec;
            this._operator = _operator;
            this.operand = operand;
        }

        public char Operator
        {
            get { return _operator; }
        }

        public int Operand { get { return operand; } }


        /// <summary>
        /// Выполняем команду...
        /// </summary>
        public void Execute()
        {
            rec.Operation(_operator,operand);
        }

        /// <summary>
        /// Выполняем команду обратную заданной...
        /// </summary>
        public void UnExecute()
        {
            rec.Operation(Undo(_operator),operand);
        }

        /// <summary>
        /// Вспомогательный метод для реверса команды...
        /// </summary>
        /// <param name="operator">Оператор операции...</param>
        /// <returns></returns>
        private char Undo(char @operator)
        {
            char undo;
            switch (@operator)
            {
                case '+': undo = '-'; break;
                case '-': undo = '+'; break;
                case '*': undo = '/'; break;
                case '/': undo = '*'; break;
                default: undo = ' '; break;
            }
            return undo;
        }
    }
}
