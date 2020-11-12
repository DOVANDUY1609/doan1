using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Entities
{
    public class Khachhang
    {
        private int Makh;
        private string TenKH;
        private int SDT;
        private string Diachi;
        public int makh
        {
            get
            {
                return Makh;
            }
            set
            {
                if (Makh > 1)
                    Makh = value;
            }
        }

        public string tenkhachhang
        {
            get
            {
                return TenKH;
            }
            set
            {
                if (TenKH != "")
                    TenKH = value;
            }
        }

        public int sdt
        {
            get
            {
                return SDT;
            }
            set
            {
                if (SDT >1)
                    SDT = value;
            }
        }
        public string diachi
        {
            get
            {
                return Diachi;
            }
            set
            {
                if (Diachi != "")
                    Diachi = value;
            }
        }
        public Khachhang()
        {
        }
        public Khachhang(Khachhang kh)
        {
            Makh = kh.makh;
            TenKH = kh.tenkhachhang;
            SDT = kh.sdt;
            Diachi = kh.diachi;
        }
        public Khachhang(int makh,string tenkh,int sdt,string diachi)  
        {
            Makh = makh;
            TenKH = tenkh;
            SDT = sdt;
            Diachi = diachi;
        }
    }
}
