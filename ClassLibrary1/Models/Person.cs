namespace ApiTests.Models
{
    public abstract class Person
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string birthday { get; set; }
        public Sex sex { get; set; }

        public abstract void DisplayBody();
    }
}
