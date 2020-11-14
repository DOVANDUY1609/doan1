using MyStore.Untility;
using System.IO;
using MyStore.Entities;
namespace MyStore.DataAcess
{
    class MathangDAL : IDMathangDAL
    {
        //Xác định đường dẫn của tệp dữ liệu Hang hoa.txt l 
        private string txtfile = "Data/Hanghoa.txt";
        //Lấy toàn bộ dữ liệu có trong file HocSinh.txt đưa vào một danh sách 
        public List<Mathang> GetData()
        {
            List<Mathang> list = new List<Mathang>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = MyStore.Untility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Mathang(int.Parse(a[0]), a[1], a[2], int.Parse(a[3]), int.Parse(a[4])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Lấy mã hang hoa của bản ghi cuối cùng phục vụ cho đánh mã tự động
        public int Mahang
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
        public void Insert(Mathang hh)
        {
            //int mah = Mahang + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(hh.mahang + "#" + hh.tenhang + "#" + hh.maloai + "#" + hh.soluongnhapve + "#" + hh.soluonghienco);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<Mathang> list)
        {
            StreamWriter fwrite = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].mahang + "#" + list[i].tenhang + "#" + list[i].maloai + "#" + list[i].soluongnhapve + "#" + list[i].soluonghienco);
            fwrite.Close();
        }
    }
}
