namespace KataKana
{
    public class StringCalculator
    {
        public int Add(string str)
        {
            var sum = 0;
            if (string.IsNullOrEmpty(str)) return sum;

            string delimiter = ",";

            if (str.Length>5 && str[0]=='/' && str[1] == '/')
            {
                if (str[3] == '\\' && str[4] == 'n')
                {
                    delimiter = str[2].ToString();
                    str = str.Substring(5);
                }
                else
                {
                    var delimiterEnd = str.IndexOf(@"\n");
                    if (delimiterEnd>0)
                    {
                        var delimiters = str.Substring(3, delimiterEnd-3).Replace("]", string.Empty).Split('[');
                        foreach (var delim in delimiters)
                        {
                            if (delim.Length == 0) continue;
                            str = str.Replace(delim, delimiter.ToString());
                        }
                    }
                }
            }

            str = str.Replace(@"\n", delimiter.ToString());
            var ints = str.Split(delimiter);

            List<int> negatives = new List<int>();

            foreach(var i in ints)
            {
                int integer;
                if (Int32.TryParse(i, out integer)){
                    if (integer < 0)
                    {
                        negatives.Add(integer);
                    }
                    else if(integer<=1000)
                    {
                        sum += integer;
                    }
                }
            }
            if (negatives.Count==0) return sum;
            else
            {
                string errorString = "Negatives not allowed: ";
                negatives.ForEach(i => errorString += i.ToString() + ',');
                throw new Exception(errorString.Substring(errorString.Length - 2));
            }
        }
    }
}