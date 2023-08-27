﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route256.Test_2023_08
{
    internal class TaskG
    {
    }
}
/*
 G. 3-Покер (25 баллов)
ограничение по времени на тест1 секунда
ограничение по памяти на тест256 мегабайт
вводстандартный ввод
выводстандартный вывод
Колода состоит из 52 карт. Каждая карта обозначается одним из тринадцати значений (2, 3, 4, 5, 6, 7, 8, 9, Ten, Jack, Queen, King, Ace) и одной из четырех мастей (Spades, Clubs, Diamonds, Hearts).

Выдуманная игра 3-Покер происходит следующим образом.

Изначально все n
 игроков получают по две карты из колоды.
После этого на стол выкладывается одна карта из той же колоды.
Выигрывают те игроки, у которых собралась самая старшая комбинация.
Для определения самой старшей комбинации, которая собралась у i
-го игрока, используются следующие правила:

если две карты у игрока в руке и карта на столе имеют одинаковое значение, игрок собрал комбинацию 'Сет со значением x
';
если из двух карт у игрока в руке и карты на столе можно выбрать две карты с одинаковым значением x
, игрок собрал комбинацию 'Пара со значением x
';
иначе, берется карта с самым старшим значением из двух карт у игрока в руке и карты на столе, тогда игрок собрал комбинацию 'Старшая карта x
'.
Любой сет старше пары, а любая пара старше комбинации старшая карта. Из одинаковых комбинаций старше та, у которой старше значение. Если одинаковая самая старшая комбинация есть у нескольких игроков, все они объявляются выигрывшими.

Вы — первый игрок. Вам известно, какие карты получил на руки каждый игрок. Определите, какую карту можно выложить на стол, чтобы вы оказались в числе победителей.

Входные данные
Каждый тест состоит из нескольких наборов входных данных. Первая строка содержит целое число t
 (1≤t≤103
) — количество наборов входных данных. Далее следует описание наборов входных данных.

Первая строка каждого набора входных данных содержит целое число n
 (2≤n≤25
) — количество игроков.

Следующие n
 строк каждого набора входных данных содержат описания двух карт, разделенных пробелом — карты, которые получил на руки i
-й игрок.

Описание карты состоит из двух символов, записанных подряд: значения и масти.

Выходные данные
Для каждого набора входных данных выведите в первой строке количество карт k
, которые можно выложить на стол для вашей победы. В следующих k
 строках выведите описания этих карт. Выводить описания можно в любом порядке.

Примеры
входные данныеСкопировать
4
2
TS TC
AD AH
3
2H 3H
9S 9C
4D QS
3
4C 7H
4H 4D
6S 6H
3
2S 3H
2C 2D
3C 3D
выходные данныеСкопировать
2
TD
TH
0
3
7S
7C
7D
0
входные данныеСкопировать
1
7
AS AC
AD AH
KS JH
9D 9C
5H 5D
3C 3S
TC TH
выходные данныеСкопировать
30
2S
2C
2D
2H
4S
4C
4D
4H
6S
6C
6D
6H
7S
7C
7D
7H
8S
8C
8D
8H
JS
JC
JD
QS
QC
QD
QH
KC
KD
KH
Примечание
Разберем первый пример.

В первом наборе входных данных для победы первого игрока можно выложить на стол десятку (T), тогда первый игрок выиграет с комбинацией сет со значением T.

Во втором наборе входных данных невозможно добиться победы первого игрока.

В третьем наборе входных данных для победы первого игрока можно выложить на стол семерку (7), тогда первый игрок выиграет с комбинацией пара со значением 7.

В четвертом наборе входных данных невозможно добиться победы первого игрока.
 */