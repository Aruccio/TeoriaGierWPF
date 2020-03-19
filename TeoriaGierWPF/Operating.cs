using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeoriaGierWPF
{
    class Operating
    {
        public   Operating()
        {
           // MainWindow mw = new MainWindow();
        }

        public static Operating ShowRecord()
        {
            var opera = new Operating();
            {
                opera.Name = "";
            }
            return opera;
        }

        public int Points { get; set; }
        public string Name { get; set; }

        void GraczUzytkownik(int[] stosy, int gracz)
        {
            gracz = 1;
            Console.WriteLine("Podaj z którego stosu pobierane są zapałki: ");
            string liczba = Console.ReadLine();
            int ktoryStos = int.Parse(liczba);
            while (ktoryStos == 0 || ktoryStos > stosy.Length)
            {
                Console.WriteLine("Podałeś niepoprawny stos");
                liczba = Console.ReadLine();
                ktoryStos = int.Parse(liczba);
            }
            Console.WriteLine("Podaj ilość pobranych zapałek: ");
            liczba = Console.ReadLine();
            int ileZapałek = int.Parse(liczba);
            while (stosy[ktoryStos - 1] < ileZapałek || stosy[ktoryStos - 1] == 0)
            {
                Console.WriteLine("Podałeś niepoprawną ilość zapałek");
                liczba = Console.ReadLine();
                ileZapałek = int.Parse(liczba);
            }
            stosy[ktoryStos - 1] = stosy[ktoryStos - 1] - ileZapałek;
            for (int i = 0; i < stosy.Length; i++)
            {
                Console.Write("{0}:", i + 1);
                for (int j = 0; j < stosy[i]; j++) Console.Write("|");
                Console.WriteLine();
            }
            SprawdzenieWygranej(stosy, gracz);
            GraczKomputer(stosy, ktoryStos, ileZapałek, gracz);
        }
        void SprawdzenieWygranej(int[] stosy, int gracz)
        {
            int sprawdzenieCzyJedenStos = 0;
            for (int i = 0; i < stosy.Length; i++)
            {
                if (stosy[i] == 0) sprawdzenieCzyJedenStos += 1;
            }
            if ((stosy.Length - sprawdzenieCzyJedenStos) == 1)
            {
                for (int i = 0; i < stosy.Length; i++)
                {
                    if (stosy[i] == 1) Console.WriteLine("Zwycięstwo gracza {0}!", gracz);
                }
            }
        }
        void GraczKomputer(int[] stosy, int ktoryStos, int ileZapalek, int gracz)
        {
            gracz = 2;
            int sprawdzenieCzyJedenStos = 0;
            int sprawdzenieCzyDwaStosy = 0;
            int nieWzial = 0;
            int stosyZJedynka = 0;
            if (stosy.Length % 2 == 0)
            {
                for (int i = 0; i < stosy.Length; i++)
                {
                    if (stosy[i] == 0) sprawdzenieCzyJedenStos += 1;
                    if (stosy[i] != 0) sprawdzenieCzyDwaStosy += 1;
                    if (stosy[i] == 1) stosyZJedynka += 1;
                }
                Console.WriteLine("Ilość stosów to: {0}", sprawdzenieCzyDwaStosy);
                if (stosy.Length - sprawdzenieCzyJedenStos == 1)
                {
                    for (int i = 0; i < stosy.Length; i++)
                    {
                        if (stosy[i] != 0) sprawdzenieCzyJedenStos = i;
                        break;
                    }
                    stosy[sprawdzenieCzyJedenStos] = stosy[sprawdzenieCzyJedenStos] - stosy[sprawdzenieCzyJedenStos] + 1;
                }
                else if (sprawdzenieCzyDwaStosy == 2 && (stosyZJedynka == 1 || stosyZJedynka == 2))
                {
                    for (int i = 0; i < stosy.Length; i++)
                    {
                        if (stosy[i] == 1)
                        {
                            for (int j = 0; j < stosy.Length; j++)
                            {
                                if (stosy[j] != 1 && stosy[j] != 0)
                                {
                                    sprawdzenieCzyDwaStosy = j;
                                }
                                if (stosyZJedynka == 2 && stosy[j] != 0)
                                {
                                    sprawdzenieCzyDwaStosy = j;
                                }
                            }
                            break;
                        }
                    }
                    stosy[sprawdzenieCzyDwaStosy] = stosy[sprawdzenieCzyDwaStosy] - stosy[sprawdzenieCzyDwaStosy];
                }
                else if (sprawdzenieCzyDwaStosy == 3 && stosyZJedynka == 2)
                {
                    for (int i = 0; i < stosy.Length; i++)
                    {
                        if (stosy[i] != 1 && stosy[i] != 0)
                        {
                            sprawdzenieCzyDwaStosy = i;
                            break;
                        }
                    }
                    stosy[sprawdzenieCzyDwaStosy] = stosy[sprawdzenieCzyDwaStosy] - stosy[sprawdzenieCzyDwaStosy] + 1;
                }
                else if (sprawdzenieCzyDwaStosy == 4 && stosyZJedynka == 3)
                {
                    for (int i = 0; i < stosy.Length; i++)
                    {
                        if (stosy[i] != 1 && stosy[i] != 0)
                        {
                            sprawdzenieCzyDwaStosy = i;
                            break;
                        }
                    }
                    stosy[sprawdzenieCzyDwaStosy] = stosy[sprawdzenieCzyDwaStosy] - stosy[sprawdzenieCzyDwaStosy];
                }
                else
                {
                    for (int i = 0; i < stosy.Length; i++)
                    {
                        if (stosy[i] == stosy[ktoryStos - 1] + ileZapalek)
                        {
                            stosy[i] = stosy[i] - ileZapalek;
                            break;
                        }
                    }
                }
            }
            if (stosy.Length % 2 == 1)
            {
                for (int i = 0; i < stosy.Length; i++)
                {
                    if (stosy[i] == 0) sprawdzenieCzyJedenStos += 1;
                    if (stosy[i] != 0) sprawdzenieCzyDwaStosy += 1;
                    if (stosy[i] == 1) stosyZJedynka += 1;
                }
                Console.WriteLine("Ilość stosów z jedynką to: {0}", stosyZJedynka);
                Console.WriteLine("Ilość stosów to: {0}", sprawdzenieCzyDwaStosy);
                if (sprawdzenieCzyDwaStosy == 2 && stosyZJedynka == 2)
                {
                    for (int i = 0; i < stosy.Length; i++)
                    {
                        if (stosy[i] != 0)
                        {
                            sprawdzenieCzyJedenStos = i;
                            break;
                        }

                    }
                    stosy[sprawdzenieCzyJedenStos] = stosy[sprawdzenieCzyJedenStos] - stosy[sprawdzenieCzyJedenStos];
                }
                else if (sprawdzenieCzyDwaStosy == 2 && stosyZJedynka == 1)
                {
                    for (int i = 0; i < stosy.Length; i++)
                    {
                        if (stosy[i] != 0 && stosy[i] != 1)
                        {
                            sprawdzenieCzyJedenStos = i;
                            break;
                        }

                    }
                    stosy[sprawdzenieCzyJedenStos] = stosy[sprawdzenieCzyJedenStos] - stosy[sprawdzenieCzyJedenStos];
                }
                else if (sprawdzenieCzyDwaStosy == 2 && stosyZJedynka == 0)
                {
                    for (int i = 0; i < stosy.Length; i++)
                    {
                        if (stosy[i] != 0 && stosy[i] != 1 && stosy[i] > 2)
                        {
                            sprawdzenieCzyJedenStos = i;
                        }
                    }
                    if (stosy[sprawdzenieCzyJedenStos] > 2)
                    {
                        stosy[sprawdzenieCzyJedenStos] = stosy[sprawdzenieCzyJedenStos] - stosy[sprawdzenieCzyJedenStos] + 2;
                    }
                    else stosy[sprawdzenieCzyJedenStos] -= 1;
                }

                else if (stosy.Length - sprawdzenieCzyJedenStos == 1 || sprawdzenieCzyDwaStosy == 1)
                {
                    for (int i = 0; i < stosy.Length; i++)
                    {
                        if (stosy[i] != 0) sprawdzenieCzyJedenStos = i;
                    }
                    stosy[sprawdzenieCzyJedenStos] = stosy[sprawdzenieCzyJedenStos] - stosy[sprawdzenieCzyJedenStos] + 1;
                }
                else if (sprawdzenieCzyDwaStosy == 3 && stosyZJedynka == 2)
                {
                    for (int i = 0; i < stosy.Length; i++)
                    {
                        if (stosy[i] != 1 && stosy[i] != 0)
                        {
                            sprawdzenieCzyDwaStosy = i;
                            break;
                        }
                    }
                    stosy[sprawdzenieCzyDwaStosy] = stosy[sprawdzenieCzyDwaStosy] - stosy[sprawdzenieCzyDwaStosy] + 1;
                }
                else if (sprawdzenieCzyDwaStosy == 4 && stosyZJedynka == 3)
                {
                    for (int i = 0; i < stosy.Length; i++)
                    {
                        if (stosy[i] != 1 && stosy[i] != 0)
                        {
                            sprawdzenieCzyDwaStosy = i;
                            break;
                        }
                    }
                    stosy[sprawdzenieCzyDwaStosy] = stosy[sprawdzenieCzyDwaStosy] - stosy[sprawdzenieCzyDwaStosy];
                }
                else
                {
                    for (int i = 0; i < stosy.Length; i++)
                    {
                        if (stosy[i] == stosy[ktoryStos - 1] + ileZapalek)
                        {
                            nieWzial = 1;
                            stosy[i] = stosy[i] - ileZapalek;
                            break;
                        }
                    }
                    if (nieWzial == 0)
                    {
                        for (int i = 0; i < stosy.Length; i++)
                        {
                            if (stosy[i] != 0 && stosy[i] != 1)
                            {
                                sprawdzenieCzyJedenStos = i;
                                break;
                            }
                        }
                        stosy[sprawdzenieCzyJedenStos] = stosy[sprawdzenieCzyJedenStos] - stosy[sprawdzenieCzyJedenStos] + 1;
                        nieWzial = 0;
                    }
                }
            }
            for (int i = 0; i < stosy.Length; i++)
            {
                Console.Write("{0}:", i + 1);
                for (int j = 0; j < stosy[i]; j++) Console.Write("|");
                Console.WriteLine();
            }
            SprawdzenieWygranej(stosy, gracz);
            GraczUzytkownik(stosy, gracz);
        }

    }
}
