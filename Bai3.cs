abstract class ThiSinh {
    public string SoBaoDanh {get; set;}
    public string HoTen {get; set;}
    public string DiaChi {get; set;}
    public int MucUuTien {get; set;}

    public abstract void HienThiThongTin();
}

class ThiSinhKhoiA : ThiSinh {
    public float DiemToan { get; set; }
    public float DiemLy { get; set; }
    public float DiemHoa { get; set; }

    public void NhapDiem(float diemToan, float diemLy, float diemHoa)
    {
        DiemToan = diemToan;
        DiemLy = diemLy;
        DiemHoa = diemHoa;
    }

    public override void HienThiThongTin()
    {
        System.Console.WriteLine("So bao danh: {0}", SoBaoDanh);
        System.Console.WriteLine("Ho ten: {0}", HoTen);
        System.Console.WriteLine("Dia chi: {0}", DiaChi);
        System.Console.WriteLine("Muc uu tien: {0}", MucUuTien);
        System.Console.WriteLine("Khoi: A");
    }
}

class ThiSinhKhoiB : ThiSinh {
    public float DiemToan { get; set; }
    public float DiemHoa { get; set; }
    public float DiemSinh { get; set; }

    public void NhapDiem(float diemToan, float diemHoa, float diemSinh)
    {
        DiemToan = diemToan;
        DiemHoa = diemHoa;
        DiemSinh = diemSinh;
    }

    public override void HienThiThongTin()
    {
        System.Console.WriteLine("So bao danh: {0}", SoBaoDanh);
        System.Console.WriteLine("Ho ten: {0}", HoTen);
        System.Console.WriteLine("Dia chi: {0}", DiaChi);
        System.Console.WriteLine("Muc uu tien: {0}", MucUuTien);
        System.Console.WriteLine("Khoi: B");
    }
}

class ThiSinhKhoiC : ThiSinh {
    public float DiemVan { get; set; }
    public float DiemSu { get; set; }
    public float DiemDia { get; set; }

    public void NhapDiem(float diemVan, float diemSu, float diemDia)
    {
        DiemVan = diemVan;
        DiemSu = diemSu;
        DiemDia = diemDia;
    }

    public override void HienThiThongTin()
    {
        System.Console.WriteLine("So bao danh: {0}", SoBaoDanh);
        System.Console.WriteLine("Ho ten: {0}", HoTen);
        System.Console.WriteLine("Dia chi: {0}", DiaChi);
        System.Console.WriteLine("Muc uu tien: {0}", MucUuTien);
        System.Console.WriteLine("Khoi: C");
    }
}

class TuyenSinh
{
    private static List<ThiSinh> danhSachThiSinh;
    
    static TuyenSinh()
    {
        danhSachThiSinh = new List<ThiSinh>();
    }

    public void ThemMoiThiSinh(ThiSinh thiSinh)
    {
        danhSachThiSinh.Add(thiSinh);
    }

    public ThiSinh TimKiemTheoSoBaoDanh(string soBaoDanh)
    {
        return danhSachThiSinh.Find(x => x.SoBaoDanh == soBaoDanh);
    }
}

public interface IFormThemThiSinh
{
    void ThemThiSinh();
}

public class FormThemThiSinhA : IFormThemThiSinh
{
    private TuyenSinh tuyenSinh;
    public FormThemThiSinhA()
    {
        tuyenSinh = new TuyenSinh();
    }
    public void ThemThiSinh()
    {
        ThiSinhKhoiA thiSinhKhoiA = new ThiSinhKhoiA();
        System.Console.WriteLine("Them moi thi sinh Khoi A:");
        Console.Write("So bao danh: ");
        thiSinhKhoiA.SoBaoDanh = Console.ReadLine();
        Console.Write("Ho ten: ");
        thiSinhKhoiA.HoTen = Console.ReadLine();
        Console.Write("Dia chi: ");
        thiSinhKhoiA.DiaChi = Console.ReadLine();
        Console.Write("Muc uu tien: ");
        int i;
        while(!Int32.TryParse(Console.ReadLine(), out i))
        {
            System.Console.Write("Nhap lai muc uu tien: ");
        }
        thiSinhKhoiA.MucUuTien = i;
        tuyenSinh.ThemMoiThiSinh(thiSinhKhoiA);
    }
}

