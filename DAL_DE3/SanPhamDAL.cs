using DTO_DE3;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace DAL_DE3
{
    public class SanPhamDAL
    {

        private List<SanPhamDTO> dSSPs = new List<SanPhamDTO>();

        public List<SanPhamDTO> readFilesp(string filename)
        {
            dSSPs.Clear();
            XmlDocument docsp = new XmlDocument();
            docsp.Load(filename);
            XmlNodeList nodes = docsp.GetElementsByTagName("SanPham");
            foreach (XmlNode node in nodes)
            {
                string Loai = node.Attributes["Loai"].Value;
                string ma = node["MaSP"].InnerText;
                string ten = node["TenSP"].InnerText;
                double kg = double.Parse(node["TrongLuong"].InnerText);
                double gia = double.Parse(node["GiaBan"].InnerText);
                string hang = node["XuatXu"].InnerText;
                DateTime ngay = DateTime.ParseExact(node["NgaySX"].InnerText, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (Loai == "1")
                {
                    dSSPs.Add(new ChamSocDa(ma, ten, kg, gia, hang, ngay));
                }
                else if (Loai == "2")
                {
                    dSSPs.Add(new TrangDiem(ma, ten, kg, gia, hang, ngay));
                }
                else if (Loai == "3")
                {
                    dSSPs.Add(new ChongNang(ma, ten, kg, gia, hang, ngay));
                }
            }
            return dSSPs;
        }
        public void ThemSanPhamMoi(SanPhamDTO sp)
        {
            dSSPs.Add(sp);
        }
        public List<SanPhamDTO> TimSanPhamTheoXuatXu(string xuatxu)
        {
            return dSSPs.Where(t => t.XuatXu == xuatxu).ToList();
        }
        public void CapNhatGia()
        {
            foreach (SanPhamDTO a in dSSPs)
            {
                if (a is TrangDiem)
                    a.GiaBan += a.GiaBan * 0.05;
            }
        }
        public List<SanPhamDTO> GiaBanTren300()
        {
            return dSSPs.Where(t => t.GiaBan > 300000).ToList();
        }
        public List<TrangDiem> SanPhamTrangDiem()
        {
            return dSSPs.OfType<TrangDiem>().ToList();
        }
        public List<SanPhamDTO> SanPhamTren3Thang()
        {
            return dSSPs.Where(t => t.soThang() > 3).ToList();
        }
    }
}
