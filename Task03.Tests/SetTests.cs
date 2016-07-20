using NUnit.Framework;

namespace Task03.Tests
{
    public class SetTests
    {

        [TestCase("{ 2 3 4 5 6 7 }")]
        public void SetTest(string expected)
        {
            Set<string> set = new Set<string>();
            Set<string> set1 = new Set<string>();
            for (int i = 0; i < 10; i++)
            {
                set.Add(i.ToString());
            }
            for (int i = 5; i < 14; i++)
            {
                set1.Add(i.ToString());
            }
            set1.Clear();
            for (int i = 2; i < 8; i++)
            {
                set1.Add(i.ToString());
            }
            if (set.Contains("10"))
                set.Remove("10");
            Set<string> result = set.IntersectionOfSets(set1);

            Assert.AreEqual(expected, result.ToString());
        }


    }

}