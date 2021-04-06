using System;
using System.Linq;
using System.Runtime.CompilerServices;
using ClassDemoOperator.model;

namespace ClassDemoOperator
{
    public class OperatorWorker
    {
        private ItemList list;

        public OperatorWorker()
        {
        }

        public void Start()
        {
            NormalUse();

            //UseForeach();
            //UseBrackets();
            //UseOperators();
            UseEquality();
        }

        
        private void NormalUse()
        {
            list = new ItemList();
            list.Add(new Item("Cola", 15));
            list.Add(new Item("Coffee", 22));

            Console.WriteLine(list);

            ItemList listEqual = new ItemList();
            listEqual.Add(new Item("Cola", 15));
            listEqual.Add(new Item("Coffee", 22));

            Console.WriteLine("Lists are equal = " + (list == listEqual));

        }

        
        private void UseForeach()
        {
            foreach (Item item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(list.Average( i => i.Price));
        }

        private void UseOperators()
        {
            ItemList B = new ItemList();
            B.Add(new Item("Tea", 22));
            B.Add(new Item("Cacao", 35));

            ItemList returListe = list + B;

            Console.WriteLine("Kombineret liste \n" + returListe);


            returListe = returListe + new Item("Sugar", 9);
            Console.WriteLine("Kombineret liste2 \n" + returListe);

            returListe = new Item("Soda", 14) + returListe;
            Console.WriteLine("Kombineret liste3 \n" + returListe);
        }

        private void UseBrackets()
        {
            Console.WriteLine("Hent cola " + list["Cola"]);

            list["Milk"] = new Item("Milk", 23);
            Console.WriteLine(list);
        }

        private void UseEquality()
        {
            ItemList equalListe = new ItemList();
            equalListe.AddRange(list);

            Console.WriteLine("De to lister er ens " + (list == equalListe));
        }


    }
}