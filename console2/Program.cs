public abstract class Animal
{
    private string Name;
    private string Species;
    private int Age;
    public abstract void Makesound();
    public abstract void Eat(string foodtype);
    public abstract void Move();
    public string Getname(){
        return Name;
    }
    public string GetSpecies(){
        return Species;
    }
    public int GetAge(){
        return Age;
    }
    public Animal(string name, string species, int age)
    {
        Name = name;
        Species = species;
        Age = age;
    }
}
class Lion : Animal
{
    public Lion(string name, int age) : base(name, "lion", age) { }
    public override void Makesound()
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
    public override void Makesound()
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
    public override void Makesound()
    {
        System.Console.WriteLine("A rabbit squeaks");
    }
    public override void Eat(string foodtype)
    {
        System.Console.WriteLine("A rabbit eats " + foodtype);
    }
    public override void Move()
    {
        System.Console.WriteLine("A rabbbit jumps");
    }

}
class Anoconda : Animal
{
    public Anoconda(string name, int age) : base(name, "Anoconda", age) { }
    public override void Makesound()
    {
        System.Console.WriteLine("An anoconda hisses");
    }
    public override void Eat(string foodtype)
    {
        System.Console.WriteLine("An anoconda eats " + foodtype);
    }
    public override void Move()
    {
        System.Console.WriteLine("An anoconda crawls");
    }

}
class Enclosure<T> where T : Animal
{
    private List<T> animalsinenclosure = new List<T>();
    public void Addanimal(T animal)
    {
        animalsinenclosure.Add(animal);
    }
    public void Removeanimal(T animal)
    {
        animalsinenclosure.Remove(animal);
    }
    public void DisplayAnimalDetails()
    {
        foreach (var animal in animalsinenclosure)
        {
            System.Console.WriteLine(animal.Getname(), animal.GetSpecies(), animal.GetAge());
        }
    }
    public void GetAnimalcount()
    {
        int a = 0;
        foreach (var animal in animalsinenclosure)
        {
            a++;
        }
        System.Console.WriteLine("the number of animal in enclosure is " + a);
    }
    public List<T> Getanimals()
    {
        return animalsinenclosure;
    }


}
class Zookeeper
{
    public void Feedanimalsinenclosure<T>(Enclosure<T> enclosure, string foodtype) where T : Animal
    {
        foreach (var animals in enclosure.Getanimals())
        {
            animals.Eat(foodtype);
        }
    }
    public void TriggerSoundsinenclosure<T>(Enclosure<T> enclosure) where T : Animal
    {
        foreach (var animals in enclosure.Getanimals())
        {
            animals.Makesound();
        }
    }
    public void ObserveMotionsinEnclosure<T>(Enclosure<T> enclosure) where T : Animal
    {
        foreach (var animals in enclosure.Getanimals())
        {
            animals.Move();
        }
    }
}
class Program
{
    static void Main()
    {
        Enclosure<Lion> lionenclosure = new Enclosure<Lion>();
        Enclosure<Eagle> aviary = new Enclosure<Eagle>();
        Enclosure<Rabbit> colony = new Enclosure<Rabbit>();
        Enclosure<Anoconda> knot = new Enclosure<Anoconda>();
        Eagle eagle1 = new Eagle("harry", 2);
        Eagle eagle2 = new Eagle("sam", 1);
        aviary.Addanimal(eagle1);
        aviary.Addanimal(eagle2);

        Rabbit rabbit1 = new Rabbit("rahul", 1);
        Rabbit rabbit2 = new Rabbit("ketu", 1);
        colony.Addanimal(rabbit1);
        colony.Addanimal(rabbit2);
        colony.GetAnimalcount();

        Anoconda anoconda1 = new Anoconda("nagin", 20);
        knot.Addanimal(anoconda1);

        Lion lion = new Lion("simbha", 20);
        Lion lion2 = new Lion("simbha", 22);
        Lion lion3 = new Lion("simbha", 23);
        lionenclosure.Addanimal(lion);
        lionenclosure.Addanimal(lion2);
        lionenclosure.Addanimal(lion3);

        Zookeeper zookeeper = new Zookeeper();
        zookeeper.ObserveMotionsinEnclosure(aviary);
        zookeeper.TriggerSoundsinenclosure(colony);
        zookeeper.Feedanimalsinenclosure(lionenclosure, "grass");
        

    }
}