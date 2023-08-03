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
    private static List<CanBo> danhSachCanBo;


    static QLCB()
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


    public List<CanBo> DanhSachCanBo()
    {
        return danhSachCanBo;
    }
}

public interface IFormThemCanBo
{
    void ThemCanBo();
}

public class FormThemCongNhan : IFormThemCanBo
{
    private QLCB qLCB;

    public FormThemCongNhan()
    {
        qLCB = new QLCB();
    }
    public void ThemCanBo()
    {
        CongNhan canBo = new CongNhan();
        Console.WriteLine("Form them cong nhan:");
        Console.Write("Ho ten: ");
        canBo.HoTen = Console.ReadLine();
        Console.Write("Tuoi: ");
        int tuoi;
        while (!Int32.TryParse(Console.ReadLine(), out tuoi))
        {
            System.Console.Write("Nhap lai tuoi: ");
        }
        canBo.Tuoi = tuoi;
        Console.Write("Gioi tinh: ");
        canBo.GioiTinh = Console.ReadLine();
        Console.Write("Dia chi: ");
        canBo.DiaChi = Console.ReadLine();
        Console.Write("Bac: ");
        int bac;
        while (!Int32.TryParse(Console.ReadLine(), out bac))
        {
            System.Console.Write("Nhap lai bac: ");
        }
        canBo.Bac = bac;

        qLCB.ThemCanBo(canBo);
        System.Console.WriteLine("Them can bo thanh cong");
    }
}

public class FormThemKySu : IFormThemCanBo
{
    private QLCB qLCB;

    public FormThemKySu()
    {
        qLCB = new QLCB();
    }
    public void ThemCanBo()
    {
        KySu canBo = new KySu();
        Console.WriteLine("Form them ky su:");
        Console.Write("Ho ten: ");
        canBo.HoTen = Console.ReadLine();
        Console.Write("Tuoi: ");
        int tuoi;
        while (!Int32.TryParse(Console.ReadLine(), out tuoi))
        {
            System.Console.Write("Nhap lai tuoi: ");
        }
        canBo.Tuoi = tuoi;
        Console.Write("Gioi tinh: ");
        canBo.GioiTinh = Console.ReadLine();
        Console.Write("Dia chi: ");
        canBo.DiaChi = Console.ReadLine();
        Console.Write("Nganh dao tao: ");
        canBo.NganhDaoTao = Console.ReadLine();

        qLCB.ThemCanBo(canBo);
        System.Console.WriteLine("Them can bo thanh cong");
    }
}

public class FormThemNhanVien : IFormThemCanBo
{
    private QLCB qLCB;

    public FormThemNhanVien()
    {
        qLCB = new QLCB();
    }
    public void ThemCanBo()
    {
        NhanVien canBo = new NhanVien();
        Console.WriteLine("Form them ky su:");
        Console.Write("Ho ten: ");
        canBo.HoTen = Console.ReadLine();
        Console.Write("Tuoi: ");
        int tuoi;
        while (!Int32.TryParse(Console.ReadLine(), out tuoi))
        {
            System.Console.Write("Nhap lai tuoi: ");
        }
        canBo.Tuoi = tuoi;
        Console.Write("Gioi tinh: ");
        canBo.GioiTinh = Console.ReadLine();
        Console.Write("Dia chi: ");
        canBo.DiaChi = Console.ReadLine();
        Console.Write("Cong viec: ");
        canBo.CongViec = Console.ReadLine();

        qLCB.ThemCanBo(canBo);
        System.Console.WriteLine("Them can bo thanh cong");
    }
}

public class FormCanBo
{
    private QLCB qLCB;
    public FormCanBo()
    {
        qLCB = new QLCB();
    }
    public void HienThiDanhSachCanBoTheoTen(string ten)
    {
        List<CanBo> danhSachCanBo = qLCB.TimKiemTheoTen(ten);
        foreach (CanBo canBo in danhSachCanBo)
        {
            System.Console.WriteLine("Can bo {0}:", i + 1);
            canBo.HienThiThongTin();
        }
    }
}

public class DanhSachCanBo
{
    private QLCB qLCB;
    public DanhSachCanBo()
    {
        qLCB = new QLCB();
    }
    public void HienThiDanhSachCanBo()
    {
        List<CanBo> list = qLCB.DanhSachCanBo();
        for (int i = 0; i < list.Count; i++)
        {
            System.Console.WriteLine("Can bo {0}:", i + 1);
            list[i].HienThiThongTin();
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Them cong nhan");
            Console.WriteLine("2. Them ky su");
            Console.WriteLine("3. Them nhan vien");
            Console.WriteLine("4. Tim kiem can bo theo ten");
            Console.WriteLine("5. Xuat danh sach can bo");
            Console.WriteLine("6. Thoat");
            Console.Write("Nhap chuc nang: ");
            int chucNang;
            while (!Int32.TryParse(Console.ReadLine(), out chucNang))
            {
                System.Console.Write("Nhap lai chuc nang: ");
            }
            switch (chucNang)
            {
                case 1: {
                    FormThemCongNhan formThemCongNhan = new FormThemCongNhan();
                    formThemCongNhan.ThemCanBo();
                    break;
                }
                case 2: {
                    FormThemKySu formThemKySu = new FormThemKySu();
                    formThemKySu.ThemCanBo();
                    break;
                }
                case 3: {
                    FormThemNhanVien formThemNhanVien = new FormThemNhanVien();
                    formThemNhanVien.ThemCanBo();
                    break;
                }
                case 4: {
                    FormCanBo formCanBo = new FormCanBo();
                    Console.Write("Nhap ten can bo: ");
                    string ten = Console.ReadLine();
                    formCanBo.HienThiDanhSachCanBoTheoTen(ten);
                    break;
                }
                case 5: {
                    DanhSachCanBo danhSachCanBo = new DanhSachCanBo();
                    danhSachCanBo.HienThiDanhSachCanBo();
                    break;
                }
                case 6: {
                    return;
                }
                default: {
                    System.Console.WriteLine("Chuc nang khong hop le");
                    break;
                }
            }
        }
    }
}
