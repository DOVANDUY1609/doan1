using System;
using MyStore.Untility;
using System.IO;
using MyStore.Entities;

namespace MyStore.DataAcess
{
    class NhanvienDAL : IDNhanvienDAL
    {
        //Xác định đường dẫn của tệp dữ liệu nhanvien.txt l 
        private string txtfile = "Data/Nhan_vien.txt";
        //Lấy toàn bộ dữ liệu có trong file HocSinh.txt đưa vào một danh sách 
        public List<Nhan_vien> GetData()
        {
            List<Nhan_vien> list = new List<Nhan_vien>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = MyStore.Untility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Nhan_vien(int.Parse(a[0]), a[1], a[2], DateTime.Parse(a[3])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã nhan vien của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int Manv
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
        public void Insert(Nhan_vien nv)
        {
            int mah = Manv + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(mah + "#" + nv.manv + "#" + nv.tennv + "#" + nv.gioitinh + "#" + nv.ngaysinh);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<Nhan_vien> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].manv + "#" + list[i].tennv + "#" + list[i].gioitinh + "#" + list[i].ngaysinh);
            fwrite.Close();
        }
    }
}
