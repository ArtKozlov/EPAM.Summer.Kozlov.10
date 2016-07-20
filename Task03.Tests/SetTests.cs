using NUnit.Framework;

namespace Task03.Tests
{
    public class SetTests
    {

        [TestCase("{ 2 3 4 5 6 7 }")]
        public void SetTest(string expected)
        {
            Set<int> set = new Set<int>();
            Set<int> set1 = new Set<int>();
            for (int i = 0; i < 10; i++)
            {
                set.Add(i);
            }
            for (int i = 5; i < 14; i++)
            {
                set1.Add(i);
            }
            set1.Clear();
            for (int i = 2; i < 8; i++)
            {
                set1.Add(i);
            }
            if (set.Contains(10))
                set.Remove(10);
            Set<int> result = set.IntersectionOfSets(set1);

            Assert.AreEqual(expected, result.ToString());
        }


    }

}