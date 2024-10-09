using System;
using BasicOpakovani.Domain;

namespace BasicOpakovani
{
    class Program
    {
        static void Main(string[] args)
        {
            Woman blanka = new Woman("Blanka", 43, 60);
            Man JJ = new Man("JJ", 17, 80, 103.2f);
            Marriage Manzelstvi = new Marriage(JJ, blanka);

            Man Jarda = new Man("Jarda", 48, 80, 4);
            Nonbinary Michal = new Nonbinary("Michal", 17, 20, 4);
            Marriage Manzelstvi2 = new Marriage(Jarda, Michal);
            Manzelstvi2.Accept1();
            
            Manzelstvi2.Marry();
            Manzelstvi2.Divorce();
            Manzelstvi.Divorce();
            
        }
    }
}