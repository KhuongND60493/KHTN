using System;
using System.Globalization;

namespace TinhTuoiDocGia
{
    class DocGia
    {
        private int maDG;
        private string hotenDG;
        private string diaChiDG;
        private string cmndDG;
        private string ngaySinh;

        public void nhapDocGia(string ghiChu)
        {
            Console.WriteLine(ghiChu);
            Console.Write("Nhap ma doc gia: ");
            this.maDG = int.Parse(Console.ReadLine());
            Console.Write("Nhap ten doc gia: ");
            this.hotenDG = Console.ReadLine();
            Console.Write("Nhap dia chi doc gia: ");
            this.diaChiDG = Console.ReadLine();
            Console.Write("Nhap cmnd doc gia: ");
            this.cmndDG = Console.ReadLine();
            Console.Write("Nhap ngay sinh (dd/MM/YYYY): ");
            this.ngaySinh = Console.ReadLine();
        }

        public int tinhTuoi(int currentYear)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime ngaySinh = DateTime.ParseExact(this.ngaySinh, "dd/MM/yyyy", provider);
            return currentYear - ngaySinh.Year;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            DocGia ds = new DocGia();
            ds.nhapDocGia("Hay nhap thong tin doc gia: ");
            double kq = ds.tinhTuoi(2013);
            Console.Write("-> Tuoi doc gia: " + kq);
            Console.ReadLine();
        }
    }
}