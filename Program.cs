using System;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var nipote = new Person(6, "Luca", "Cippo");
            var nonno = new Person(75, "Aristide", "Merotti");

            var comparator = new PersonComparator();

            Person[] listAge = comparator.Compare(nipote, nonno, new AgeComparator());
            Console.WriteLine("La persona più giovane è :"+listAge[0].name);//Luca Cippo

            Person[] listFirstName = comparator.Compare(nipote, nonno, new FirstNameComparator());
            Console.WriteLine("La prima persona in ordine di nome è :"+listFirstName[0].firstName);//Aristide Merotti

            Person[] listLastName = comparator.Compare(nipote, nonno, new LastNameComparator());
            Console.WriteLine("La prima persona in ordine di cognome è :"+listLastName[0].lastName);//Luca Cippo

            Console.ReadLine();
        }
    }

    /*
    * Comparatore della Età
    */
    class AgeComparator : IPersonStrategy
    {
        public Person[] Sort(Person p1, Person p2)
        {
            Person[] result = new Person[2];

            if(p1.age > p2.age){
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
        Person[] Sort(Person p1, Person p2);
    }

    class PersonComparator
    {
        public Person[] Compare(Person p1, Person p2, IPersonStrategy strategy){
            Person[] pArray;

            pArray = strategy.Sort(p1, p2);

            return pArray;

        }
    }

    class Person
    {
        public int age;
        public string firstName;
        public string lastName;

        public Person(int a, string firstName, string lastName)
        {
            age = a;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
