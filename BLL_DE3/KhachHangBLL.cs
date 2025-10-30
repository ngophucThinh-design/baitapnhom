using DAL_DE3;
using DTO_DE3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DE3
{
    public class KhachHangBLL
    {
        KhachHangDAL khachhangdal = new KhachHangDAL();
        List<KhachHangDTO> lkh;
        public KhachHangBLL() { }
        public List<KhachHangDTO> getlistKhachHang()
        {
            return lkh = khachhangdal.readfilekh(@"../../../Data/SanPham.xml");
        }
        public List<KhachHangDTO> DSKH()
        {
            return lkh;
        }
    }
}