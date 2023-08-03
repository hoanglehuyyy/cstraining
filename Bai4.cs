class Nguoi {
    public string HoTen {get; set;}
    public int Tuoi {get; set;}
    public string NgheNghiep {get; set;}
    public string CMND {get; set;}
}

class HoGiaDinh {
    public string SoNha {get; set;}
    public List<Nguoi> ThanhVien {get; set;}

    public HoGiaDinh() {
        ThanhVien = new List<Nguoi>();
    }

    public void ThemThanhVien(Nguoi nguoi) {
        ThanhVien.Add(nguoi);
    }

    public void HienThiThongTin() {
        System.Console.WriteLine("So nha: {0}", SoNha);
        System.Console.WriteLine("So thanh vien: {0}", ThanhVien.Count);
    }
}   

class KhuPho {
    private List<HoGiaDinh> danhSachHoGiaDinh;

    public KhuPho() {
        danhSachHoGiaDinh = new List<HoGiaDinh>();
    }

    public void ThemHoGiaDinh(HoGiaDinh ho) {
        danhSachHoGiaDinh.Add(ho);
    }

    public bool KiemTraCMND(string cmnd) {
        return !danhSachHoGiaDinh.Any(ho => ho.ThanhVien.Any(tv => tv.CMND == cmnd));
    }

    public void HienThiThongTin() {
        foreach (HoGiaDinh ho in danhSachHoGiaDinh) {
            ho.HienThiThongTin();
        }
    }
}

class Program {
    public static void Main(string[] args) {
        KhuPho khuPho = new KhuPho();
        System.Console.Write("Nhap so ho dan: ");
        Int32.TryParse(Console.ReadLine(), out int n);
        for (int i = 0; i < n; i ++) {
            HoGiaDinh hoGiaDinh = new HoGiaDinh();
            khuPho.ThemHoGiaDinh(hoGiaDinh);
            System.Console.WriteLine("Thong tin ho gia dinh thu {0}:", i + 1);
            System.Console.Write("So nha: ");
            hoGiaDinh.SoNha = Console.ReadLine();
            System.Console.Write("So thanh vien: ");
            Int32.TryParse(Console.ReadLine(), out int m);
            for (int j = 0; j < m; j ++) {
                Nguoi nguoi = new Nguoi();
                System.Console.WriteLine("Thong tin thanh vien thu {0}", j + 1);
                System.Console.Write("Ho ten: ");
                nguoi.HoTen = Console.ReadLine();
                System.Console.Write("Tuoi: ");
                Int32.TryParse(Console.ReadLine(), out int tuoi);
                nguoi.Tuoi = tuoi;
                System.Console.Write("Nghe nghiep: ");
                nguoi.NgheNghiep = Console.ReadLine();
                bool unique = false;
                while (!unique) {
                    System.Console.Write("CMND: ");
                    string cmnd = Console.ReadLine();
                    if (khuPho.KiemTraCMND(cmnd)) {
                        nguoi.CMND = cmnd;
                        unique = true;
                    }
                    else {
                        System.Console.WriteLine("So CMND da ton tai. Vui long nhap lai:");
                    }
                }
                hoGiaDinh.ThemThanhVien(nguoi);
            }
        }
        System.Console.WriteLine();
        System.Console.WriteLine("Thong tin khu pho:");
        khuPho.HienThiThongTin();
   }
}
