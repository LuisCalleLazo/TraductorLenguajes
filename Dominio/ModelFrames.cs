using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using AccesoDatos.LibsFrams;
namespace Dominio
{
    public class ModelFrames
    {
        DataFrames data_frames = new DataFrames();
        public (List<string>,List<int>,List<string>) GetNamesFrames(string id_lang)
        {
            return data_frames.GetNamesFrames(id_lang);
        }
        public string GetInfoFrame(int id_frame)
        {
            return data_frames.GetInfoFrame(id_frame);
        }
    }
}
