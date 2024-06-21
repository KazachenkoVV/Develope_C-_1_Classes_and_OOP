using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develope_1
{
    internal class Family
    {
        public List<FamilyMember> Members { get; private set; } = new List<FamilyMember>();

        public void AddMember(FamilyMember person)
        {
            Members.Add(person);
        }

        public void PrintChildren(FamilyMember parent)
        {
            List<FamilyMember> members = Members.Where(m => m.Father == parent || m.Mother == parent).ToList(); ;
            if (members.Count > 0)
            {
                Console.WriteLine($"{parent.GetNameAndYearsOld()} имеет детей:");
                foreach (FamilyMember child in members)
                    Console.WriteLine($"    {child.GetNameAndYearsOld()}");
            }
            else
                Console.WriteLine($"{parent.GetNameAndYearsOld()} не имеет детей.");
            Console.WriteLine();
        }
            public void PrintFamily()
        {
            Console.WriteLine("Список людей в генеологическом древе:");
            foreach (FamilyMember person in Members)
            {
                Console.WriteLine(person.GetNameAndYearsOld());

                Console.Write("  Отец: ");
                if (person.Father != null)
                    Console.WriteLine(person.Father.GetNameAndYearsOld());
                else
                    Console.WriteLine("нет данных.");

                Console.Write("  Мать: ");
                if (person.Mother != null)
                    Console.WriteLine(person.Mother.GetNameAndYearsOld());
                else
                    Console.WriteLine("нет данных.");

                Console.Write("  В браке ");
                if (person.Spouse != null)
                    Console.WriteLine($"с {person.Spouse.GetNameAndYearsOld()}");
                else
                    Console.WriteLine("не состоит.");
            }
        }
    }
}
