class HocSinh
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public string QueQuan { get; set; }
    public int Lop {get; set;}

    public HocSinh(string hoTen, int tuoi, string queQuan, int lop)
    {
        HoTen = hoTen;
        Tuoi = tuoi;
        QueQuan = queQuan;
        Lop = lop;
    }
}

class TruongTHPT
{
    private static List<HocSinh> danhSachHocSinh;

    static TruongTHPT()
    {
        danhSachHocSinh = new List<HocSinh>();
    }

    public void ThemHocSinh(HocSinh hocSinh)
    {
        danhSachHocSinh.Add(hocSinh);
    }

    public List<HocSinh> GetHocSinhByTuoi(int tuoi)
    {
        return danhSachHocSinh.Where(hs => hs.Tuoi == tuoi).ToList();
    }

    public List<HocSinh> GetHocSinhByTuoiVaQue(int tuoi, string queQuan)
    {
        return danhSachHocSinh.Where(hs => hs.Tuoi == tuoi && hs.QueQuan == queQuan).ToList();
    }
}

public class DanhSachHocSinhScreen
{
    private TruongTHPT truongTHPT;
    public DanhSachHocSinhScreen()
    {
        truongTHPT = new TruongTHPT();
    }

    public void HienThiDanhSachHocSinhByTuoi()
    {
        Console.WriteLine("Danh sách học sinh theo tuổi");
        Console.Write("Nhap tuoi: ");
        int tuoi;
        while(!Int32.TryParse(Console.ReadLine(), out tuoi))
        {
            Console.WriteLine("Vui lòng nhập đúng tuổi");
            Console.Write("Nhap tuoi: ");
        }
        Console.WriteLine("======================================");
        Console.WriteLine();
        Console.WriteLine("Mã học sinh | Tên học sinh | Tuổi | Quê quán | Lớp");
        Console.WriteLine("------------------------------------");
        foreach (var hocSinh in truongTHPT.GetHocSinhByTuoi(tuoi))
        {
            Console.WriteLine($"{hocSinh.HoTen} | {hocSinh.Tuoi} | {hocSinh.QueQuan} | {hocSinh.Lop}");
        }
        Console.WriteLine();
    }

    public void HienThiDanhSachHocSinhByTuoiVaQue()
    {
        Console.WriteLine("Danh sách học sinh theo tuổi và quê quán");
        Console.Write("Nhap tuoi: ");
        int tuoi;
        while (!Int32.TryParse(Console.ReadLine(), out tuoi))
        {
            Console.WriteLine("Vui lòng nhập đúng tuổi");
            Console.Write("Nhap tuoi: ");
        }
        Console.Write("Nhap quê quán: ");
        string queQuan = null;
        while (String.IsNullOrEmpty(queQuan))
        {
            Console.Write("Nhap que quán: ");
            queQuan = Console.ReadLine();
        }
        Console.WriteLine("======================================");
        Console.WriteLine();
        Console.WriteLine("Mã học sinh | Tên học sinh | Tuổi | Quê quán | Lớp");
        Console.WriteLine("------------------------------------");
        foreach (var hocSinh in truongTHPT.GetHocSinhByTuoiVaQue(tuoi, queQuan))
        {
            Console.WriteLine($"{hocSinh.HoTen} | {hocSinh.Tuoi} | {hocSinh.QueQuan} | {hocSinh.Lop}");
        }
    }
}

public class FormThemHocSinh
{
    private TruongTHPT truongTHPT;
    public FormThemHocSinh()
    {
        truongTHPT = new TruongTHPT();
    }
    public void ThemHocSinh()
    {
        Console.WriteLine("Form thêm học sinh");
        Console.Write("Nhap ho ten: ");
        string hoTen = Console.ReadLine();
        Console.Write("Nhap tuoi: ");
        int tuoi;
        while (!Int32.TryParse(Console.ReadLine(), out tuoi))
        {
            Console.WriteLine("Vui lòng nhập đúng tuổi");
            Console.Write("Nhap tuoi: ");
        }
        Console.Write("Nhap que quán: ");
        string queQuan = Console.ReadLine();
        Console.Write("Nhap lop: ");
        int lop;
        while (!Int32.TryParse(Console.ReadLine(), out lop))
        {
            Console.WriteLine("Vui lòng nhập đúng lớp");
            Console.Write("Nhap lớp: ");
        }
        truongTHPT.ThemHocSinh(new HocSinh(hoTen, tuoi, queQuan, lop));
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("======================================");
            Console.WriteLine();
            Console.WriteLine("1. Thêm học sinh");
            Console.WriteLine("2. Hiển thị danh sách học sinh theo tuổi");
            Console.WriteLine("3. Hiển thị danh sách học sinh theo tuổi và quê quán");
            Console.WriteLine("4. Thoát");
            Console.Write("Nhap chọn: ");
            int chon;
            while (!Int32.TryParse(Console.ReadLine(), out chon))
            {
                Console.WriteLine("Vui lòng nhập đúng chọn");
                Console.Write("Nhap chọn: ");
            }
            switch (chon)
            {
                case 1:
                    new FormThemHocSinh().ThemHocSinh();
                    break;
                case 2:
                    new DanhSachHocSinhScreen().HienThiDanhSachHocSinhByTuoi();
                    break;
                case 3:
                    new DanhSachHocSinhScreen().HienThiDanhSachHocSinhByTuoiVaQue();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Vui lòng nhập đúng chọn");
                    Console.Write("Nhap chọn: ");
                    break;
            }
        }
    }
}
