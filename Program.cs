using System.Collections.Immutable;

class Program
{
    static void Main()
    {
        int[] tab = RandomTab(100);
        Console.WriteLine("Tablica przed sortowaniem:");
        WypiszTab(tab);
        
        Sortowanie(tab);
        Console.WriteLine("\nTablica po sortowaniu:");
        WypiszTab(tab);

        int[] tabDoWeryfikacji = (int[])tab.Clone();
        Array.Sort(tabDoWeryfikacji);

        bool prawidlowoSortowana = PorownajTab(tab, tabDoWeryfikacji);
        Console.WriteLine("\nWynik sortowania: " + (prawidlowoSortowana ? "Prawda" : "Fałsz"));
    }
    static int[] RandomTab(int dlugosc)
    {
        Random rand = new Random();
        int[] tab = new int[dlugosc];
        for (int i = 0; i < dlugosc; i++)
        {
            tab[i] = rand.Next(1000);
        }
        return tab;
    }
    static void WypiszTab(int[] tab)
    {
        foreach (var item in tab)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    static void Sortowanie(int[] tab)
    {
        for (int i = 1; i < tab.Length; i++)
        {
            int key = tab[i];
            int j = i - 1;

            while (j >= 0 && tab[j] > key)
            {
                tab[j + 1] = tab[j];
                j--;
            }
            tab[j + 1] = key;
        }
    }
    static bool PorownajTab(int[] tab1, int[] tab2)
    {
        if (tab1.Length != tab2.Length) return false;
        for (int i = 0; i < tab2.Length; i++)
        {
            if (tab1[i] != tab2[i]) return false;
        }
        return true;
    }
}