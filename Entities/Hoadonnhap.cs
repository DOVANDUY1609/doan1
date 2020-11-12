using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Entities
{
    public  class Hoadonnhap
    {
        private int Mahdn;
        private string Mancc;
        private string Mann;
        private DateTime Ngaynhan;
        private double Tongtien;
        private string Ghichu;
        public int mahdn
        {
            get
            {
                return Mahdn;
            }
            set
            {
                if (Mahdn > 1)
                    Mahdn = value;
            }
        }

        public string mancc
        {
            get
            {
                return Mancc;
            }
            set
            {
                if (Mancc !="")
                    Mancc = value;
            }
        }

        public string mann
        {
            get
            {
                return Mann;
            }
            set
            {
                if (Mann !="")
                    Mann = value;
            }
        }
        public DateTime ngaynhan
        {
            get
            {
                return Ngaynhan;
            }
            set
            {
                //if (Ngaynhan > DateTime.Now)
                    Ngaynhan = value;
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
        public string ghichu
        {
            get
            {
                return Ghichu;
            }
            set
            {
                if (Ghichu != "")
                    Ghichu = value;
            }
        }

        public Hoadonnhap()
        {
        }
        public Hoadonnhap(Hoadonnhap hdn)
        {
            Mahdn = hdn.mahdn;
            Mancc = string.Copy(hdn.mancc);
            Mann = string.Copy(hdn.mann);
            Ngaynhan = hdn.ngaynhan;
            Tongtien = hdn.tongtien;
            Ghichu = string.Copy(hdn.ghichu);
        }
        public Hoadonnhap(int mahdn,string mancc,string mann,DateTime ngaynhan,double tongtien,string ghichu)
        {
            Mahdn = mahdn;
            Mancc = mancc;
            Mann = mann;
            Ngaynhan = ngaynhan;
            Tongtien = tongtien;
            Ghichu = ghichu;
        }
    }
}
