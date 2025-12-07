using AppVideoClips.Lib;
namespace AppVideoClips.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadDataSet()
        {
            DataService ds = new DataService();

            string path = @"C:\Users\User\Desktop\Dataset.csv";
            FileInfo fi = new FileInfo(path);
            bool fileEx = fi.Exists;
            bool wait = true;
            Assert.AreEqual(wait, fileEx);            
        }
    }
}

