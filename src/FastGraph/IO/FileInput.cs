using System;
using System.IO;

namespace FastGraph.IO
{
    public class FileInput 
    {

        public void LoadCSV(GraphNode loadTo, string path, bool ignoreFirstLine, int xColumntID, int yColumnID, char separator)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                string text = sr.ReadToEnd();
                int lines = 0;

                foreach (char c in text)
                    if (c == '\n')
                        lines++;

                sr.BaseStream.Position = 0;
                sr.DiscardBufferedData();

                string xColBuff;
                string yColBuff;

                for (int i = 0; i < lines; i++)
                {
                    if (ignoreFirstLine && i == 0) continue;

                    xColBuff = "";
                    yColBuff = "";

                    string line = sr.ReadLine();
                    int actualCol = 1;

                    foreach (char c in line)
                    {
                        if (c == separator) { actualCol++; continue; }
                        if (c == '\"' || c == '\'') continue;
                        if (actualCol == xColumntID)
                            xColBuff += c;
                        if (actualCol == yColumnID)
                            yColBuff += c;
                    }

                    float x = float.Parse(xColBuff);
                    float y = float.Parse(yColBuff);

                    loadTo.Values.Add(new Coordinate(x, y));
                }

                sr.Close();
                fs.Close();
            }catch(Exception e)
            {
                throw new FileInputException("Incorrect file input", e);
            }
        }
    }
}
