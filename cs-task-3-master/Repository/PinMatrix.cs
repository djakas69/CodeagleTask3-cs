using Csharp_Task_3.Helpers;


namespace Csharp_Task_3.Repository
{
    public class PinMatrix
    {
        #region VARIABLES
        private static readonly int Rows = 4;
        private static readonly int Columns = 3;

        int CurrentRow = -1;
        int CurrentColumn = -1;

        public string[,] NumberPositions = new string[Rows, Columns];
        #endregion

        #region CONSTRUCTOR
        public PinMatrix()
        {
            NumberPositions[0, 0] = "1";
            NumberPositions[0, 1] = "2";
            NumberPositions[0, 2] = "3";

            NumberPositions[1, 0] = "4";
            NumberPositions[1, 1] = "5";
            NumberPositions[1, 2] = "6";

            NumberPositions[2, 0] = "7";
            NumberPositions[2, 1] = "8";
            NumberPositions[2, 2] = "9";

            NumberPositions[3, 0] = "-1";
            NumberPositions[3, 1] = "0";
            NumberPositions[3, 2] = "-1";
        }
        #endregion

        #region METHODS
        /// <summary>
        /// GetPINs return array of all variations for given numbers up to 8 digits
        /// </summary>
        /// <param name="num">number that user enter</param>
        /// <returns>array of number variations</returns>
        public List<string> GetPINs(string num)
        {
            var result = new List<string>();
            char[] parts = num.ToCharArray();
            List<List<string>> mainlist = new List<List<string>>();
            //create main list
            foreach (char part in parts)
            {
                List<string> res = oneNumberVariations(part.ToString());
                mainlist.Add(res);


            }

            var cartesianList = mainlist.CartesianProduct();
            string test = "";
            foreach (var cartesian in cartesianList)
            {
                string temp = "";
                foreach (var item in cartesian)
                {
                    temp += item;
                }
                if (result.Contains(temp) == false)
                {
                    result.Add(temp);
                    test += temp + ",";
                }
                else
                {
                    string doubles = temp;
                }
            }

            return result;
        }

        /// <summary>
        /// Return list of all possible variations for one number
        /// </summary>
        /// <param name="num"></param>
        /// <returns>array list of numbers</returns>
        private List<string> oneNumberVariations(string num)
        {
            var result = new List<string>();
            findNumberPossitionInMatrix(num);
            result = getOtherVaritionsForNumber();
            result.Add(num.ToString());
            return result;
        }
        /// <summary>
        /// Find the horisontal and vertical position for given number
        /// That possition we will use to find alternative numbers
        /// </summary>
        /// <param name="num">incomming number</param>
        private void findNumberPossitionInMatrix(string num)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (NumberPositions[i, j] == num)
                    {
                        CurrentRow = i;
                        CurrentColumn = j;
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Calulate list of alternative numbers for given number
        /// </summary>
        /// <returns>list of numbers</returns>
        private List<string> getOtherVaritionsForNumber()
        {
            List<string> result = new List<string>();

            #region Horisontal
            //try left
            if (CurrentColumn > 0)
            {
                string tempInt = NumberPositions[CurrentRow, CurrentColumn - 1];
                if (tempInt.Equals("-1") == false)
                {
                    result.Add(tempInt.ToString());
                }
            }
            //try right
            if (CurrentColumn < Columns - 1)
            {
                string tempInt = NumberPositions[CurrentRow, CurrentColumn + 1];
                if (tempInt.Equals("-1") == false)
                {
                    result.Add(tempInt.ToString());
                }
            }
            #endregion
            #region Vertical
            //try up
            if (CurrentRow > 0)
            {
                string tempInt = NumberPositions[CurrentRow - 1, CurrentColumn];
                if (tempInt.Equals("-1") == false)
                {
                    result.Add(tempInt.ToString());
                }
            }
            //try right
            if (CurrentRow < Rows - 1)
            {
                string tempInt = NumberPositions[CurrentRow + 1, CurrentColumn];
                if (tempInt.Equals("-1") == false)
                {
                    result.Add(tempInt.ToString());
                }
            }
            #endregion

            return result;
        }


        #endregion

    }
}
