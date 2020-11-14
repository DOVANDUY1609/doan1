using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Untility
{
    public abstract class Menu
    {
        private string[] dt;
        public Menu(string[]dt)
        {
            this.dt = dt;
        }
        public int MaxMuc()
        {
            int max = dt[0].Length;
            for (int i = 0; i < dt.Length; ++i)
                if (max < dt[0].Length)
                    max = dt[0].Length;
            return max;
        }
        public void ChuanHoaMenu()
        {
            int max = MaxMuc();
            for (int i = 0; i < dt.Length; ++i)
                dt[i] = MyStore.Untility.CongCu.ChuanHoaXau(dt[i], max);
        }
        public void Writexy(int x, int y, int vitri, ConsoleColor maunen, ConsoleColor mauchu)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = maunen;
            Console.ForegroundColor = mauchu;
            Console.Write(dt[vitri]);
        }
        public void Writexy(int x, int y, string s)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
        public void HienTheoPhimTat(int x, int y, ConsoleColor maunen, ConsoleColor mauchu)
        {
            ChuanHoaMenu();
            IO.BoxTitle("CAC CHUC NANG CHINH", x, y, dt.Length * 2 + 5, MaxMuc() + 10);
            x = x + 5;
            y = y + 3;
            for (int i = 0; i < dt.Length; ++i) Writexy(x, y + i * 2, i, maunen, mauchu);
            IO.Writexy("Hay chon mot chuc nang de thuc hien...", x, y + dt.Length * 2);
            ConsoleKeyInfo kt = Console.ReadKey();

            string[] key = new string[dt.Length];
            for (int i = 0; i < dt.Length; ++i)
                key[i] = dt[i].Substring(0, dt[i].IndexOf("."));
            for (int i = 0; i < key.Length; ++i)
                if (kt.Key.ToString() == key[i]) ThucHien(i);
        }
        public void HienTheoKieuCuon(int x, int y, ConsoleColor maunen_t, ConsoleColor mauchu_t, ConsoleColor maunen_s, ConsoleColor mauchu_s)
        {
            ChuanHoaMenu();
            int chon = 0;
            for (int i = 0; i < dt.Length; ++i) Writexy(x, y + i, i, maunen_t, mauchu_t);
            Writexy(x, y + chon, chon, maunen_s, mauchu_s);
            do
            {
                ConsoleKeyInfo kt = Console.ReadKey();
                for (int i = 0; i < dt.Length; ++i) Writexy(x, y + i, i, maunen_t, mauchu_t);
                switch (kt.Key)
                {
                    case ConsoleKey.DownArrow://↓
                        if (chon == dt.Length - 1) chon = 0;
                        else chon = chon + 1;
                        Writexy(x, y + chon, chon, maunen_s, mauchu_s);
                        break;
                    case ConsoleKey.UpArrow://↑
                        if (chon == 0) chon = dt.Length - 1;
                        else chon = chon - 1;
                        Writexy(x, y + chon, chon, maunen_s, mauchu_s);
                        break;
                    case ConsoleKey.Enter:
                        ThucHien(chon);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        for (int i = 0; i < dt.Length; ++i) Writexy(x, y + i, i, maunen_t, mauchu_t);
                        Writexy(x, y + chon, chon, maunen_s, mauchu_s);
                        break;
                }
                Writexy(x, y + dt.Length + 1, "Ban dang chon muc:" + chon);
            } while (true);
        }
        public abstract void ThucHien(int vitri);
    }
}

    

