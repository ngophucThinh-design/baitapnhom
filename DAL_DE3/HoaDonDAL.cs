using DTO_DE3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL_DE3
{
    public class HoaDonDAL
    {
        List<HoaDonDTO> hoaDons = new List<HoaDonDTO>();


        public List<HoaDonDTO> KhoiTao(List<KhachHangDTO> lkh, List<SanPhamDTO> lsp)
        {
            hoaDons.Clear();
            hoaDons.Add(new HoaDonDTO(lkh[0], new List<SanPhamDTO> { lsp[0], lsp[1], lsp[6], lsp[7] }));
            hoaDons.Add(new HoaDonDTO(lkh[1], new List<SanPhamDTO> { lsp[2], lsp[3] }));
            hoaDons.Add(new HoaDonDTO(lkh[2], new List<SanPhamDTO> { lsp[4], lsp[5] }));
            return hoaDons;
        }
        private string ChuanHoaChuoi(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            text = text.Trim().ToLower();
            string normalized = text.Normalize(NormalizationForm.FormD);
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string clean = regex.Replace(normalized, String.Empty)
                                 .Replace('đ', 'd').Replace('Đ', 'D');
            return clean;
        }

        public List<SanPhamDTO> SanPhamDaMua(string tenkh)
        {
            string tenCanTim = ChuanHoaChuoi(tenkh);

            HoaDonDTO hd = hoaDons.FirstOrDefault(t =>
                t.Kh != null &&
                ChuanHoaChuoi(t.Kh.TenKH) == tenCanTim);

            if (hd == null)
            {
                return null;
            }

            return hd.Sp;
        }
        public List<KhachHangDTO> KhachHangMuaHon3SP()
        {
            List<HoaDonDTO> khv = hoaDons.Where(t => t.Sp.Count > 3).ToList();
            List<KhachHangDTO> lkhv = new List<KhachHangDTO>();
            foreach (HoaDonDTO hd in khv)
            {
                lkhv.Add(hd.Kh);
            }
            return lkhv;
        }
        public KhachHangDTO KhachHangMuaNhieuNhat()
        {
            return hoaDons.OrderByDescending(t => t.TongTienSP()).First().Kh;
        }
    }
}
