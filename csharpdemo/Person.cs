namespace csharpdemo
{
    public class Person
    {
        public Person(string name, string email, int age)
        {
            this.Name = name;
            this.Email = email;
            this.Age = age;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public Person WithName(string newName) { return new Person(newName, this.Email, this.Age); }
        public Person WithEmail(string newEmail) { return new Person(this.Name, newEmail, this.Age); }
        public Person WithAge(int newAge) { return new Person(this.Name, this.Email, newAge); }

    }

    /// <summary>
    /// Demonstrates updating the properties on a Person
    /// </summary>
    public class PersonExample
    {
        /// <summary>
        /// If the class is mutable, just use assignment
        /// </summary>
        public static void Mutable()
        {
            var p = new Person("Scott", "scott@example.com", 21);

            // Person is mutable
            p.Name = "Tom";
            p.Email = "tom@example.com";
            p.Age = 42;
        }

        /// <summary>
        /// If the class is immutable, it can get repetitive
        /// </summary>
        public static void Immutable_v1()
        {
            // Person is immutable
            var p = new Person("Scott", "scott@example.com", 21);
            var p2 = p.WithName("Tom");
            var p3 = p2.WithEmail("tom@example.com");
            var p4 = p3.WithAge(42);
        }

        /// <summary>
        /// If the class is immutable, you end up with a pipeline
        /// </summary>
        public static void Immutable_v2()
        {
            // Person is immutable
            var p = new Person("Scott", "scott@example.com", 21);
            p
            .WithName("Tom")
            .WithEmail("tom@example.com")
            .WithAge(42);
        }

    }
}
