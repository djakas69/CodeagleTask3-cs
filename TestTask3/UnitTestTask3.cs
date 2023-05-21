using Csharp_Task_3.Data;

namespace Tests
{
    public class TestsGetPINs
    {
        private PinMatrix pmx;
        [SetUp]
        public void Setup()
        {
            pmx= new PinMatrix();
        }

        [Test]
        [TestCase("1", "1,2,4", true)]
        [TestCase("2", "1,2,3,5", true)]
        [TestCase("3", "2,3,6", true)]
        [TestCase("4", "1,4,5,7", true)]
        [TestCase("5", "2,4,5,6,8", true)]
        [TestCase("6", "6,3,5,9", true)]
        [TestCase("7", "4,7,8", true)]
        [TestCase("8", "5,7,8,9,0", true)]
        [TestCase("9", "6,8,9", true)]
        [TestCase("0", "0,8", true)]
        [TestCase("8", "5,7,8,9", false)]
        public void OnePin(string PinNum, string ExpectedRes, bool ExpectedStatus)
        {
            //"["5","7","8","9","0"]"

            List<string> listIncomming =  ExpectedRes.Split(",").ToList() ;

            List<string> listRes = pmx.GetPINs(PinNum);

            AssertCcompareTwoLists(listIncomming, listRes,ExpectedStatus);

        }

        [Test]
        [TestCase("11", true)]
        [TestCase("36", true)]
        [TestCase("369", true)]
        [TestCase("420", true)]
        [TestCase("1234", true)]
        [TestCase("2245", true)]
        [TestCase("2244", true)]        
        [TestCase("14357", true)]
        [TestCase("224456", true)]
        [TestCase("1435711", true)]
        [TestCase("36110033", true)]
        public void MorePins(string PinNum,  bool ExpectedStatus)
        {
            string ExpectedRes="";
            string expectedResFile = PinNum + ".txt";
            if(File.Exists(expectedResFile))
            {
                ExpectedRes = File.ReadAllText(expectedResFile);
                List<string> listIncomming = ExpectedRes.Split(",").ToList();
                
                List<string> listRes = pmx.GetPINs(PinNum);

                AssertCcompareTwoLists(listIncomming, listRes, ExpectedStatus);
            }
            else
            {
                Assert.Fail();
            }
            
        }
       
        private void AssertCcompareTwoLists(List<string> listIncomming, List<string> listRes, bool ExpectedStatus)
        {

            bool isEqual = false;

            if (listIncomming.Count == listRes.Count)
            {
                isEqual = !listIncomming.Except(listRes).Any();
            }

            if (isEqual == ExpectedStatus)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true);
            }
        }
    }
}