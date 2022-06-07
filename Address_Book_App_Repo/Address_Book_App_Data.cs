namespace Address_Book_App_Repo;

public class Address_Book_App_Data
{
    public Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();

    public void AddContact(Contact newContact) {
        _contacts.Add(newContact.ContactID, newContact);
    }

    public List<Contact> GetAllContacts() {
        List<Contact> result = new List<Contact>();
        foreach(var c in _contacts) {
            result.Add(c.Value);
        }
        return result;
    }

    public Contact? GetContactByID(int IDnum) {
        try {
            return _contacts[IDnum];
        } catch (Exception e) {
            System.Console.WriteLine(e.Message);
            return null;
        }
    }

    public List<Contact> GetContactsByName(string name) {
        List<Contact> result = new List<Contact>();
        foreach (var c in _contacts) {
            if (c.Value.Name == name) {
                result.Add(_contacts[c.Key]);
            }
        }
        return result;
    }

    public void EditContactName(int IDnum, string name) {
        Contact? target = GetContactByID(IDnum);
        if (target != null) {
            target.Name = name;
        } else {
            System.Console.WriteLine("Contact not found.");
        }
    }

    public void EditContactAddress(int IDnum, string address) {
        Contact? target = GetContactByID(IDnum);
        if (target != null) {
            target.Address = address;
        } else {
            System.Console.WriteLine("Contact not found.");
        }
    }

    // TODO: Add more Update methods

    public void RemoveContact(int IDnum) {
        Contact? target = GetContactByID(IDnum);
        if (target != null) {
            _contacts.Remove(target.ContactID);
        } else {
            System.Console.WriteLine("Contact not found.");
        }
    }
}