public class FormThemThiSinhB : IFormThemThiSinh
{
    private TuyenSinh tuyenSinh;
    public FormThemThiSinhB()
    {
        tuyenSinh = new TuyenSinh();
    }
    public void ThemThiSinh()
    {
        ThiSinhKhoiB thiSinh = new ThiSinhKhoiB();
        System.Console.WriteLine("Them moi thi sinh Khoi B:");
        Console.Write("So bao danh: ");
        thiSinh.SoBaoDanh = Console.ReadLine();
        Console.Write("Ho ten: ");
        thiSinh.HoTen = Console.ReadLine();
        Console.Write("Dia chi: ");
        thiSinh.DiaChi = Console.ReadLine();
        Console.Write("Muc uu tien: ");
        int i;
        while(!Int32.TryParse(Console.ReadLine(), out i))
        {
            System.Console.Write("Nhap lai muc uu tien: ");
        }
        thiSinh.MucUuTien = i;
        tuyenSinh.ThemMoiThiSinh(thiSinh);
    }
}

public class FormThemThiSinhC : IFormThemThiSinh
{
    private TuyenSinh tuyenSinh;
    public FormThemThiSinhC()
    {
        tuyenSinh = new TuyenSinh();
    }
    public void ThemThiSinh()
    {
        ThiSinhKhoiC thiSinh = new ThiSinhKhoiC();
        System.Console.WriteLine("Them moi thi sinh Khoi C:");
        Console.Write("So bao danh: ");
        thiSinh.SoBaoDanh = Console.ReadLine();
        Console.Write("Ho ten: ");
        thiSinh.HoTen = Console.ReadLine();
        Console.Write("Dia chi: ");
        thiSinh.DiaChi = Console.ReadLine();
        Console.Write("Muc uu tien: ");
        int i;
        while(!Int32.TryParse(Console.ReadLine(), out i))
        {
            System.Console.Write("Nhap lai muc uu tien: ");
        }
        thiSinh.MucUuTien = i;
        tuyenSinh.ThemMoiThiSinh(thiSinh);
    }
}

public class FormTimKiemThiSinh
{
    private TuyenSinh tuyenSinh;
    public FormTimKiemThiSinh()
    {
        tuyenSinh = new TuyenSinh();
    }
    public void TimKiemThiSinh()
    {
        System.Console.WriteLine("Tim kiem thi sinh:");
        Console.Write("So bao danh: ");
        string soBaoDanh = Console.ReadLine();
        ThiSinh thiSinh = tuyenSinh.TimKiemTheoSoBaoDanh(soBaoDanh);
        if (thiSinh!= null)
        {
            thiSinh.HienThiThongTin();
        }
        else
        {
            System.Console.WriteLine("Khong tim thay thi sinh");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Them thi sinh khoi A");
            Console.WriteLine("2. Them thi sinh khoi B");
            Console.WriteLine("3. Them thi sinh khoi C");
            Console.WriteLine("4. Tim kiem thi sinh");  
            Console.WriteLine("5. Exit");
            Console.Write("Nhap chuc nang: ");
            int chucNang;
            while (!Int32.TryParse(Console.ReadLine(), out chucNang))
            {
                System.Console.Write("Nhap lai chuc nang: ");
            }
            switch (chucNang)
            {
                case 1: {
                    FormThemThiSinhA formThemThiSinhA = new FormThemThiSinhA();
                    formThemThiSinhA.ThemThiSinh();
                    break;
                }
                case 2: {
                    FormThemThiSinhB formThemThiSinhB = new FormThemThiSinhB();
                    formThemThiSinhB.ThemThiSinh();
                    break;
                }
                case 3: {
                    FormThemThiSinhC formThemThiSinhC = new FormThemThiSinhC();
                    formThemThiSinhC.ThemThiSinh();
                    break;
                }
                case 4: {
                    FormTimKiemThiSinh formTimKiemThiSinh = new FormTimKiemThiSinh();
                    formTimKiemThiSinh.TimKiemThiSinh();
                    break;
                }
                case 5: {
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