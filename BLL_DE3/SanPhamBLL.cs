using DTO_DE3;
using DAL_DE3;
using System.Collections.Generic;
using System.Globalization;

namespace BLL_DE3
{
    public class SanPhamBLL
    {
        SanPhamDAL sanphamdal = new SanPhamDAL();
        List<SanPhamDTO> dssp;
        public List<SanPhamDTO> getListSanPham()
        {
            return dssp = sanphamdal.readFilesp(@"../../../Data/SanPham.xml");
        }
        public void ThemSanPhamMoi(SanPhamDTO sp)
        {
            sanphamdal.ThemSanPhamMoi(sp);
        }
        public List<SanPhamDTO> DSSP()
        {
            return dssp;
        }
        public List<SanPhamDTO> TimSanPhamTheoXuatXu(string xuatxu)
        {
            return sanphamdal.TimSanPhamTheoXuatXu(xuatxu);
        }
        public void CapNhatGia()
        {
            sanphamdal.CapNhatGia();
        }
        public List<SanPhamDTO> GiaBanTren300()
        {
            return sanphamdal.GiaBanTren300();
        }
        public List<TrangDiem> SanPhamTrangDiem()
        {
            return sanphamdal.SanPhamTrangDiem();
        }
        public List<SanPhamDTO> SanPhamtren3Thang()
        {
            return sanphamdal.SanPhamTren3Thang();
        }
    }
}



