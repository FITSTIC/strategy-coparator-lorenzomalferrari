using System;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
          /*
            var nipote = new Person(6, "Luca", "Cippo");
            var nonno = new Person(75, "Aristide", "Merotti");
            var mario = new Person(75, "Mario", "Perotti");
            var gino = new Person(75, "Gino", "Negro");
            var lorenzo = new Person(75, "Lorenzo", "Verratti");
            var marcello = new Person(75, "Marcello", "Ciccio");
            var davide = new Person(75, "Davide", "Basso");
          */

            Person[] arrayPerson = [6, "Luca", "Cippo"];
            Person[] arrayPerson = [24, "Aristide", "Merotti"];
            Person[] arrayPerson = [43, "Mario", "Perotti"];
            Person[] arrayPerson = [33, "Gino", "Negro"];
            Person[] arrayPerson = [71, "Lorenzo", "Verratti"];
            Person[] arrayPerson = [12, "Marcello", "Ciccio"];
            Person[] arrayPerson = [100, "Davide", "Basso"];

            var comparator = new PersonComparator();

            // Età Comparator
            Person[] listAge = comparator.Compare(arrayPerson, new AgeComparator());
            //Console.WriteLine("La persona più giovane è :"+listAge[0].name);//Luca Cippo
            Console.WriteLine("Classifica ordinata per l'età");
            for (i = 0; i <= listAge.lenght; i++) {
              Console.WriteLine(listAge[i]);
            }
            // Nome Comparator
            Person[] listFirstName = comparator.Compare(arrayPerson, new FirstNameComparator());
            //Console.WriteLine("La prima persona in ordine di nome è :"+listFirstName[0].firstName);//Aristide Merotti
            Console.WriteLine("Classifica ordinata per il nome");
            for (i = 0; i <= listFirstName.lenght; i++) {
              Console.WriteLine(listFirstName[i]);
            }
            //Cognome Comparator
            Person[] listLastName = comparator.Compare(arrayPerson, new LastNameComparator());
            //Console.WriteLine("La prima persona in ordine di cognome è :"+listLastName[0].lastName);//Luca Cippo
            Console.WriteLine("Classifica ordinata per il cognome");
            for (i = 0; i <= listLastName.lenght; i++) {
              Console.WriteLine(listLastName[i]);
            }
            Console.ReadLine();
        }
    }

    /*
    * Comparatore della Età
    */
    class AgeComparator : IPersonStrategy
    {
        public Person[] Sort(Person[] arrayPerson)
        {
            Person[] result = new Person[arrayPerson.Count];
            /*
            if(p1.age > p2.age){
                result[0] = p2;
                result[1] = p1;
            }else{
                result[0] = p1;
                result[1] = p2;
            }
            */
            return result;
        }
    }
    /*
    * Comparatore del Nome
    */
    class FirstNameComparator : IPersonStrategy
    {
        public Person[] Sort(Person p1, Person p2)
        {
            Person[] result = new Person[2];

            if(p1.firstName.CompareTo(p2.firstName) > 0){
                result[0] = p2;
                result[1] = p1;
            }else{
                result[0] = p1;
                result[1] = p2;
            }
            return result;
        }
    }
    /*
    * Comparatore del Cognome
    */
    class LastNameComparator : IPersonStrategy
    {
        public Person[] Sort(Person p1, Person p2)
        {
            Person[] result = new Person[2];

            if(p1.lastName.CompareTo(p2.lastName) > 0){
                result[0] = p2;
                result[1] = p1;
            }else{
                result[0] = p1;
                result[1] = p2;
            }
            return result;
        }
    }

    interface IPersonStrategy
    {
        Person[] Sort(Person[] array);
    }

    //Comparatore delle Persone
    class PersonComparator
    {
        public Person[] Compare(Person[] arrayPerson, IPersonStrategy strategy){
            //Person[] pArray;
            pArray = strategy.Sort(arrayPerson);
            return pArray;

        }
    }

    //Classe Persona con attributi: Età, Nome, Cognome
    class Person
    {
        public int age;
        public string firstName;
        public string lastName;

        public Person(int a, string firstName, string lastName)
        {
            this.age = a;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
