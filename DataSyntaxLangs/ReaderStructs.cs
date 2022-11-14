using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyntaxLangs
{
    public class ReaderStructs
    {
        String url;
        public ReaderStructs(String url)
        {
            this.url = url;
        }

        public String ReadStructPrTxt()
        {
            String path= "C:\\Users\\59177\\Desktop\\UNIFRANZ\\SEMESTRE2\\ProyectoSemestre\\TraductorLenguajes\\DataSyntaxLangs\\StructsPrs\\";
            String line;
            String struct_pr="";
            if (this.url != "")
            {
                try
                {
                    StreamReader sr = new StreamReader(path + this.url);

                    line = sr.ReadLine();

                    while (line != null)
                    {
                        line = sr.ReadLine();
                        struct_pr += line + "\n";
                    }

                    sr.Close();
                    return struct_pr;
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
            else
            {
                return "";
            }
        }
    }
}
