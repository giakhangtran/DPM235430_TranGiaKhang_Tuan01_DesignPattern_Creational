namespace MSSV_HoTen_RealSingletonPattern_BanHang
{
    // Bộ cấu hình hệ thống bán hàng duy nhất dùng chung toàn app
    public sealed class CauHinhBanHang
    {
        private static CauHinhBanHang _instance;
        private static readonly object _lock = new object();

        public string TenCuaHang { get; set; }
        public double PhanTramThueVAT { get; set; }
        public string TrangThaiKetNoiDB { get; private set; }

        private CauHinhBanHang()
        {
            TenCuaHang = "Cửa Hàng Tiện Lợi 24/7";
            PhanTramThueVAT = 0.08; // VAT 8%
            TrangThaiKetNoiDB = "Connected (Server=DB_BAN_HANG;Database=SalesDB)";
        }

        public static CauHinhBanHang Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new CauHinhBanHang();
                        }
                    }
                }
                return _instance;
            }
        }

        public double TinhTienSauThue(double tongTienChuaThue)
        {
            return tongTienChuaThue + (tongTienChuaThue * PhanTramThueVAT);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Module Thu ngân gọi cấu hình
            var configThuNgan = CauHinhBanHang.Instance;
            Console.WriteLine($"[Thu ngân] Tên cửa hàng: {configThuNgan.TenCuaHang}");
            Console.WriteLine($"[Thu ngân] DB: {configThuNgan.TrangThaiKetNoiDB}");
            Console.WriteLine($"[Thu ngân] Đơn hàng 500,000đ sau thuế: {configThuNgan.TinhTienSauThue(500000):N0}đ");

            // Module Kế toán kiểm tra lại thể hiện (instance)
            var configKeToan = CauHinhBanHang.Instance;
            Console.WriteLine($"\n[Kế toán] Kiểm tra dùng chung instance: {ReferenceEquals(configThuNgan, configKeToan)}");
        }
    }
}