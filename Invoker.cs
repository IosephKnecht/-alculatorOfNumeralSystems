using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorSS
{
    class Invoker
    {
        /// <summary>
        /// Экземпляр класса реалиизующего всю мат.логику...
        /// </summary>
        private Receiver _calculator = Receiver.Instance();
        /// <summary>
        /// Лист команд...
        /// </summary>
        private List<Command> _commands = new List<Command>();

        private int _current = 0;

        /// <summary>
        ///Логическая переменная проверяющая был ли ввод данных первым...
        /// </summary>
        private bool status = true;

        /// <summary>
        /// На сколько уровней "вверх" идем...
        /// </summary>
        /// <param name="levels">Кол-во уровней...</param>
        public void Redo(int levels)
        {
            for (int i = 0; i < levels; i++)
                if (_current < _commands.Count - 1)
                    _commands[_current++].Execute();
        }

        /// <summary>
        /// На сколько уровней "вниз" идем..
        /// </summary>
        /// <param name="levels">Кол-во уровней...</param>
        public void Undo(int levels)
        {

            for (int i = 0; i < levels; i++)
                if (_current > 0)
                    _commands[--_current].UnExecute();
            if (_current == 0) status = true;
        }

        /// <summary>
        /// Создаем команду,что бы отправить на Receiver;
        /// </summary>
        /// <param name="operator">Знак операции...</param>
        /// <param name="operand">Операнд...</param>
        public void Compute(char @operator, int operand)
        {

            Command command;
            if (status)
            {
                command = new CalculCommand(
                              _calculator, '+', operand);
                command.Execute();
                status = false;
            }
            else
            {
                command = new CalculCommand(
                  _calculator, @operator, operand);
                command.Execute();
            }

            _commands.Add(command);
            _current++;
        }

    }
}
