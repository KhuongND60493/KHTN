using System;
using System.Collections.Generic;

namespace TimHangGiaCaoNhat
{
    class Hang
    {
        private int maHang;
        private string tenHang;
        private double gia;

        public void nhapHang(string ghiChu)
        {
            Console.WriteLine(ghiChu);
            Console.Write("Nhap ma hang: ");
            this.maHang = int.Parse(Console.ReadLine());
            Console.Write("Nhap ten hang: ");
            this.tenHang = Console.ReadLine();
            Console.Write("Nhap gia hang: ");
            this.gia = double.Parse(Console.ReadLine());
        }

        public double giaHang()
        {
            return this.gia;
        }

        public string xuatThongTinHang()
        {
            return "(" + this.maHang + ") " + this.tenHang + "- gia " + this.gia;
        }
    }

    class DanhSachHang
    {
        private List<Hang> dsHang;

        public DanhSachHang()
        {
            this.dsHang = new List<Hang>();
        }

        public void nhapDanhSachHang(string ghiChu)
        {
            int N;
            Console.WriteLine(ghiChu);
            Console.Write("-> Nhap so luong hang: ");
            N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var hang = new Hang();
                hang.nhapHang($"-->Nhap hang thu {i + 1}: ");
                this.dsHang.Add(hang);
            }
        }

        public Hang timHangGiaCaoNhat()
        {
            Hang kq = null;
            foreach (var hang in this.dsHang)
            {
                if (kq == null)
                    kq = hang;
                if (hang.giaHang() > kq.giaHang())
                {
                    kq = hang;
                }
            }

            return kq;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DanhSachHang ds = new DanhSachHang();
            ds.nhapDanhSachHang("Hay nhap danh sach hang");
            Console.Write("Hang gia cao nhat " + ds.timHangGiaCaoNhat().xuatThongTinHang());
            Console.ReadLine();
        }
    }
}