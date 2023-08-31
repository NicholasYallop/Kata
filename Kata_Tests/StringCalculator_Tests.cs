using KataKana;

namespace KataKana_Tests
{
    public class Tests
    {
        [TestCase("", 0, "")]
        [TestCase("1", 1, "")]
        [TestCase("2", 2, "")]
        [TestCase("1,2", 3, "")]
        [TestCase("12", 12, "")]
        [TestCase("12,2", 14, "")]
        [TestCase("1,12, 3", 16, "")]
        [TestCase("1,12, 99", 112, "")]
        [TestCase(@"1,12\n99", 112, "")]
        [TestCase(@"1\n12", 13, "")]
        [TestCase(@"1\n12,3", 16, "")]
        [TestCase(@"1\n12\n,3", 16, "")]
        [TestCase(@"//;\n1;2", 3, "")]
        [TestCase(@"//;\n1;2\n3", 6, "")]
        [TestCase(@"//;\n1;2;3", 6, "")]
        [TestCase("-1,2", 0, "Negatives not allowed: -1")]
        [TestCase("2,-4,3,-5", 0, "Negatives not allowed: -4,-5")]
        [TestCase(@"1001,2", 2, "")]
        [TestCase(@"1001,2", 2, "")]
        [TestCase(@"//[|||]\n1|||2|||3", 6, "")]
        [TestCase(@"//[|][%]\n1|2%3", 6, "")]
        public void Test1(string input, int sum, string expectedError)
        {
            // arrange
            var calculator = new StringCalculator();

            if (expectedError == "")
            {
                var output = calculator.Add(input);
                Assert.AreEqual(sum, output);
            }
            else
            {
                Assert.Throws(typeof(Exception), () => calculator.Add(input), expectedError);
            }
        }
    }
}