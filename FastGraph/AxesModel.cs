using System;
namespace FastGraph
{
    public class AxesModel 
    {
        public string xName;
        public string yName;

        public int xMargin = 40;
        public int yMargin = 40;

        public int xPointersCount = 10;
        public int yPointersCount = 10;

        public AxesModel(string xName, string yName)
        {
            this.xName = xName;
            this.yName = yName;
        }
    }
}
