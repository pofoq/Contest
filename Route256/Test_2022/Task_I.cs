﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Codeforces.Contest
{
    public class Task_I
    {

    }
}
/*
 I. Отображение страниц (40 баллов)
ограничение по времени на тест10 секунд
ограничение по памяти на тест512 мегабайт
вводстандартный ввод
выводстандартный вывод
В этой задаче вам предстоит написать отображение в текстовом виде простейших HTML-таблиц.

В задаче используется очень ограниченное подмножество HTML-разметки. Внимательно прочтите условие задачи.

В этой задаче все таблицы имеют строго прямоугольный вид, то есть содержат не менее одной строки, каждая строка содержит не менее одной ячейки, и во всех строках каждой отдельной таблицы одинаковое количество ячеек.

Таблица описывается следующей грамматикой:

⟨TABLE⟩ := <table>⟨ROWS⟩</table>
⟨ROWS⟩ := ⟨ROW⟩|⟨ROW⟩⟨ROWS⟩
⟨ROW⟩ := <tr>⟨CELLS⟩</tr>
⟨CELLS⟩ := ⟨CELL⟩|⟨CELL⟩⟨CELLS⟩
⟨CELL⟩ := <td></td>|<td>⟨TABLE⟩</td>
Таким образом, каждая ячейка таблицы либо пуста, либо содержит ровно одну другую таблицу.

Вот пример минимальной корректной таблицы: <table><tr><td></td></tr></table>.

Вот пример минимальной корректной таблицы размера 2×3: <table><tr><td></td><td></td><td></td></tr><tr><td></td><td></td><td></td></tr></table>.

Вот пример таблицы 2×1, в нижнюю клетку которой вложена минимальная таблица: <table><tr><td></td></tr><tr><td><table><tr><td></td></tr></table></td></tr></table>.

Ваша задача — отобразить заданную таблицу в текстовом виде. Каждая из таблиц (как внешняя, так и любая внутренняя) должна занимать минимальную площадь. Содержимое любой ячейки прижимается к её левому верхнему углу.

Изучите примеры и точно следуйте всем особенностям форматирования, которые продемонстрированы в них. В этой задаче вам нужно вывести в точности ожидаемое представление таблицы — не выводите лишние незначащие пробелы или какие-либо другие символы.

Входные данные
В первой строке теста записано целое число t (1≤t≤100) — количество наборов входных данных в тесте.

Далее следуют описания наборов. Наборы входных данных в тесте независимы. Друг на друга они никак не влияют.

Каждый набор начинается строкой, которая содержит целое число k (1≤k≤1000) — количество строк, в которых записан очередной набор.

Далее следуют k строк, в которых записано описание ровно одной таблицы. Описание произвольным образом разбито на k строк и отформатировано пробелами, которые следует полностью игнорировать. Пробелы могут даже разрывать ключевые слова в HTML-разметке.

Каждая таблица (и внешняя, и все вложенные) соответствует грамматике выше и имеет строго прямоугольную форму: количества ячеек в каждой строке равны в рамках каждой отдельной таблицы.

Размер файла каждого теста не превосходит 1 мегабайта. Глубина вложенности таблиц не превосходит 10. Гарантируется, что размер вывода для любого теста не превосходит 1 мегабайта.

Выходные данные
Выведите t заданных таблиц, следуя примерам. Каждая таблица должна занимать минимальную возможную площадь. Содержимое любой ячейки прижимается к её левому верхнему углу.

Точно следуйте примерам, они демонстрируют все особенности и требования форматирования вывода.

Гарантируется, что размер вывода для любого теста не превосходит 1 мегабайта.

Пример
входные данныеСкопировать
4
5
<table>
    <tr>
        <td></td>
    </tr>
</table>
4
<table>
    <tr><td></td><td></td><td></td></tr>
    <tr><td></td><td></td><td></td></tr>
</table>
5
<t                      a
ble><tr><td></td></tr><tr
><td><table><tr><td></td>
</tr></table></td></tr></
table                   >
35
<table>
    <tr>
        <td>
        </td>
        <td>
            <table>
                <tr><td>
                    <table><tr><td></td></tr></table>
                </td></tr>
            </table>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <table><tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr></table>
        </td>
        <td>
            <table><tr><td></td></tr></table>
        </td>
        <td>
            <table>
                <tr><td></td></tr>
                <tr><td></td></tr>
                <tr><td></td></tr>
            </table>
        </td>
    </tr>
</table>
выходные данныеСкопировать
+-+
|.|
+-+
+-+-+-+
|.|.|.|
+-+-+-+
|.|.|.|
+-+-+-+
+---+
|...|
+---+
|+-+|
||.||
|+-+|
+---+
+---------+-----+---+
|.........|+---+|...|
|.........||+-+||...|
|.........|||.|||...|
|.........||+-+||...|
|.........|+---+|...|
+---------+-----+---+
|+-+-+-+-+|+-+..|+-+|
||.|.|.|.|||.|..||.||
|+-+-+-+-+|+-+..|+-+|
|.........|.....||.||
|.........|.....|+-+|
|.........|.....||.||
|.........|.....|+-+|
+---------+-----+---+

 */