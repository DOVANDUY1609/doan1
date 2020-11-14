using System;
using MyStore.Untility;
using System.IO;
using MyStore.Entities;
using  MyStore.Business;

namespace MyStore.DataAcess
{
    class KhachhangDAL : IDKhachhangDAL
    {
        //Xác định đường dẫn của tệp dữ liệu nhanvien.txt l 
        private string txtfile = "Data/Khachhang.txt";
        //Lấy toàn bộ dữ liệu có trong file HocSinh.txt đưa vào một danh sách 
        public List<Khachhang> GetData()
        {
            List<Khachhang> list = new List<Khachhang>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = MyStore.Untility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Khachhang(int.Parse(a[0]),a[1],int.Parse(a[2]), a[3]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã nhan vien của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int Makh
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
        //Chèn một bản ghi học sinh vào tệp
        public void Insert(Khachhang nv)
        {
            int mah = Makh + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(mah + "#" + nv.makh + "#" + nv.tenkhachhang + "#" + nv.sdt + "#" + nv.diachi);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<Khachhang> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].makh + "#" + list[i].tenkhachhang + "#" + list[i].sdt + "#" + list[i].diachi);
            fwrite.Close();
        }
    }
}
