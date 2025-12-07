using AppVideoClips.Lib;
namespace Tyuiu.GrigorjanAM.Sprint7.Project.V9.Test
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
        [TestMethod]
        public void rlySortedUbyv()
        {
            DataService ds = new DataService();
            string[,] basa = {
                                { "ID", "Название",    "Длительность"},
                                { "1",   "Примерный видеоклип", "240"},
                                { "2",   "Забавный момент", "180"},
                                { "3",   "Энергичный ритм", "300"}
                             };
            int column = 0;

            string[,] sortedbasa = { { "ID", "Название",    "Длительность"},
                                     { "3", "Энергичный ритм", "300" },
                                     { "2",   "Забавный момент", "180"},
                                     { "1",   "Примерный видеоклип", "240"}
                                   };

            string[,] result = ds.SortUbyv(basa, column);
            CollectionAssert.AreEqual(result, sortedbasa);
        }
        [TestMethod]
        public void rlySortedVozr()
        {
            DataService ds = new DataService();

            string[,] basa = {
                                { "ID", "Название",    "Длительность"},
                                { "1",   "Примерный видеоклип", "240"},
                                { "2",   "Забавный момент", "180"},
                                { "3",   "Энергичный ритм", "300"}
                             };
            int column = 2;
            string[,] sortedbasa = { { "ID", "Название", "Длительность" },
                                     { "2",   "Забавный момент", "180"},
                                     { "1",   "Примерный видеоклип", "240"},
                                     { "3",   "Энергичный ритм", "300"}
                                   };

            string[,] result = ds.SortVozr(basa, column);
            CollectionAssert.AreEqual(sortedbasa, result);



        }
    }


}

