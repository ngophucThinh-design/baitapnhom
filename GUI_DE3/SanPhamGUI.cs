using DTO_DE3;
using BLL_DE3;
using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;

namespace GUI_DE3
{
    public class SanPhamGUI
    {
        SanPhamBLL sanphambll = new SanPhamBLL();

        public void showListSP(List<SanPhamDTO> splist)
        {

            Console.OutputEncoding = UnicodeEncoding.Unicode;

            Console.WriteLine($"{"Ma SP",-10}{"Ten SP",-25}{"Trong luong",-13}{"Gia ban",-10}{"Xuat xu",-20}{"Ngay SX",-13}{"ThanhTienSP",-13}{"Khuyen mai",-10}");
            Console.WriteLine("======================================================================================================================");
            foreach (SanPhamDTO a in splist)
            {
                a.Xuat();
            }
        }
        public List<SanPhamDTO> getlistSP()
        {
            return sanphambll.getListSanPham();
        }
        public void DSSP()
        {
            showListSP(sanphambll.DSSP());
        }
        public void ThemSanPhamMoi()
        {
            Console.WriteLine("Nhap ma san pham: ");
            string ma = Console.ReadLine();
            Console.WriteLine("Nhap ten san pham: ");
            string ten = Console.ReadLine();
            Console.WriteLine("Nhap trong luong san pham: ");
            double trongluong = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap gia ban san pham: ");
            double gia = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap xuat xu san pham: ");
            string xuatxu = Console.ReadLine();
            Console.WriteLine("Nhap ngay san xuat san pham: ");
            DateTime ngaysx = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("Nhap loai san pham: ");
            int loai = int.Parse(Console.ReadLine());
            if (loai == 1)
            {
                sanphambll.ThemSanPhamMoi(new ChamSocDa(ma, ten, trongluong, gia, xuatxu, ngaysx));
            }
            else if (loai == 2)
            {
                sanphambll.ThemSanPhamMoi(new TrangDiem(ma, ten, trongluong, gia, xuatxu, ngaysx));
            }
            else
            {
                sanphambll.ThemSanPhamMoi(new ChongNang(ma, ten, trongluong, gia, xuatxu, ngaysx));
            }
        }

        public void TimSanPhamTheoXuatXu()
        {
            Console.WriteLine("Nhap xuat xu cua san pham can tim: ");
            string xuatxu = Console.ReadLine();
            List<SanPhamDTO> sp = sanphambll.TimSanPhamTheoXuatXu(xuatxu);
            showListSP(sp);
        }
        public void CapNhatGia()
        {
            try
            {
                sanphambll.CapNhatGia();
                Console.WriteLine("Cap nhat thanh cong.");
                Console.WriteLine("DSSP sau khi cap nhat:");
                DSSP();
            }
            catch
            {
                Console.WriteLine("Cap nhat that bai.");
            }
        }
        public void GiaBanTren300()
        {
            Console.WriteLine("DANH SACH SAN PHAM CO GIA BAN TREN 300: ");
            List<SanPhamDTO> spv = sanphambll.GiaBanTren300();
            showListSP(spv);
        }
        public void SanPhamTrangDiem()
        {
            Console.WriteLine("DANH SACH SAN PHAM LOAI TRANG DIEM: ");
            List<TrangDiem> sptd = sanphambll.SanPhamTrangDiem();
            Console.WriteLine($"{"Ma SP",-10}{"Ten SP",-25}{"Trong luong",-13}{"Gia ban",-10}{"Xuat xu",-20}{"Ngay SX",-13}{"ThanhTienSP",-13}{"Khuyen mai",-10}");
            Console.WriteLine("======================================================================================================================");
            foreach (TrangDiem a in sptd)
            {
                a.Xuat();
            }
        }
        public void SanPhamTren3Thang()
        {
            Console.WriteLine("DANH SACH SAN PHAM TREN 3 THANG: ");
            List<SanPhamDTO> sphsd = sanphambll.SanPhamtren3Thang();
            showListSP(sphsd);
        }
    }


}
