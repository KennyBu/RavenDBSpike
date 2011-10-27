using System;

namespace RavenDBSpike
{
    public class CustomerDocument
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}