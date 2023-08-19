using System;
using System.Collections.Generic;
using System.Linq;

namespace Route256.Sandbox.old
{
    internal class Task_H
    {
        public void Main(string[] args)
        {
            var testCaseCount = int.Parse(Console.ReadLine());

            for (var test = 0; test < testCaseCount; test++)
            {
                var arr = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                int rowCount = arr[0];
                int elementCount = arr[1];
                var map = new Map();

                for (var rowNum = 1; rowNum <= rowCount; rowNum++)
                {
                    var isEven = rowNum % 2 == 0 ? 1 : 0;
                    var rowStr = Console.ReadLine();
                    for (var i = isEven; i < elementCount; i += 2)
                    {
                        var id = rowNum * 100 + i + 1;
                        var region = rowStr[i];
                        map.Add(region, id);
                    }
                }

                Console.WriteLine(map.Validate() ? "YES" : "NO");
            }
        }

        class Hexagon
        {
            public char RegionId { get; }
            public int Id { get; }
            public bool Visited { get; set; }

            public Hexagon(char region, int id)
            {
                RegionId = region;
                Id = id;
            }
        }

        class Map
        {
            public Dictionary<char, Region> Regions => _regions;

            private Dictionary<int, Hexagon> _map;
            private Dictionary<char, Region> _regions;

            public Map()
            {
                _regions = new();
                _map = new();
            }
            public void Add(char region, int id)
            {
                _map.Add(id, new Hexagon(region, id));
                if (!_regions.ContainsKey(region))
                    _regions.Add(region, new Region(region, id));
            }

            public Hexagon this[int id]
            {
                get => _map[id];
                set
                {
                    _map[id] = value;
                }
            }
            public bool Validate()
            {
                foreach (var region in _regions.Values)
                {
                    CheckRegion(region);
                }

                return !_map.Any(h => !h.Value.Visited);
            }

            void CheckRegion(Region region)
            {
                CheckHexRecurs(region, region.StartHexId);

                region.Checked = true;
            }

            void CheckHexRecurs(Region region, int hexId)
            {
                if (!_map.ContainsKey(hexId))
                    return;
                var hex = _map[hexId];
                if (region.Id != hex.RegionId)
                    return;
                if (hex.Visited)
                    return;

                hex.Visited = true;
                CheckHexRecurs(region, hex.Id - 101);
                CheckHexRecurs(region, hex.Id - 99);
                CheckHexRecurs(region, hex.Id - 2);
                CheckHexRecurs(region, hex.Id + 2);
                CheckHexRecurs(region, hex.Id + 99);
                CheckHexRecurs(region, hex.Id + 101);
            }
        }

        class Region
        {
            public char Id { get; }
            public int StartHexId { get; }
            public bool Checked { get; set; }
            public Region(char key, int startHexId)
            {
                Id = key;
                StartHexId = startHexId;
            }
        }
    }
}

/*
 H. Валидация карты (25 баллов)
ограничение по времени на тест1 секунда
ограничение по памяти на тест512 мегабайт
вводстандартный ввод
выводстандартный вывод
В этой задаче вам необходимо реализовать валидацию корректности карты для стратегической компьютерной игры.

Карта состоит из гексагонов (шестиугольников), каждый из которых принадлежит какому-то региону карты. В файлах игры карта представлена как n строк по m символов в каждой (строки и символы в них нумеруются с единицы). Каждый нечетный символ каждой четной строки и каждый четный символ каждой нечетной строки — точка (символ . с ASCII кодом 46); все остальные символы соответствуют гексагонам и являются заглавными буквами латинского алфавита. Буква указывает на то, какому региону принадлежит гексагон.

Посмотрите на картинку ниже, чтобы понять, как описание карты в файлах игры соответствует карте из шестиугольников.

Соответствие описания карты в файле (слева) и самой карты (справа). Регионы R, G, V, Y и B окрашены в красный, зеленый, фиолетовый, желтый и синий цвет, соответственно.
Вы должны проверить, что каждый регион карты является одной связной областью. Иными словами, не должно быть двух гексагонов, принадлежащих одному и тому же региону, которые не соединены другими гексагонами этого же региона.

Карта слева является корректной. Карта справа не является корректной, так как гексагоны, обозначенные цифрами 1 и 2, принадлежат одному и тому же региону (обозначенному красным цветом), но не соединены другими гексагонами этого региона.
Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
В первой строке задано одно целое число t (1≤t≤100) — количество наборов входных данных.

Первая строка набора входных данных содержит два целых числа n и m (2≤n,m≤20) — количество строк и количество символов в каждой строке в описании карты.

Далее следуют n строк по m символов в каждой — описание карты. Каждый нечетный символ каждой четной строки и каждый четный символ каждой нечетной строки — точка (символ . с ASCII кодом 46); все остальные символы соответствуют гексагонам и являются заглавными буквами латинского алфавита.

Выходные данные
На каждый набор входных данных выведите ответ в отдельной строке — YES, если каждый регион карты представляет связную область, или NO, если это не так.

Пример
входные данныеСкопировать
3
3 7
R.R.R.G
.Y.G.G.
B.Y.V.V
4 8
Y.R.B.B.
.R.R.B.V
B.R.B.R.
.B.B.R.R
2 7
G.B.R.G
.G.G.G.
выходные данныеСкопировать
YES
NO
YES
Примечание
Первые два набора входных данных из примера показаны на второй картинке в условии.
 */