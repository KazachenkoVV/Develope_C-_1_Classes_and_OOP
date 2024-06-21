/* 1. Спроектируйте программу для построени генеалогического дерева,
 * уточните что у нас есть члены семьи у кого нет детей.
 * Есть члены семьи у кого дети есть
 * Есть мужчины и женщины
 * 
 * 2. Реализовать в классе методы вывода родителей, детей, братьев/сестёр (включая двоюродных),
 * бабушек и дедушек.
 * Подумайте как лучше реализовать данные методы.
 * 
 * 3. Домашнее задание:
 * Доработайте приложение генеалогического дерева таким образом чтобы программа выводила на экран
 * близких родственников (жену/мужа). Продумайте способ более красивого вывода с использованием горизонтальных и вертикальных черточек.
 * Родителей, детей.
 */
namespace Develope_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            List<FamilyMember> person = new List<FamilyMember>
            {
            new("Казаченко Никита Иванович", Gender.man, 1903),     //0
            new("Казаченко Ксения Ивановна", Gender.woman, 1902),   //1
            new("Тихонов Прокофий Дмитриевич", Gender.man, 1908),   //2
            new("Тихонова Елена Васильевна", Gender.woman, 1918),   //3
            new("Казаченко Василий Никитич", Gender.man, 1940),     //4
            new("Казаченко Инна Прокофьевна", Gender.woman, 1941),  //5
            new("Казаченко Валерий Васильевич", Gender.man, 1964),  //6
            new("Казаченко Андрей Васильевич", Gender.man, 1973),   //7
            new("Казаченко Евгений Валерьевич", Gender.man, 1989),  //8
            new("Казаченко Елена Фёдоровна", Gender.woman, 1964),   //9
            new("Галяк Фёдор Фёдорович", Gender.man, 1937),         //10
            new("Галяк Алла Алексеевна", Gender.woman, 1939),       //11
            new("Галяк Василий Фёдорович", Gender.man, 1959),       //12
            new("Сотникова Татьяна Фёдоровна", Gender.woman, 1969), //13
            new("Карпенко Светлана Фёдоровна", Gender.woman, 1975), //14
            new("Романов Александр Фёдорович", Gender.man, 1977)    //15
            };

            // Переносим список членов семьи в класс Family
            foreach (var member in person)
            {
                family.AddMember(member);
            }

            // Устанваливаем родителей
            person[4].Father = person[0];
            person[4].Mother = person[1];
            person[5].Father = person[2];
            person[5].Mother = person[3];
            person[6].Father = person[4];
            person[6].Mother = person[5];
            person[7].Father = person[4];
            person[7].Mother = person[5];
            person[8].Father = person[6];
            person[8].Mother = person[9];
            person[9].Father = person[10];
            person[9].Mother = person[11];
            person[12].Father = person[10];
            person[12].Mother = person[11];
            person[13].Father = person[10];
            person[13].Mother = person[11];
            person[14].Father = person[10];
            person[14].Mother = person[11];
            person[15].Father = person[10];
            person[15].Mother = person[11];

            // Устанавливаем брачные отношения
            person[0].Spouse = person[1];
            person[2].Spouse = person[3];
            person[4].Spouse = person[5];
            person[6].Spouse = person[9];
            person[11].Spouse = person[10];

            // Печать бабушек и дедушек для указанных персон
            person[6].PrintGrandParents();
            person[7].PrintGrandParents();
            person[8].PrintGrandParents();
            person[4].PrintGrandParents();

            // Печать супругов для указанных персон
            person[0].PrintSpouse();
            person[1].PrintSpouse();
            person[6].PrintSpouse();
            person[8].PrintSpouse();

            // Печать детей для указанных персон
            family.PrintChildren(person[11]);
            family.PrintChildren(person[6]);
            family.PrintChildren(person[8]);
            family.PrintChildren(person[9]);

            // Печать краткой информации о членах древа
            family.PrintFamily();

        }
    }
}
