namespace StringCalculator.Domain
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if(String.IsNullOrWhiteSpace(numbers))
                return 0;

            var nums = numbers.Split(',');

            var exceedsCount = nums.Length > 2;
            var consecutiveCommas = nums.Any(x => x == "");
            var nonNumbers = nums.Any(x => !int.TryParse(x, out var _));

            if (exceedsCount || nonNumbers || consecutiveCommas)
                throw new ArgumentException(nameof(numbers));

            var sum = nums.Sum(x => Convert.ToInt32(x));             

            return sum;


        }
    }
}