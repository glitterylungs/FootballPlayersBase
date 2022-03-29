using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Players_Base
{
    internal class Player
    {
        private string forename;

        public string Forename
        {
            get { return forename; }
            set { forename = value; }
        }

        public string surname { get; set; }
        public int age { get; set; }
        public double weight { get; set; }

        public Player(string forename = "Gall", string surname = "Anonim", int age = 15, double weight = 55)
        {
            this.forename = forename;
            this.surname = surname;
            this.age = age;
            this.weight = weight;
        }

        public override string ToString()
        {
            return $"{surname} {forename}, age: {age}, weight: {weight}kg";
        }

    }
}
