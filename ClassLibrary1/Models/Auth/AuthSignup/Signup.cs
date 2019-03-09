using System;

namespace ApiTests.Models.Auth.AuthSignup
{
    public class Signup : Person
    {
        public int client_id { get; set; }
        public string client_secret { get; set; }
        public string phone { get; set; }
        public string password { get; set; } 
        public TestMode test_mode { get; set; }

        public override void DisplayBody()
        {
            Console.WriteLine($"first_name = {first_name}" +
                              $", second_name = {last_name}" +
                              $", birthday = {birthday}" +
                              $", sex = {sex}, " +
                              $", client_id {client_id}" +
                              $", client_secret {client_secret}" +
                              $", phone = {phone}" +
                              $", password {password}" +
                              $", test_mode {test_mode}");
        }
    }
}
