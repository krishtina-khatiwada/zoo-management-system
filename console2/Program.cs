public abstract class Animal
{
    private string _name;
    private string _species;
    private int _age;
    public abstract void MakeSound();
    public abstract void Eat(string foodtype);
    public abstract void Move();

    public string GetName(){
        return _name;
    }
    public string GetSpecies(){
        return _species;
    }
    public int GetAge(){
        return _age;
    }
    public Animal(string name, string species, int age)
    {
        _name = name;
        _species = species;
        _age = age;
    }
}
class Lion : Animal
{
    public Lion(string name, int age) : base(name, "lion", age) { }
    public override void MakeSound()
    {
        System.Console.WriteLine("A lion roars");
    }
    public override void Eat(string foodtype)
    {
        System.Console.WriteLine("A lion eats " + foodtype);
    }
    public override void Move()
    {
        System.Console.WriteLine("A lion walks");
    }

}
class Eagle : Animal
{
    public Eagle(string name, int age) : base(name, "Eagle", age) { }
    public override void MakeSound()
    {
        System.Console.WriteLine("An eagle screeches");
    }
    public override void Eat(string foodtype)
    {
        System.Console.WriteLine("An eagle eats "+ foodtype);
    }
    public override void Move()
    {
        System.Console.WriteLine("An eagle flies");
    }

}
class Rabbit : Animal
{
    public Rabbit(string name, int age) : base(name, "Rabbit", age) { }
    public override void MakeSound()
    {
        System.Console.WriteLine("A rabbit squeaks");
    }
    public override void Eat(string foodType)
    {
        System.Console.WriteLine("A rabbit eats " + foodType);
    }
    public override void Move()
    {
        System.Console.WriteLine("A rabbbit jumps");
    }

}
class Anoconda : Animal
{
    public Anoconda(string name, int age) : base(name, "Anoconda", age) { }
    public override void MakeSound()
    {
        System.Console.WriteLine("An anoconda hisses");
    }
    public override void Eat(string foodType)
    {
        System.Console.WriteLine("An anoconda eats " + foodType);
    }
    public override void Move()
    {
        System.Console.WriteLine("An anoconda crawls");
    }

}
class Enclosure<T> where T : Animal
{
    private List<T> _animalsInEnclosure = new List<T>();
    public void AddAnimal(T animal)
    {
       _animalsInEnclosure.Add(animal);
    }
    public void RemoveAnimal(T animal)
    {
        _animalsInEnclosure.Remove(animal);
    }
    public void DisplayAnimalDetails()
    {
        foreach (var animal in _animalsInEnclosure)
        {
            System.Console.WriteLine($"Name: {animal.GetName()}, Species: {animal.GetSpecies()}, Age: {animal.GetAge()}");
        }
    }
    public void GetAnimalCount()
    {
        int a = 0;
        foreach (var animal in _animalsInEnclosure)
        {
            a++;
        }
        System.Console.WriteLine("the number of animal in enclosure is " + a);
    }
    public List<T> GetAnimals()
    {
        return _animalsInEnclosure;
    }


}
class Zookeeper
{
    public void FeedAnimalsInEnclosure<T>(Enclosure<T> enclosure, string foodType) where T : Animal
    {
        foreach (var animals in enclosure.GetAnimals())
        {
            animals.Eat(foodType);
        }
    }
    public void TriggerSoundsInEnclosure<T>(Enclosure<T> enclosure) where T : Animal
    {
        foreach (var animals in enclosure.GetAnimals())
        {
            animals.MakeSound();
        }
    }
    public void ObserveMotionsInEnclosure<T>(Enclosure<T> enclosure) where T : Animal
    {
        foreach (var animals in enclosure.GetAnimals())
        {
            animals.Move();
        }
    }
}
class Program
{
    static void Main()
    {
        Enclosure<Lion> _lionEnclosure = new Enclosure<Lion>();
        Enclosure<Eagle> _aviary = new Enclosure<Eagle>();
        Enclosure<Rabbit> _colony = new Enclosure<Rabbit>();
        Enclosure<Anoconda> _knot = new Enclosure<Anoconda>();
        Eagle eagle1 = new Eagle("harry", 2);
        Eagle eagle2 = new Eagle("sam", 1);
        _aviary.AddAnimal(eagle1);
        _aviary.AddAnimal(eagle2);

        Rabbit rabbit1 = new Rabbit("rahul", 1);
        Rabbit rabbit2 = new Rabbit("ketu", 1);
        _colony.AddAnimal(rabbit1);
        _colony.AddAnimal(rabbit2);
        _colony.GetAnimalCount();

        Anoconda anoconda1 = new Anoconda("nagin", 20);
        _knot.AddAnimal(anoconda1);

        Lion lion = new Lion("simbha", 20);
        Lion lion2 = new Lion("simbha", 22);
        Lion lion3 = new Lion("simbha", 23);
        _lionEnclosure.AddAnimal(lion);
        _lionEnclosure.AddAnimal(lion2);
        _lionEnclosure.AddAnimal(lion3);

        Zookeeper zookeeper = new Zookeeper();
        zookeeper.ObserveMotionsInEnclosure(_aviary);
        zookeeper.TriggerSoundsInEnclosure(_colony);
        zookeeper.FeedAnimalsInEnclosure(_lionEnclosure, "grass");
        

    }
}