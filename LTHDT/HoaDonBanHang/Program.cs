using System;

namespace HoaDonBanHang
{
    using System;
    using System.Collections.Generic;

    class Hang
    {
        private int maHang;
        private int loaiHang;
        private int VATDacBiet;
        private string tenHang;
        private double giaHang;

        public void nhapHang(string ghiChu)
        {
            Console.WriteLine(ghiChu);
            Console.Write("Nhap ma hang: ");
            this.maHang = int.Parse(Console.ReadLine());
            Console.Write("Nhap ten hang: ");
            this.tenHang = Console.ReadLine();
            Console.Write("Nhap loai (1: hang binh thuong, 2: hang dac biet): ");
            this.loaiHang = int.Parse(Console.ReadLine());
            if (this.loaiHang == 2)
            {
                Console.Write("Nhap thue cua hang dac biet: ");
                this.VATDacBiet = int.Parse(Console.ReadLine());
            }
            else
            {
                this.VATDacBiet = 0;
            }

            Console.Write("Nhap gia hang: ");
            this.giaHang = double.Parse(Console.ReadLine());
        }

        public double tienSauThue()
        {
            var kq = this.giaHang * 105 / 100;
            var thueDB = 0.0;
            if (this.loaiHang == 2)
            {
                thueDB = this.giaHang * this.VATDacBiet / 100;
            }

            return kq + thueDB;
        }
    }

    class HoaDon
    {
        private int maHD;
        private string nguoiMua;
        private DateTime ngayLapHD;
        private List<Hang> dsHang;
        private double tongTien;

        public HoaDon()
        {
            this.dsHang = new List<Hang>();
            this.ngayLapHD = new DateTime();
        }

        public void nhapHoaDon(string ghiChu)
        {
            int N;
            Console.WriteLine(ghiChu);
            Console.Write("Nhap ma hoa don: ");
            this.maHD = int.Parse(Console.ReadLine());
            Console.Write("Nhap nguoi mua: ");
            this.nguoiMua = Console.ReadLine();
          
            Console.Write("-> Nhap so luong hang: ");
            N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var hang = new Hang();
                hang.nhapHang($"-->Nhap hang thu {i + 1}: ");
                this.dsHang.Add(hang);
            }
        }

        public void tinhTongTien()
        {
            var kq = 0.0;
            foreach (var sach in this.dsHang)
            {
                kq += sach.tienSauThue();
            }

            this.tongTien = kq;
        }

        public string xuatTongTien()
        {
            return "Tong tien cua hoa dong la " + this.tongTien;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HoaDon hd = new HoaDon();
            hd.nhapHoaDon("Hay hoa don");
            hd.tinhTongTien();
            Console.Write(hd.xuatTongTien());
            Console.ReadLine();
        }
    }
}