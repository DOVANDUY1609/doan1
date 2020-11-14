using MyStore.Untility;
using System.IO;
using MyStore.Entities;

namespace MyStore.DataAcess
{
    class LoaidoDAL : IDLoaidoDAL
    {
        //Xác định đường dẫn của tệp dữ liệu Loaihang.txt l 
        private string txtfile = "Data/LoaiHang.txt";
        //Lấy toàn bộ dữ liệu có trong file Loaihang.txt đưa vào một danh sách 
        public List<Loaido> GetData()
        {
            List<Loaido> list = new List<Loaido>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = MyStore.Untility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Loaido(int.Parse(a[0]), a[1], a[2]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã học sinh của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int Maloai
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
        public void Insert(Loaido lh)
        {
            int Malh = Maloai + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(Maloai + "#" + lh.tenloai + "#" + lh.dacdiem);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<Loaido> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].maloai + list[i].tenloai + list[i].dacdiem);
            fwrite.Close();
        }
    }
}
