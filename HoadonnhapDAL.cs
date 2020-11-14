using MyStore.Untility;
using System.IO;
using MyStore.Entities;
using System;
namespace MyStore.DataAcess
{
    class HoadonnhapDAL : IDHoadonnhapDAL
    {
        //Xác định đường dẫn của tệp dữ liệu Chitiethoadonnhap.txt l 
        private string txtfile = "Data/Hoadonnhap.txt";
        //Lấy toàn bộ dữ liệu có trong file HocSinh.txt đưa vào một danh sách 
        public List<Hoadonnhap> GetData()
        {
            List<Hoadonnhap> list = new List<Hoadonnhap>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = MyStore.Untility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Hoadonnhap(int.Parse(a[0]), int.Parse(a[1]), int.Parse(a[2]), DateTime.Parse(a[3]),int.Parse(a[4]),a[5]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã hang hoa của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int Mahdn
        {
            get
            {
                StreamReader fread = File.OpenText(txtfile);
                string s = fread.ReadLine();
                string tmp = "";
                while (s != null)
                {
                    if (s != "") tmp = s;
                    s = fread.ReadLine();
                }
                fread.Close();
                if (tmp == "") return 0;
                else
                {
                    tmp = MyStore.Untility.CongCu.ChuanHoaXau(tmp);
                    string[] a = tmp.Split('#');
                    return int.Parse(a[0]);
                }
            }
        }
        //Chèn một bản ghi hang hoa vào tệp
        public void Insert(Hoadonnhap hh)
        {
            int mah = Mahdn + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(mah + "#" + hh.mahdn + "#" + hh.mancc + "#" + hh.mann + "#" + hh.ngaynhan + "#" + hh.tongtien + "#" + hh.ghichu);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<Hoadonnhap> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mahdn + "#" + list[i].mancc + "#" + list[i].mann + "#" + list[i].ngaynhan+"#"+list[i].tongtien+"#"+list[i].ghichu);
            fwrite.Close();
        }
    }
}
