using System;

namespace TinhTienThueCuaSach
{
    using System;
    using System.Collections.Generic;

    class LoadSach
    {
        public int maLoaiSach;
        public string tenLoaiSach;

        public LoadSach(int maLoaiSach, string tenLoaiSach)
        {
            this.maLoaiSach = maLoaiSach;
            this.tenLoaiSach = tenLoaiSach;
        }
    }

    class DanhSachLoaiSach
    {
        private List<LoadSach> dsLoaiSach;

        public DanhSachLoaiSach()
        {
            this.dsLoaiSach = new List<LoadSach>();
            this.dsLoaiSach.Add(new LoadSach(1, "Sach tieng anh"));
            this.dsLoaiSach.Add(new LoadSach(2, "Sach tieng viet"));
        }

        public string notiLoaiSach()
        {
            var noti = "";
            foreach (var loaiSach in this.dsLoaiSach)
            {
                noti += " Ma " + loaiSach.maLoaiSach + " (" + loaiSach.tenLoaiSach + ")";
            }

            return noti;
        }

        public int loaiSachTiengAnh()
        {
            return 1;
        }
    }

    class Sach
    {
        private int maSach;
        private int loadSach;
        private string tenSach;
        private double giaSach;

        public void nhapSach(string ghiChu, string ghiChuloaiSach)
        {
            Console.WriteLine(ghiChu);
            Console.Write("Nhap ma sach: ");
            this.maSach = int.Parse(Console.ReadLine());
            Console.Write("Nhap loai sach" + ghiChuloaiSach +": ");
            this.loadSach = int.Parse(Console.ReadLine());
            Console.Write("Nhap ten sach: ");
            this.tenSach = Console.ReadLine();
            Console.Write("Nhap gia sach: ");
            this.giaSach = double.Parse(Console.ReadLine());
        }

        public double thueSach(int sachTiengAnh)
        {
            if (this.loadSach == sachTiengAnh)
            {
                if (this.giaSach > 1000000)
                {
                    return this.giaSach * 10 / 100;
                }
                else
                {
                    return this.giaSach * 8 / 100;
                }
            }
            else
            {
                return this.giaSach * 5 / 100;
            }
        }
    }

    class DanhSachSach
    {
        private List<Sach> dsSach;
        private DanhSachLoaiSach dsLoaiSach;

        public DanhSachSach()
        {
            dsSach = new List<Sach>();
            dsLoaiSach = new DanhSachLoaiSach();
        }

        public void nhapDanhSach(string ghiChu)
        {
            Console.WriteLine(ghiChu);
            int N;
            Console.Write("-> Nhap so luong sach: ");
            N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var sach = new Sach();
                sach.nhapSach($"-->Nhap sach thu {i + 1}: ", dsLoaiSach.notiLoaiSach());
                this.dsSach.Add(sach);
            }
        }

        public double tongThueCanDong()
        {
            var kq = 0.0;
            foreach (var sach in this.dsSach)
            {
                kq += sach.thueSach(dsLoaiSach.loaiSachTiengAnh());
            }

            return kq;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DanhSachSach ds = new DanhSachSach();
            ds.nhapDanhSach("Hay nhap sach");
            double kq = ds.tongThueCanDong();
            Console.Write("-> So thue can dong: " + kq);
            Console.ReadLine();
        }
    }
}