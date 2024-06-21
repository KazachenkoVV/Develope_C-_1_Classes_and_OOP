using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develope_1
{
    public enum Gender { man, woman };
    
    public class FamilyMember
    {
        public string FullName { get; set; }
        public Gender Gender { get; init; }
        public int YearOfBirth { get; init; }
        public FamilyMember? Father { get; set; }
        public FamilyMember? Mother { get; set; }
        FamilyMember? spouse;

        public FamilyMember(string fullName, Gender gender, int yearOfBirth)
        {
            if (string.IsNullOrWhiteSpace(fullName) || fullName.Length < 5)
                throw new ArgumentException("Таких коротких имён не существует!");

            if (!Enum.IsDefined(typeof(Gender), gender))
                throw new ArgumentException("Недопустимое значение для пола");

            FullName = fullName.Trim();
            Gender = gender;
            YearOfBirth = yearOfBirth;
        }

        public FamilyMember Spouse
        {
            get { return spouse; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), "Нельзя использовать совйство на несуществующем экземпляре (null).");
                else
                {
                    // Свободен ли потенциальный супруг?
                    if (value.Spouse != null && value.Spouse != this)
                    {
                        throw new InvalidOperationException($"{value.FullName} уже имеет другого супруга!");
                    }
                    // Нельзя жениться / выйти замуж за себя любимого!
                    if (this == value)
                    {
                        throw new InvalidOperationException($"{value.FullName} нельзя сочетаться браком самом с собой!");
                    }
                    // Однополые браки не регистрируют!
                    if (this.Gender == value.Gender)
                    {
                        throw new InvalidOperationException($"{value.FullName} однополые браки в России не регистрируют!");
                    }
                    // Если сам на данный момент в браке - разводим
                    if (Spouse != null)
                    {
                        Spouse.spouse = null;
                    }
                    spouse = value;         // Регистрируем брак самого
                    spouse.spouse = this;   // Регистрируем брак его супруга / супруги
                }
            }
        }
        public void RemoveSpouse()
        {
            if (this.spouse != null)
            {
                spouse.spouse = null;
                spouse = null;
            }
        }
        public void PrintSpouse()
        {
            if (this.spouse != null)
            {
                Console.WriteLine($"{this.GetNameAndYearsOld()} имеет супруг{this.GetSpouseGenitiveSuffix()}:");
                Console.WriteLine($"    {this.Spouse.GetNameAndYearsOld()}\n");
            }
            else
            {
                Console.WriteLine($"{this.GetNameAndYearsOld()} не имеет супруг{this.GetSpouseGenitiveSuffix()}\n");
            }
        }

            public FamilyMember[] GetGrandMothers()
        {
            FamilyMember[] grandMothers = new FamilyMember[2];
            if (Mother?.Mother != null)
            {
                grandMothers[0] = Mother.Mother;
            }
            if (Father?.Mother != null)
            {
                grandMothers[1] = Father.Mother;
            }
            return grandMothers;
        }
        public FamilyMember[] GetGrandFathers()
        {
            FamilyMember[] grandFathers = new FamilyMember[2];
            if (Mother?.Father != null)
            {
                grandFathers[0] = Mother.Father;
            }
            if (Father?.Father != null)
            {
                grandFathers[1] = Father.Father;
            }
            return grandFathers;
        }
        public void PrintGrandParents()
        {
            var grandMothers = GetGrandMothers();
            var grandFathers = GetGrandFathers();

            Console.WriteLine($"У {FullName} есть бабушки:");
            foreach (var item in grandMothers)
                if (item != null)
                    Console.WriteLine($"    {item.GetNameAndYearsOld()}");
            else
                Console.WriteLine("    нет данных");

            Console.WriteLine($"У {FullName} есть дедушки:");
            foreach (var item in grandFathers)
                if (item != null)
                    Console.WriteLine($"    {item.GetNameAndYearsOld()}");
                else
                    Console.WriteLine("    нет данных");
            Console.WriteLine();
        }
        public string GetNameAndYearsOld()
        {
            int yearsOld = DateTime.Now.Year - this.YearOfBirth;
            return $"{this.FullName} - {yearsOld} {yearsOld.GetYearSuffix()}";
        }
    }
}
