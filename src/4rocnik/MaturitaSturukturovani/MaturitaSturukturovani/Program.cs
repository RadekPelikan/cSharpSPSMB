// See https://aka.ms/new-console-template for more information

// Vytvor 3 projekty, ktere budou spadat do konvenci projektu
// projekt pro entity
// projekt pro asp.net
// projekt pro ef core
// projekty mohou byt prazdne, zalezi na pojmenovani

// vytvor 2 recordy v ruznem namespacu, ktere se budou jmenovat stejne
// ukaz jak se mohou tyto recordy prejmenovat pri jeho pouzivani pres using


// Vytvor metodu, ktera bude delit 2 cisla, bude vracet podil
// tato metoda muze vyhazovat vyjimku pro deleniNulou, kdy cislo b bude 0
// okomentuj spravne, ze metoda muze vyhazovat tuto vyjimku


using Student1 = MaturitaSturukturovani.Test1.Student;
using Student2 = MaturitaSturukturovani.Test2.Student;

new Student1();
new Student2();

namespace MaturitaSturukturovani
{


    class Maturita
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">ff</param>
        /// <param name="b">ggg</param>
        /// <returns></returns>
        /// <exception cref="DivideByZeroException">hhh</exception>
        public static double DivideCalc(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Nelze dělit nulou");
            }
            return a / b;
        }
    }
}

// 

/* */

/**
 * 
 */
