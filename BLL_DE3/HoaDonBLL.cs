using DAL_DE3;
using DTO_DE3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DE3
{
    public class HoaDonBLL
    {



        
        HoaDonDAL hoadondal = new HoaDonDAL();
        public HoaDonBLL() { }
        public List<HoaDonDTO> getlistHoaDon(List<KhachHangDTO> lkh, List<SanPhamDTO> lsp)
        {
            return hoadondal.KhoiTao(lkh, lsp);
        }
        public List<SanPhamDTO> SanPhamDaMua(string ten)
        {
            return hoadondal.SanPhamDaMua(ten);
        }
        public List<KhachHangDTO> MuaNhieuHon3SP()
        {
            return hoadondal.KhachHangMuaHon3SP();
        }
        public KhachHangDTO MuaNhieuNhat()
        {
            return hoadondal.KhachHangMuaNhieuNhat();
        }
    } 
}
