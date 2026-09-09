namespace MSSV_HoTen_RealAbstractFactoryPattern_BanHang
{
    // Sản phẩm 1: Hoá đơn
    public interface IHoaDon { void InHoaDon(double tongTien); }
    public class HoaDonTaiQuay : IHoaDon
    {
        public void InHoaDon(double tongTien) => Console.WriteLine($"[Tại quầy] In hoá đơn giấy - Tổng tiền: {tongTien:N0}đ");
    }
    public class HoaDonDienTu : IHoaDon
    {
        public void InHoaDon(double tongTien) => Console.WriteLine($"[Online] Gửi hoá đơn điện tử qua Email/SMS - Tổng tiền: {tongTien:N0}đ");
    }

    // Sản phẩm 2: Vận chuyển
    public interface IVanChuyen { void GiaoHang(); }
    public class NhanTaiQuay : IVanChuyen
    {
        public void GiaoHang() => Console.WriteLine("[Vận chuyển] Khách lấy hàng trực tiếp tại quầy thu ngân.");
    }
    public class GiaoHangNhanh : IVanChuyen
    {
        public void GiaoHang() => Console.WriteLine("[Vận chuyển] Đẩy đơn qua bên thứ ba (GHN, Viettel Post).");
    }

    // Abstract Factory
    public interface IBanHangFactory
    {
        IHoaDon TaoHoaDon();
        IVanChuyen TaoVanChuyen();
    }

    public class BanHangTaiQuayFactory : IBanHangFactory
    {
        public IHoaDon TaoHoaDon() => new HoaDonTaiQuay();
        public IVanChuyen TaoVanChuyen() => new NhanTaiQuay();
    }

    public class BanHangOnlineFactory : IBanHangFactory
    {
        public IHoaDon TaoHoaDon() => new HoaDonDienTu();
        public IVanChuyen TaoVanChuyen() => new GiaoHangNhanh();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- XỬ LÝ ĐƠN HÀNG TẠI QUẦY ---");
            XuLyDonHang(new BanHangTaiQuayFactory(), 450000);

            Console.WriteLine("\n--- XỬ LÝ ĐƠN HÀNG ONLINE ---");
            XuLyDonHang(new BanHangOnlineFactory(), 1200000);
        }

        static void XuLyDonHang(IBanHangFactory factory, double tongTien)
        {
            var hoaDon = factory.TaoHoaDon();
            var vanChuyen = factory.TaoVanChuyen();

            hoaDon.InHoaDon(tongTien);
            vanChuyen.GiaoHang();
        }
    }
}