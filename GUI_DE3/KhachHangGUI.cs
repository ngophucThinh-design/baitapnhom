using BLL_DE3;
using DTO_DE3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DE3
{
    public class KhachHangGUI
    {
        KhachHangBLL khachhangbll = new KhachHangBLL();
        public void showListKH(List<KhachHangDTO> lkh)
        {
            Console.WriteLine($"{"Ma KH",-10}{"Ten KH",-30}{"So DT",-15}");
            Console.WriteLine("======================================================================================================================");
            foreach (KhachHangDTO a in lkh)
            {
                a.Xuat();
            }
        }
        public List<KhachHangDTO> getlistKH()
        {
            return khachhangbll.getlistKhachHang();
        }
        public void DSKH()
        {
            showListKH(khachhangbll.DSKH());
        }
    }
}
