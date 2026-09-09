namespace MSSV_HoTen_RealPrototypePattern_BanHang
{
    public class DonHangDinhKy : ICloneable
    {
        public string KhachHang { get; set; }
        public List<string> DanhSachSP { get; set; }
        public double TongTien { get; set; }

        public DonHangDinhKy(string khachHang, List<string> danhSachSP, double tongTien)
        {
            KhachHang = khachHang;
            DanhSachSP = danhSachSP;
            TongTien = tongTien;
        }

        // Deep copy để tránh đụng chạm danh sách sản phẩm khi sửa
        public object Clone()
        {
            return new DonHangDinhKy(
                this.KhachHang,
                new List<string>(this.DanhSachSP),
                this.TongTien
            );
        }

        public void InChiTiet(string tenDot)
        {
            Console.WriteLine($"[{tenDot}] Khách: {KhachHang} | SP: {string.Join(", ", DanhSachSP)} | Tổng: {TongTien:N0}đ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Đơn mẫu cấu hình sẵn
            var donMauTuan = new DonHangDinhKy("Đại lý Cần Thơ", new List<string> { "Cà phê Robusta (10kg)", "Sữa đặc (5 thùng)" }, 8500000);
            donMauTuan.InChiTiet("Đơn mẫu gốc");

            // Sao chép sang tuần 1
            var donTuan1 = (DonHangDinhKy)donMauTuan.Clone();
            donTuan1.InChiTiet("Giao Tuần 1");

            // Sao chép sang tuần 2 và bổ sung hàng phát sinh
            var donTuan2 = (DonHangDinhKy)donMauTuan.Clone();
            donTuan2.DanhSachSP.Add("Trà lài (2kg)");
            donTuan2.TongTien += 500000;
            donTuan2.InChiTiet("Giao Tuần 2 (đã sửa)");
        }
    }
}