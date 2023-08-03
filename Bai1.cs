abstract class CanBo
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public string GioiTinh { get; set; }
    public string DiaChi { get; set; }


    public abstract void HienThiThongTin();
}


class CongNhan : CanBo
{
    public int Bac { get; set; }


    public override void HienThiThongTin()
    {
        System.Console.WriteLine("Ho ten: {0}", HoTen);
        System.Console.WriteLine("Tuoi: {0}", Tuoi);
        System.Console.WriteLine("Gioi tinh: {0}", GioiTinh);
        System.Console.WriteLine("Dia chi: {0}", DiaChi);
        System.Console.WriteLine("Bac: {0}", Bac);
    }
}


class KySu : CanBo
{
    public string NganhDaoTao { get; set; }


    public override void HienThiThongTin()
    {
        System.Console.WriteLine("Ho ten: {0}", HoTen);
        System.Console.WriteLine("Tuoi: {0}", Tuoi);
        System.Console.WriteLine("Gioi tinh: {0}", GioiTinh);
        System.Console.WriteLine("Dia chi: {0}", DiaChi);
        System.Console.WriteLine("Nganh dao tao: {0}", NganhDaoTao); ;
    }
}


class NhanVien : CanBo
{
    public string CongViec { get; set; }


    public override void HienThiThongTin()
    {
        System.Console.WriteLine("Ho ten: {0}", HoTen);
        System.Console.WriteLine("Tuoi: {0}", Tuoi);
        System.Console.WriteLine("Gioi tinh: {0}", GioiTinh);
        System.Console.WriteLine("Dia chi: {0}", DiaChi);
        System.Console.WriteLine("Cong viec: {0}", CongViec); ;
    }
}


class QLCB
{
    private List<CanBo> danhSachCanBo;


    public QLCB()
    {
        danhSachCanBo = new List<CanBo>();
    }


    public void ThemCanBo(CanBo canBo)
    {
        danhSachCanBo.Add(canBo);
    }


    public List<CanBo> TimKiemTheoTen(string ten)
    {
        return danhSachCanBo.FindAll(canBo => canBo.HoTen.Contains(ten));
    }


    public void HienThongTinDanhSachCanBo()
    {
        for (int i = 0; i < danhSachCanBo.Count; i++)
        {
            System.Console.WriteLine("Can bo {0}:", i + 1);
            danhSachCanBo[i].HienThiThongTin();
        }
    }
}

class Test
{
    public static void Main(string[] args)
    {
        QLCB qLCB = new QLCB();
        CanBo canbo1 = new NhanVien() {
            HoTen = "AB",
            Tuoi = 20,
            GioiTinh = "Nam",
            DiaChi = "Ha Noi",
            CongViec = "Dev"
        };
        CanBo canbo2 = new KySu() {
            HoTen = "BC",
            Tuoi = 22,
            GioiTinh = "Nu",
            DiaChi = "Ha Nam",
            NganhDaoTao = "CNTT"
        };
        CanBo canbo3 = new CongNhan() {
            HoTen = "AC",
            Tuoi = 24,
            GioiTinh = "Nam",
            DiaChi = "Ha Noi",
            Bac = 10
        }        ;
        qLCB.ThemCanBo(canbo1);
        qLCB.ThemCanBo(canbo2);
        qLCB.ThemCanBo(canbo3);
        List<CanBo> list = qLCB.TimKiemTheoTen("A");
        foreach(CanBo can in list) {
            can.HienThiThongTin();
        }
    }
}
