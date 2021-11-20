using System;

namespace DiemTBHocSinhLonNhat
{
    using System;
    using System.Collections.Generic;

    class HocSinh
    {
        private int maHS;
        private string tenHS;
        private double diemTB;

        public void NhapHocSinh(string ghiChu)
        {
            Console.WriteLine(ghiChu);
            Console.Write("Nhap ma hoc sinh: ");
            this.maHS = int.Parse(Console.ReadLine());
            Console.Write("Nhap ten hoc sinh: ");
            this.tenHS = Console.ReadLine();
            Console.Write("Nhap diem trung binh hoc sinh: ");
            this.diemTB = double.Parse(Console.ReadLine());
        }

        public string infoHS()
        {
            return this.tenHS+" (MSHS:"+this.maHS+")"+ " voi so diem " + this.diemTB;
        }
        public double diemHS()
        {
            return this.diemTB;
        }
    }


    class DanhSanhHS
    {
        private List<HocSinh> dsHs;

        public DanhSanhHS()
        {
            dsHs = new List<HocSinh>();
        }

        public void Nhap(string ghiChu)
        {
            Console.WriteLine(ghiChu);
            int N;
            Console.Write("-> Nhap so luong hoc sinh: ");
            N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var hs = new HocSinh();
                hs.NhapHocSinh($"-->Nhap Hoc Sinh thu {i + 1}: ");
                this.dsHs.Add(hs);
            }
        }

        public HocSinh TimHocSinhDiemTBLonNhat()
        {
            HocSinh kq = null;
            foreach (var hs in this.dsHs)
            {
                if (kq == null)
                {
                    kq = hs;
                }
                else
                {
                    if (kq.diemHS() < hs.diemHS())
                        kq = hs;
                }
            }

            return kq;
        }
    }

    class Program
    {
        static void Main()
        {
            DanhSanhHS ds = new DanhSanhHS();
            ds.Nhap("Nhap danh sach hoc sinh: ");
            HocSinh kq = ds.TimHocSinhDiemTBLonNhat();
            if (kq != null)
            {
                Console.WriteLine($"Ket qua la {kq.infoHS()}");
            }
            else
            {
                Console.WriteLine($"Khong có hoc sinh nao");
            }

            Console.ReadLine();
        }
    }
}