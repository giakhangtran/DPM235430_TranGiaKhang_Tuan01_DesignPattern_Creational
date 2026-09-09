namespace MSSV_HoTen_RealBuilderPattern_BanHang
{
    public class DonHang
    {
        public List<string> DanhSachMatHang { get; set; } = new List<string>();
        public bool DongGoiHopQua { get; set; }
        public string MaGiamGia { get; set; } = "Không có";
        public string HinhThucGiao { get; set; } = "Tiêu chuẩn";

        public void HienThiDonHang()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Mặt hàng: {string.Join(", ", DanhSachMatHang)}");
            Console.WriteLine($"Gói quà: {(DongGoiHopQua ? "Có (kèm thiệp)" : "Không")}");
            Console.WriteLine($"Mã voucher: {MaGiamGia}");
            Console.WriteLine($"Giao hàng: {HinhThucGiao}");
            Console.WriteLine("------------------------------------------");
        }
    }

    public interface IDonHangBuilder
    {
        IDonHangBuilder ThemSanPham(string tenSp);
        IDonHangBuilder ThemGoiQua();
        IDonHangBuilder ApDungVoucher(string code);
        IDonHangBuilder ChonGiaoHoaToc();
        DonHang Build();
    }

    public class DonHangBuilder : IDonHangBuilder
    {
        private DonHang _donHang = new DonHang();

        public IDonHangBuilder ThemSanPham(string tenSp)
        {
            _donHang.DanhSachMatHang.Add(tenSp);
            return this;
        }

        public IDonHangBuilder ThemGoiQua()
        {
            _donHang.DongGoiHopQua = true;
            return this;
        }

        public IDonHangBuilder ApDungVoucher(string code)
        {
            _donHang.MaGiamGia = code;
            return this;
        }

        public IDonHangBuilder ChonGiaoHoaToc()
        {
            _donHang.HinhThucGiao = "Hoả tốc 2h";
            return this;
        }

        public DonHang Build()
        {
            DonHang result = _donHang;
            _donHang = new DonHang();
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var builder = new DonHangBuilder();

            Console.WriteLine("1. Đơn hàng tiêu chuẩn:");
            var don1 = builder.ThemSanPham("Bàn phím cơ")
                              .ThemSanPham("Chuột không dây")
                              .Build();
            don1.HienThiDonHang();

            Console.WriteLine("\n2. Đơn hàng VIP (Gói quà + Voucher + Hoả tốc):");
            var don2 = builder.ThemSanPham("Laptop Dell XPS")
                              .ThemGoiQua()
                              .ApDungVoucher("GIAM100K")
                              .ChonGiaoHoaToc()
                              .Build();
            don2.HienThiDonHang();
        }
    }
}