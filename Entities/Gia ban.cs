using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyStore.Entities
{
    public class Gia_ban
    {
        private int Magb;
        private string Mahang;
        private int giaban;
        private DateTime Ngayad;
        private DateTime Ngaythoiad;
        public int magb
        {
            get
            {
                return Magb;
            }
            set
            {
                if (Magb > 1)
                    Magb = value;
            }
        }
        public string mahang
        {
            get
            {
                return Mahang;
            }
            set
            {
                if (Mahang !="")
                    Mahang = value;
            }
        }

        public int Giaban
        {
            get
            {
                return giaban;
            }
            set
            {
                if (giaban > 1)
                    giaban = value;
            }
        }
        public DateTime ngayad
        {
            get
            {
                return Ngayad;
            }
            set
            {
                
                    Ngayad = value;
            }
        }
        public DateTime ngaythoiad
        {
            get
            {
                return Ngaythoiad;
            }
            set
            {
                
                    ngaythoiad = value;
            }
        }
        public Gia_ban()
        {
        }
        public Gia_ban(Gia_ban gb)
        {
            Magb = gb.magb;
            Mahang =string.Copy(gb.mahang);
            giaban = gb.Giaban;
            Ngayad = gb.ngayad;
            Ngaythoiad = gb.ngaythoiad;
        }
        public Gia_ban(int magb,string mahang,int giaban,DateTime ngayad,DateTime ngaythoiad)
        {
            Magb = magb;
            Mahang = mahang;
            Giaban = giaban;
            Ngayad = ngayad;
            Ngaythoiad = ngaythoiad;
        }
    }
}
