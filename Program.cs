using System;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var nipote = new Person(6, "Luca", "Cippo");
            var nonno = new Person(75, "Aristide", "Merotti");
            var mario = new Person(75, "Mario", "Perotti");
            var gino = new Person(75, "Gino", "Negro");
            var lorenzo = new Person(75, "Lorenzo", "Verratti");
            var marcello = new Person(75, "Marcello", "Ciccio");
            var davide = new Person(75, "Davide", "Basso");
          

            Person[] arrayPerson = {nipote,nonno,mario,gino,lorenzo,marcello,davide};

            var comparator = new PersonComparator();

            // Età Comparator
            Person[] listAge = comparator.Compare(arrayPerson, new AgeComparator());
            //Console.WriteLine("La persona più giovane è :"+listAge[0].name);//Luca Cippo
            Console.WriteLine("Classifica ordinata per l'età:");
            for (i = 0; i <= listAge.lenght; i++) {
              Console.WriteLine(listAge[i]);
            }
            // Nome Comparator
            Person[] listFirstName = comparator.Compare(arrayPerson, new NameComparator());
            //Console.WriteLine("La prima persona in ordine di nome è :"+listFirstName[0].firstName);//Aristide Merotti
            Console.WriteLine("Classifica ordinata per il nome");
            for (i = 0; i <= listFirstName.lenght; i++) {
              Console.WriteLine(listFirstName[i]);
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
            //Bubble Sort
            int i;
            int j;
            int temp;

            for (i = (x - 1); i >= 0; i--)
            {
              for (j = 1; j <= i; j++)
              {
                if (arrayPerson[j - 1].age > arrayPerson[j].age)
                {
                  temp = arrayPerson[j - 1];
                  arrayPerson[j - 1] = arrayPerson[j];
                  arrayPerson[j] = temp;
                }
              }
            }
            result = arrayPerson;
            return result;
        }
    }
    /*
    * Comparatore del Nome e Cognome
    */
    class NameComparator : IPersonStrategy
    {
        public Person[] Sort(Person[] arrayPerson)
        {
            Person[] result = new Person[arrayPerson.lenght];
            for (int i = 0; i < arrayPerson.length-1; i++)
			{
                if(arrayPerson[i].firstName.CompareTo(arrayPerson[i+1].firstName) > 0){
                result[i] = arrayPerson[i+1];
                result[i+1] = arrayPerson[i];
            }
            else if (arrayPerson[i].firstName.CompareTo(arrayPerson[i+1].firstName) < 0){
                result[i] = arrayPerson[i];
                result[i+1] = arrayPerson[i+1];
            }
            else{
                if(arrayPerson[i].lastName.CompareTo(arrayPerson[i+1].lastName) > 0){
                    result[i] = arrayPerson[i+1];
                    result[i+1] = arrayPerson[i];
                }
                else if (arrayPerson[i].lastName.CompareTo(arrayPerson[i+1].lastName) < 0){
                    result[i] = arrayPerson[i];
                    result[i+1] = arrayPerson[i+1];
                }
            }
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
