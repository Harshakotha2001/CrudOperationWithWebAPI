namespace CrudOpp.Model
{
    public class AddContactRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }

        //public AddContactRequest contact { get; set; }  

    }
}
