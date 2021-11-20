using System;

namespace TinhChuViTamGiac
{
    class Diem
    {
        public int X;
        public int Y;
        public void NhapDiem(string ghiChu)
        {
            Console.WriteLine(ghiChu);
            Console.Write("Nhap toa do X: ");
            X = int.Parse(Console.ReadLine());
            Console.Write("Nhap toa do Y: ");
            Y = int.Parse(Console.ReadLine());
        }
        public double TinhKhoangCach(Diem B)
        {
            return Math.Sqrt(Math.Pow(X - B.X, 2) + Math.Pow(Y - B.Y, 2));
        }
    }
    class TamGiac
    {
        public Diem A;
        public Diem B;
        public Diem C;
    
        public void NhapTamGiac(string ghiChu)
        {
            Console.WriteLine(ghiChu);
            this.A = new Diem();
            this.A.NhapDiem("Nhap diem A: ");
            this.B = new Diem();
            this.B.NhapDiem("Nhap diem B: ");
            this.C = new Diem();
            this.C.NhapDiem("Nhap diem C: ");
        }
        public double TinhChuVi()
        {
            
            double kq = 0;
            kq += this.A.TinhKhoangCach(this.B);
            kq += this.B.TinhKhoangCach(this.C);
            kq += this.C.TinhKhoangCach(this.A);
            return kq;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            TamGiac T = new TamGiac();
            T.NhapTamGiac("Nhap tam giac: ");
            double kq = T.TinhChuVi();
            string chuoi = "Ket qua la: " + kq;
            Console.WriteLine(chuoi);
            Console.ReadLine();
        }
    }
}