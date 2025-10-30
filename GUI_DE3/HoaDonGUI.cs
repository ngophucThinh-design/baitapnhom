using BLL_DE3;
using DTO_DE3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DE3
{
    public class HoaDonGUI
    {
        HoaDonBLL hoadonbll = new HoaDonBLL();
        public List<HoaDonDTO> getListHD(List<KhachHangDTO> lkh, List<SanPhamDTO> lsp)
        {
            return hoadonbll.getlistHoaDon(lkh, lsp);
        }
        public void SanPhamKHDaMua()
        {
            Console.WriteLine("Nhap ten khach hang: ");
            string tenkh = Console.ReadLine();
            List<SanPhamDTO> spkh = hoadonbll.SanPhamDaMua(tenkh);
            try
            {
                if (spkh != null)
                {
                    foreach (SanPhamDTO a in spkh)
                        a.Xuat();
                }
            }
            catch
            {
                Console.WriteLine("Khong co ten khach hang trong danh sach");
            }
        }
        public void MuaNhieuHon3SP()
        {
            Console.WriteLine("DANH SACH KHACH HANG MUA NHIEU HON 3 SP: ");
            List<KhachHangDTO> khv = hoadonbll.MuaNhieuHon3SP();
            foreach (KhachHangDTO a in khv)
                a.Xuat();
        }
        public void MuaNhieuNhat()
        {
            Console.WriteLine("KHACH HANG MUA NHIEU TIEN NHAT: ");
            KhachHangDTO khv1 = hoadonbll.MuaNhieuNhat();
            khv1.Xuat();
        }
    }
}

