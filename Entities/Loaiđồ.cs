using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MyStore.Entities
{
    public class Loaido
    {
        private int Maloai;
        private string Tenloai;
        private string  Dacdiem;
        public int maloai
        {
            get { return Maloai; }
            set
            {
                if (Maloai > 1)
                    Maloai = value;
            }
        }
        public string tenloai
        {
            get { return Tenloai; }
            set
            {
                if (Tenloai!="")
                    Tenloai = value;
            }
        }


        public string dacdiem
        {
            get
            {
                return Dacdiem;
            }
            set
            {
                if (Dacdiem != "")
                    Dacdiem = value;
            }
        }
        public Loaido(){}
        //Phương thức thiết lập sao chép
        public Loaido(Loaido  hs)
        {
            this.Maloai = hs.maloai;
            this.tenloai = string.Copy(hs.tenloai);
            this.dacdiem = string.Copy(hs.dacdiem);
        }
        public Loaido(int mh,string th,string dd)
        {
            Maloai = mh;
            Tenloai = th;
            Dacdiem = dd;
        }
    }
}
