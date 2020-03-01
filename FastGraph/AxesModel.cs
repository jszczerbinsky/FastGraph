using System;
namespace FastGraph
{
    public class AxesModel 
    {
        public string xName;
        public string yName;

        public int xMargin = 40;
        public int yMargin = 40;

        public int xPointersSpace = 10;
        public int yPointersSpace = 10;

        public AxesModel(string xName, string yName)
        {
            this.xName = xName;
            this.yName = yName;
        }
    }
}
