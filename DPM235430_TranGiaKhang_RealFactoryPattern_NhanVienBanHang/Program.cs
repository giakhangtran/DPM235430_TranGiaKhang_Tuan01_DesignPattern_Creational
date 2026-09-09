namespace MSSV_HoTen_RealFactoryPattern_NhanVienBanHang
{
    // 1. Interface đại diện cho Nhân viên bán hàng (Product)
    public interface INhanVien
    {
        string HoTen { get; set; }
        double LuongCoBan { get; set; }
        double TinhTongThuNhap(double doanhSo);
        void InThongTin(double doanhSo);
    }

    // 2. Các loại nhân viên cụ thể (Concrete Products)
    // 2.1. Nhân viên thử việc (Hoa hồng 5%)
    public class NhanVienThuViec : INhanVien
    {
        public string HoTen { get; set; }
        public double LuongCoBan { get; set; }

        public NhanVienThuViec(string hoTen, double luongCoBan)
        {
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        public double TinhTongThuNhap(double doanhSo) => LuongCoBan + (doanhSo * 0.05);

        public void InThongTin(double doanhSo)
        {
            Console.WriteLine($"[Thử việc] {HoTen} | Lương CB: {LuongCoBan:N0}đ | Doanh số: {doanhSo:N0}đ | Thu nhập: {TinhTongThuNhap(doanhSo):N0}đ");
        }
    }

    // 2.2. Nhân viên chính thức (Hoa hồng 10%)
    public class NhanVienChinhThuc : INhanVien
    {
        public string HoTen { get; set; }
        public double LuongCoBan { get; set; }

        public NhanVienChinhThuc(string hoTen, double luongCoBan)
        {
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        public double TinhTongThuNhap(double doanhSo) => LuongCoBan + (doanhSo * 0.10);

        public void InThongTin(double doanhSo)
        {
            Console.WriteLine($"[Chính thức] {HoTen} | Lương CB: {LuongCoBan:N0}đ | Doanh số: {doanhSo:N0}đ | Thu nhập: {TinhTongThuNhap(doanhSo):N0}đ");
        }
    }

    // 2.3. Quản lý bán hàng (Hoa hồng 15% + thưởng chức vụ)
    public class QuanLyBanHang : INhanVien
    {
        public string HoTen { get; set; }
        public double LuongCoBan { get; set; }

        public QuanLyBanHang(string hoTen, double luongCoBan)
        {
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        public double TinhTongThuNhap(double doanhSo) => LuongCoBan + (doanhSo * 0.15) + 2000000;

        public void InThongTin(double doanhSo)
        {
            Console.WriteLine($"[Quản lý] {HoTen} | Lương CB: {LuongCoBan:N0}đ | Doanh số: {doanhSo:N0}đ | Thu nhập: {TinhTongThuNhap(doanhSo):N0}đ");
        }
    }

    // 3. Creator trừu tượng (Factory)
    public abstract class NhanVienFactory
    {
        public abstract INhanVien TaoNhanVien(string hoTen, double luongCoBan);
    }

    // 4. Các Concrete Factory cụ thể
    public class ThuViecFactory : NhanVienFactory
    {
        public override INhanVien TaoNhanVien(string hoTen, double luongCoBan) => new NhanVienThuViec(hoTen, luongCoBan);
    }

    public class ChinhThucFactory : NhanVienFactory
    {
        public override INhanVien TaoNhanVien(string hoTen, double luongCoBan) => new NhanVienChinhThuc(hoTen, luongCoBan);
    }

    public class QuanLyFactory : NhanVienFactory
    {
        public override INhanVien TaoNhanVien(string hoTen, double luongCoBan) => new QuanLyBanHang(hoTen, luongCoBan);
    }

    // 5. Chương trình chạy kiểm thử
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            NhanVienFactory factory;

            // Tạo nhân viên thử việc
            factory = new ThuViecFactory();
            INhanVien nv1 = factory.TaoNhanVien("Trần Văn An", 5000000);
            nv1.InThongTin(30000000);

            // Tạo nhân viên chính thức
            factory = new ChinhThucFactory();
            INhanVien nv2 = factory.TaoNhanVien("Lê Thị Bình", 8000000);
            nv2.InThongTin(60000000);

            // Tạo quản lý bán hàng
            factory = new QuanLyFactory();
            INhanVien nv3 = factory.TaoNhanVien("Nguyễn Hoàng Cường", 15000000);
            nv3.InThongTin(120000000);
        }
    }
}