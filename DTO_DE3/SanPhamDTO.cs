using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_DE3
{
    public class SanPhamDTO
    {
        private string maSP;
        private string tenSP;
        private double trongLuong;
        private double giaBan;
        private string xuatXu;
        private DateTime ngaySX;

        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public double TrongLuong { get => trongLuong; set => trongLuong = value; }
        public double GiaBan { get => giaBan; set => giaBan = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
        public DateTime NgaySX { get => ngaySX; set => ngaySX = value; }

        public SanPhamDTO(string maSP, string tenSP, double trongLuong, double giaBan, string xuatXu, DateTime ngaySX)
        {
            this.MaSP = maSP;
            this.TenSP = tenSP;
            this.TrongLuong = trongLuong;
            this.GiaBan = giaBan;
            this.XuatXu = xuatXu;
            this.NgaySX = ngaySX;
        }
        public int soThang()
        {
            int sothang = Math.Abs((DateTime.Today.Year - NgaySX.Year) * 12 + DateTime.Today.Month - NgaySX.Month);
            return sothang;
        }
        public double TroGia()
        {

            if (soThang() >= 12) return GiaBan * 0.1;
            else if (soThang() >= 9) return GiaBan * 0.05;
            else return GiaBan * 0.03;
        }
        public virtual double ThanhTienSP()
        {
            return GiaBan - TroGia();
        }
        public virtual void Xuat()
        {

            Console.Write($"{MaSP,-10}{TenSP,-30}{TrongLuong,-8}{GiaBan,-10}{XuatXu,-20}{NgaySX.ToString("dd/MM/yyyy"),-15}{ThanhTienSP(),-13}");
        }
    }
    public class ChamSocDa : SanPhamDTO, IKhuyenMai
    {
        public ChamSocDa(string maSP, string tenSP, double trongLuong, double giaBan, string xuatXu, DateTime ngaySX) : base(maSP, tenSP, trongLuong, giaBan, xuatXu, ngaySX)
        {
        }

        public double KhuyenMai()
        {
            return GiaBan * 0.1;
        }
        public override double ThanhTienSP()
        {
            return base.ThanhTienSP() - KhuyenMai();
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"{KhuyenMai()}");
        }
    }
    public class TrangDiem : SanPhamDTO, IKhuyenMai
    {
        public TrangDiem(string maSP, string tenSP, double trongLuong, double giaBan, string xuatXu, DateTime ngaySX) : base(maSP, tenSP, trongLuong, giaBan, xuatXu, ngaySX)
        {
        }

        public double KhuyenMai()
        {
            if (GiaBan > 200000) return GiaBan * 0.1;
            else if (GiaBan >= 100000) return GiaBan * 0.07;
            else return GiaBan * 0.05;
        }
        public override double ThanhTienSP()
        {
            return base.ThanhTienSP() - KhuyenMai();
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"{KhuyenMai()}");
        }
    }
    public class ChongNang : SanPhamDTO
    {
        public ChongNang(string maSP, string tenSP, double trongLuong, double giaBan, string xuatXu, DateTime ngaySX) : base(maSP, tenSP, trongLuong, giaBan, xuatXu, ngaySX)
        {
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine();
        }
    }
    interface IKhuyenMai
    {
        double KhuyenMai();
    }
}

