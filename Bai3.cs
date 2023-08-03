abstract class ThiSinh {
    public string SoBaoDanh {get; set;}
    public string HoTen {get; set;}
    public string DiaChi {get; set;}
    public int MucUuTien {get; set;}

    public abstract void HienThiThongTin();
}

class ThiSinhKhoiA : ThiSinh {
    public double DiemToan { get; set; }
    public double DiemLy { get; set; }
    public double DiemHoa { get; set; }

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
    public double DiemToan { get; set; }
    public double DiemHoa { get; set; }
    public double DiemSinh { get; set; }

    public override void HienThiThongTin()
    {
        System.Console.WriteLine("So bao danh: {0}", SoBaoDanh);
        System.Console.WriteLine("Ho ten: {0}", HoTen);
        System.Console.WriteLine("Dia chi: {0}", DiaChi);
        System.Console.WriteLine("Muc uu tien: {0}", MucUuTien);
        System.Console.WriteLine("Khoi: B");
    }
}
