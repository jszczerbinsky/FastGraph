using System;
namespace FastGraph
{
    public class AxesModel 
    {
        public string xName;
        public string yName;

        public int xMargin = 20;
        public int yMargin = 20;

        public AxesModel(string xName, string yName)
        {
            this.xName = xName;
            this.yName = yName;
        }
    }
}
