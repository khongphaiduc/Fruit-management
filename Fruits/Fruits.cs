using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruits
{
    public class Fruits
    {
        private int iD;
        private String name;

        private double price;
        private int quanlity;

        private String orgin;

     

        public Fruits(int iD, string name, double price, int quanlity, string orgin)
        {
            this.ID = iD;
            this.Name = name;
            this.Price = price;
            this.Quanlity = quanlity;
            this.Orgin = orgin;
        }




        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Quanlity { get => quanlity; set => quanlity = value; }
        public string Orgin { get => orgin; set => orgin = value; }

    }
}
