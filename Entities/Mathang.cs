using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyStore.Entities
{

    public class Mathang
    {
        private int Mahang;
        private string TenHang;
        private string MaLoai;
        private int Soluongnhapve;
        private int Soluonghienco;
        public int mahang
        {
            get
            {
                return Mahang;
            }
            set
            {
                if (Mahang > 1)
                    Mahang = value;
            }
        }
        public string tenhang
        {
            get
            {
                return TenHang;
            }
            set
            {
                if (TenHang != "")
                    TenHang = value;
            }
        }

        public string maloai
        {
            get
            {
                return MaLoai;
            }
            set
            {
                if (MaLoai != "")
                    MaLoai = value;
            }
        }
        public int soluongnhapve
        {
            get
            {
                return Soluongnhapve;
            }
            set
            {
                if (Soluongnhapve > 1)
                    Soluongnhapve = value;
            }
        }
        public int soluonghienco
        {
            get
            {
                return Soluonghienco;
            }
            set
            {
                if (Soluonghienco > 1)
                    Soluonghienco = value;
            }
        }

        public Mathang()
        {
            mahang = 0;
            tenhang = "";
            maloai = "";
            soluongnhapve = 0;
            soluongnhapve = 0;

        }
        public Mathang(Mathang hh)
        {
            Mahang = hh.mahang;
            TenHang = string.Copy(hh.tenhang);
            MaLoai = string.Copy(hh.maloai);
            Soluongnhapve = hh.soluongnhapve;
            Soluonghienco = hh.soluonghienco;

        }
        public Mathang(int mh, string th, string ml, int slnv, int slhc)
        {
            Mahang = mh;
            TenHang = th;
            MaLoai = ml;
            Soluonghienco = slhc;
            Soluongnhapve = slnv;

        }
    }
}
