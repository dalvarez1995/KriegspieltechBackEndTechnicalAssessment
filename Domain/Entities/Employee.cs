using Kriegspieltech.Domain;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public Employee(int id, string fullname, DateTime birth)
        {
            Id = id;
            FullName = fullname;
            Birth = birth;
        }

        public Employee(string fullname, DateTime birth)
        {
            FullName = fullname;
            Birth = birth;
        }

        public Employee()
        {
            
        }
        public string FullName { get; set; }

        public DateTime Birth { get; set; }
    }
}
