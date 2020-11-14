using MyStore.Untility;
using System.IO;
using MyStore.Entities;
using System;
//using MyStore.DataAcess.Interface;
namespace MyStore.DataAcess
{
    class HoadonbanDAL : IDHoadonbanDAL
    {
        //Xác định đường dẫn của tệp dữ liệu Hoadonban.txt l
        private string txtfile = "Data/Hoadonban.txt";
        //Lấy toàn bộ dữ liệu có trong file HocSinh.txt đưa vào một danh sách 
        public List<Hoadonban> GetData()
        {
            List<Hoadonban> list = new List<Hoadonban>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = MyStore.Untility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Hoadonban(int.Parse(a[0]),a[1], DateTime.Parse(a[2]),int.Parse(a[3]),double.Parse(a[4]), int.Parse(a[5])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã hang hoa của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int Mahdb
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
        public void Insert(Hoadonban hdb)
        {
            int mah = Mahdb + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(mah+"#"+hdb.mahdb+"#"+hdb.manvb+"#"+hdb.ngayban+"#"+hdb.tongtien);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<Hoadonban> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mahdb + "#" + list[i].manvb + "#" + list[i].ngayban + "#" + list[i].tongtien);
            fwrite.Close();
        }
    }
}
