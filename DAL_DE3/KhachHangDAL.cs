using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DTO_DE3;

namespace DAL_DE3
{
    public class KhachHangDAL
    {
        List<KhachHangDTO> khachHangs;
        public KhachHangDAL()
        {
            khachHangs = new List<KhachHangDTO>();
        }
        public List<KhachHangDTO> readfilekh(string filename)
        {
            khachHangs.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNodeList nodes = doc.GetElementsByTagName("KhachHang");
            foreach (XmlNode node in nodes)
            {
                string ma = node["MaKH"].InnerText;
                string ten = node["TenKH"].InnerText;
                string sodt = node["SoDT"].InnerText;
                khachHangs.Add(new KhachHangDTO(ma, ten, sodt));
            }

            return khachHangs;
        }
    }
}
