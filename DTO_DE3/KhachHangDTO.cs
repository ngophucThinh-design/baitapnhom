using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_DE3
{
    public class KhachHangDTO
    {
        private string maKH;
        private string tenKH;
        private string soDT;

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public KhachHangDTO(string ma, string ten, string sodt)
        {
            this.MaKH = ma;
            this.TenKH = ten;
            this.SoDT = sodt;
        }
        public void Xuat()
        {
            Console.WriteLine($"{MaKH,-10}{TenKH,-30}{SoDT,-15}");
        }
    }
}
