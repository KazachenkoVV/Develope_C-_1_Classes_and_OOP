namespace Develope_1
{
    public static class LocalizationHelper
    {
        public static string GetYearSuffix(this int number)
        {
            if (number >= 10 && number <= 19)
                return "лет";
            else
            {
                string numString = number.ToString();
                char lastChar = numString[numString.Length - 1];
                int lastNum = int.Parse(lastChar.ToString());
                if (lastNum == 1)
                    return "год";
                else if (lastNum >= 2 && lastNum <= 4)
                    return "года";
                else
                    return "лет";
            }
        }
        public static string GetSpouseGenitiveSuffix(this FamilyMember person)
        {
            if (person.Gender == Gender.man)
                return "у";
            else
                return "а";
        }
    }
}
