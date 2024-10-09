using System;
using System.Diagnostics.CodeAnalysis;

namespace BasicOpakovani.Domain
{
    public class Marriage
    {
        public Person person1;
        public Person person2;

        public Marriage(Person person1, Person person2)
        {
            this.person1 = person1;
            this.person2 = person2;
        }

        public bool Person1Accepted = false;
        public bool Person2Accepted = false;

        public bool Accept1()
        {
            Person1Accepted = true;
            return Person1Accepted;
        }

        public bool Accept2()
        {
            Person2Accepted = true;
            return Person2Accepted;
        }

        public void Marry()
        {
            if (Person1Accepted && Person2Accepted)
            {
                Console.WriteLine($"{this.person1.Name} a {this.person2.Name} jsou nyni manzele");
                person1.PersonMarriage = this;
                person2.PersonMarriage = this;
            }
            else
            {
                if (!Person1Accepted && Person2Accepted)
                {
                    Console.WriteLine($"{this.person1.Name} rekl ne.");
                }
                else
                {
                    Console.WriteLine($"{this.person2.Name} rekl ne.");
                }
            }
        }

        public void Divorce()
        {
            if (Person1Accepted && Person2Accepted)
            {
                person1.PersonMarriage = null;
                person2.PersonMarriage = null;
                Console.WriteLine($"{this.person1.Name} a {this.person2.Name} již nejsou manželé.");
            }
        }
    }
}
