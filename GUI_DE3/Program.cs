using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_DE3;
using DTO_DE3;

namespace GUI_DE3
{
    public class Program
    {
        static void menu()
        {
            Console.WriteLine("1.Doc du lieu tu file. ");
            Console.WriteLine("2.Them san pham.");
            Console.WriteLine("3.Xuat DSSP co trong cua hang.");
            Console.WriteLine("4.Tim kiem san pham khi biet noi xuat xu.");
            Console.WriteLine("5.DSSP khach hang da mua.");
            Console.WriteLine("6.Cap nhat gia ban cho san pham loai trang diem");
            Console.WriteLine("7.Danh sach san pham co gia ban tren 300");
            Console.WriteLine("8.DSSP thuoc loai trang diem");
            Console.WriteLine("9.DSKH mua nhieu hon 3 san pham. ");
            Console.WriteLine("10.DSSP co ngay san xuat tren 3 thang");
            Console.WriteLine("11.Khach hang mua nhieu tiẻn nhat.");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            SanPhamGUI spgui = new SanPhamGUI();
            KhachHangGUI kh = new KhachHangGUI();
            HoaDonGUI hoaDongui = new HoaDonGUI();
            int chon;
            menu();
            do
            {
                Console.WriteLine();
                Console.WriteLine("Nhap lua chon:");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        {
                            spgui.getlistSP();
                            kh.getlistKH();
                            hoaDongui.getListHD(kh.getlistKH(), spgui.getlistSP());
                            break;
                        }
                    case 2:
                        {
                            spgui.ThemSanPhamMoi();
                            break;
                        }
                    case 3:
                        {
                            spgui.DSSP();
                            Console.WriteLine();
                            kh.DSKH();
                            break;
                        }
                    case 4:
                        {
                            spgui.TimSanPhamTheoXuatXu();
                            break;
                        }
                    case 5:
                        {
                            hoaDongui.SanPhamKHDaMua(); break;
                        }
                    case 6:
                        {
                            spgui.CapNhatGia();
                            break;
                        }
                    case 7:
                        {
                            spgui.GiaBanTren300(); break;
                        }
                    case 8:
                        {
                            spgui.SanPhamTrangDiem(); break;
                        }
                    case 9:
                        {
                            hoaDongui.MuaNhieuHon3SP(); break;
                        }
                    case 10:
                        {
                            spgui.SanPhamTren3Thang(); break;
                        }
                    case 11:
                        {
                            hoaDongui.MuaNhieuNhat(); break;
                        }

                }
            } while (true);
            Console.ReadKey();
        }

    }
}
