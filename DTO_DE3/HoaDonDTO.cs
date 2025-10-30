using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_DE3
{
    public class HoaDonDTO
    {
        KhachHangDTO kh;
        List<SanPhamDTO> sp;

        public KhachHangDTO Kh { get => kh; set => kh = value; }
        public List<SanPhamDTO> Sp { get => sp; set => sp = value; }

        public HoaDonDTO(KhachHangDTO kh, List<SanPhamDTO> sp)
        {
            this.Kh = kh;
            this.Sp = sp;
        }
        public void XuatHD()
        {
            Console.WriteLine($"{"Ma KH",-10}{"Ten KH",-30}{"So DT",-15}");
            Kh.Xuat();
            Console.WriteLine("====================================================================================================================");
            Console.WriteLine($"{"Ma SP",-10}{"Ten SP",-25}{"Trong luong",-13}{"Gia ban",-10}{"Xuat xu",-20}{"Ngay SX",-13}{"ThanhTienSP",-13}{"Khuyen Mai",-10}");
            foreach (SanPhamDTO a in Sp)
            {
                a.Xuat();
            }
            Console.WriteLine("====================================================================================================================");
            Console.WriteLine($"Tong Tien San Pham:{TongTienSP()}");
            Console.WriteLine("\n");
        }
        public double TongTienSP()
        {
            return Sp.Sum(t => t.ThanhTienSP());
        }

    }
}
