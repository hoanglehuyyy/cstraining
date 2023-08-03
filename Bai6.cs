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
    private List<HocSinh> danhSachHocSinh;

    public TruongTHPT()
    {
        danhSachHocSinh = new List<HocSinh>();
    }

    public void ThemHocSinh(HocSinh hocSinh)
    {
        danhSachHocSinh.Add(hocSinh);
    }

    public List<HocSinh> HienThiHocSinh20Tuoi()
    {
        return danhSachHocSinh.Where(hs => hs.Tuoi == 20).ToList();
    }

    public int DemHocSinh23TuoiQueDN()
    {
        return danhSachHocSinh.Count(hs => hs.Tuoi == 23 && hs.QueQuan == "DN");
    }
}
