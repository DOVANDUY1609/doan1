using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MyStore.Entities
{
    public  class Nhan_vien
    {
        private int Manv;
        private string Tennv;
        private string Gioitinh;
        private DateTime Ngaysinh;
        public int manv
        {
            get
            {
                return Manv;
            }
            set
            {
                if (Manv > 1)
                    Manv = value;
            }
        }

        public string tennv
        {
            get
            {
                return Tennv;
            }
            set
            {
                if (Tennv != "")
                    Tennv = value;
            }
        }
        public string gioitinh
        {
            get
            {
                return Gioitinh;
            }
            set
            {
                if (Gioitinh != "")
                    Gioitinh = value;
            }
        }

        public DateTime ngaysinh 
        {
            get
            {
                return Ngaysinh;
            }
            set
            {
                    Ngaysinh = value;
            }
        }

        public Nhan_vien()
        {
           
        }
        public Nhan_vien(Nhan_vien nv)
        {
            Manv = nv.Manv;
            Tennv = string.Copy(nv.tennv);
            Gioitinh = string.Copy(nv.gioitinh);
            Ngaysinh = nv.ngaysinh;
        }
        public Nhan_vien(int mnv,string tnv,string gt,DateTime ns)
        {
            Manv = mnv;
            Tennv = tnv;
            Gioitinh = gt;
            Ngaysinh = ns;
        }
    }
}

