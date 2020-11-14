using MyStore.Untility;
using System.IO;
using MyStore.Entities;
using System;
namespace MyStore.DataAcess
{
    class NhacungcapDAL:IDNhacungcapDAL
    {
        //Xác định đường dẫn của tệp dữ liệu Chitiethoadonnhap.txt l 
        private string txtfile = "Data/Nhacungcap.txt";
        //Lấy toàn bộ dữ liệu có trong file HocSinh.txt đưa vào một danh sách 
        public List<Nhà_cung_cấp> GetData()
        {
            List<Nhà_cung_cấp> list = new List<Nhà_cung_cấp>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = MyStore.Untility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Nhà_cung_cấp(int.Parse(a[0]), int.Parse(a[1]), a[2], a[3]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã hang hoa của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int MaNCC
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
        public void Insert(Nhà_cung_cấp hh)
        {
            int mah = MaNCC + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(mah + "#" + hh.mancc + "#" + hh.sdt + "#" + hh.tenncc + "#" + hh.diachi);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<Nhà_cung_cấp> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mancc + "#" + list[i].sdt + "#" + list[i].tenncc + "#" + list[i].diachi);
            fwrite.Close();
        }
    }
}