using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyStore.Entities
{
    public class Nhà_cung_cấp
    {
        private int MaNCC;
        private int SDT;
        private string TenNCC;
        private string Diachi;
        public int mancc
        {
            get
            {
                return MaNCC;
            }
            set
            {
                if (MaNCC > 1)
                    MaNCC = value;
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
                if (SDT > 1)
                    SDT = value;
            }
        }
        public string tenncc
        {
            get
            {
                return TenNCC;
            }
            set
            {
                if (TenNCC != "")
                    TenNCC = value;
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
        public Nhà_cung_cấp()
        {
        }
        public Nhà_cung_cấp(Nhà_cung_cấp ncc)
        {
            MaNCC = ncc.mancc;
            SDT = ncc.sdt;
            TenNCC = ncc.tenncc;
            Diachi = ncc.diachi;
        }
        public Nhà_cung_cấp(int ma,int sd,string tncc,string dc)
        {
            MaNCC = ma;
            sdt = sd;
            TenNCC = tncc;
            Diachi = dc;
        }
    }
}
