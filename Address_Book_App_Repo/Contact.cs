namespace Address_Book_App_Repo;
public class Contact
{
    public int ContactID {get;}
    public string? Name {get; set;}
    public string? Address {get; set;}
    public string? Email {get; set;}
    public string? Phone {get; set;}
    
    public Contact() {
        ContactID = new Random().Next(10_000);
    }
    
    public Contact(string name) {
        ContactID = new Random().Next(10_000);
        Name = name;
    }

    public Contact(string name, string address, string email, string phone) {
        ContactID = new Random().Next(10_000);
        Name = name;
        Address = address;
        Email = email;
        Phone = phone;
    }
}