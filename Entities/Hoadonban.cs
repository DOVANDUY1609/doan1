using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Entities
{
    public  class Hoadonban
    {
        private int Mahdb;
        private string Manvb;
        private DateTime Ngayban;
        private int soluong;
        private double gia;
        private double Tongtien;
        public int mahdb
        {
            get
            {
                return Mahdb;
            }
            set
            {
                if (Mahdb > 1)
                    Mahdb = value;
            }
        }            
        public string manvb
        {
            get
            {
                return Manvb;
            }
            set
            {
                if (Manvb !="")
                    Manvb = value;
            }
        }

        public DateTime ngayban
        {
            get
            {
                return Ngayban;
            }
            set
            {
                if (Ngayban > DateTime.Now)
                    Ngayban = value;
            }
        }
        private int Soluong
        {
            get
            {
                return soluong;
            }
            set
            {
                if (soluong > 1)
                    soluong = value;
            }
        }
        private double Gia
        {
            get
            {
                return gia;
            }
            set
            {
                if (gia > 1)
                    gia = value;
            }
        }
        public double tongtien
        {
            get
            {
                return Tongtien;
            }
            set
            {
                if (Tongtien > 1)
                    Tongtien = value;
            }
        }
        public Hoadonban()
        {
        }
        public Hoadonban(Hoadonban hdb)
        {
            Mahdb = hdb.mahdb;
            Manvb = string.Copy(hdb.manvb);
            Ngayban = hdb.ngayban;
            soluong = hdb.Soluong;
            gia = hdb.Gia;
            Tongtien = hdb.tongtien;
        }    
        public Hoadonban(int mahdb, string manvb, DateTime ngayban,int Soluong,double Gia, double tongtien)
        {
            Mahdb = mahdb;
            Manvb = manvb;
            Ngayban = ngayban;
            soluong = Soluong;
            gia = Gia;
            Tongtien = tongtien;
        }
    }
}
