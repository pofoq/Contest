using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Codeforces.Contest_2023_04
{
    public class Task_E
    {
        public static void MainE(string[] args)
        {
            var testCaseCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < testCaseCount; i++)
            {
                var terminal = new Terminal();
                var str = Console.ReadLine();
                for (int j = 0; j < str.Length; j++)
                {
                    terminal.ApplyCommand(str[j]);
                }
                terminal.Print();
            }
        }
    }

    public class Terminal
    {
        public Cursor Cursor { get; }
        private List<StringBuilder> _lines;

        public Terminal()
        {
            Cursor = new Cursor();
            _lines = new List<StringBuilder>() { new StringBuilder("", 50) };
        }

        public void ApplyCommand(char ch)
        {
            switch (ch)
            {
                case 'L':
                    if (Cursor.Column > 0)
                        Cursor.Column--;
                    break;
                case 'R':
                    if (Cursor.Column < _lines[Cursor.Line].Length)
                        Cursor.Column++;
                    break;
                case 'U':
                    if (Cursor.Line > 0)
                    {
                        Cursor.Line--;
                        CheckColumn();
                    }
                    break;
                case 'D':
                    if (Cursor.Line < _lines.Count - 1)
                    {
                        Cursor.Line++;
                        CheckColumn();
                    }
                    break;
                case 'B':
                    Cursor.Column = 0;
                    break;
                case 'E':
                    Cursor.Column = _lines[Cursor.Line].Length;
                    break;
                case 'N':
                    var str = "";
                    if (Cursor.Column < _lines[Cursor.Line].Length)
                    {
                        str = _lines[Cursor.Line].ToString().Substring(Cursor.Column);
                        _lines[Cursor.Line].Remove(Cursor.Column, str.Length);
                    }
                    Cursor.Line++;
                    _lines.Insert(Cursor.Line, new StringBuilder(str, 50));
                    Cursor.Column = 0;
                    break;
                default:
                    _lines[Cursor.Line].Insert(Cursor.Column, ch);
                    Cursor.Column++;
                    break;
            }
        }

        public void Print()
        {
            foreach (var line in _lines)
                Console.WriteLine(line.ToString());
            Console.WriteLine('-');
        }

        private void CheckColumn()
        {
            if (Cursor.Column > _lines[Cursor.Line].Length)
                Cursor.Column = _lines[Cursor.Line].Length;
        }
    }

    public class Cursor
    {
        public int Column { get; set; } = 0;
        public int Line { get; set; } = 0;

        public Cursor()
        {

        }
    }
}
/*
 E. Терминал (15 баллов)
ограничение по времени на тест2 секунды
ограничение по памяти на тест512 мегабайт
вводстандартный ввод
выводстандартный вывод
Реализуйте элемент функциональности простейшего терминала.

Изначально терминал содержит одну пустую строку, в начале которой находится курсор.

Ваша программа должна уметь обрабатывать последовательность символов (строку ввода). Обработка символа зависит от его значения:

Строчная буква латинского алфавита или цифра обозначает, что соответствующий символ вставляется в положение курсора. Курсор сдвигается на позицию после вставленного символа.
Буквы L и R обозначают нажатия стрелок влево и вправо. Они перемещают курсор на одну позицию влево или вправо. Если в соответствующем направлении нет символа, то операция игнорируется. Заметьте, что курсор в любом случае остаётся в той же строке.
Буквы U и D обозначают нажатия стрелок вверх и вниз. Они перемещают курсор на одну позицию вверх или вниз. Если в соответствующем направлении нет строки, то операция игнорируется. Если строка есть, но в ней нужная позиция не существует, то курсор встаёт в конец строки.
Буквы B и E обозначают нажатия клавиш Home и End. Они перемещают курсор в начало или в конец текущей строки.
Буква N обозначает нажатие клавиши Enter — происходит вставка новой строки. Если курсор находился не в конце текущей строки, то она разрывается, и часть после курсора переносится в новую строку. Курсор после этой операции стоит в начале новой строки.
Вы можете представлять себе, что эмулируете последовательность нажатий в простейшем текстовом редакторе, в котором курсор занимает позицию между двумя символами строки (или находится в начале или конце строки).

Например, если строка ввода имеет вид otLLLrRuEe256LLLN, то в результате получится две строки:

route
256
Промоделируйте последовательность действий и выведите результат.

Входные данные
В первой строке входных данных записано целое число t
 (1≤t≤100
) — количество наборов входных данных.

Наборы входных данных в тесте независимы. Друг на друга они никак не влияют.

Каждый набор входных данных состоит из одной непустой строки — последовательности символов для обработки. Гарантируется, что длина этой строки не превосходит 50
. Допустимые символы в строке — строчные буквы латинского алфавита, цифры и буквы L, R, U, D, B, E, N.

Выходные данные
Для каждого набора входных данных выведите итоговую последовательность строк. Выводите все строки, включая пустые. После каждого набора выходных данных выведите дополнительную строку с единственным символом - (минус).

Пример
входные данныеСкопировать
4
otLLLrRuEe256LLLN
LRLUUDE
itisatest
abNcdLLLeUfNxNx
выходные данныеСкопировать
route
256
-

-
itisatest
-
af
x
xb
ecd
-

 */