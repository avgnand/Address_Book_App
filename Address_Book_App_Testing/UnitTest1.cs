using Address_Book_App_Repo;

namespace Address_Book_App_Testing;

public class UnitTest1
{
    [Fact]
    public void DidAddContact()
    {
        Address_Book_App_Data test = new Address_Book_App_Data();
        test.AddContact(new Contact());

        int expected = 1;
        int actual = test._contacts.Count;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DidGetAllContacts() {
        Address_Book_App_Data test = new Address_Book_App_Data();
        test.AddContact(new Contact());
        test.AddContact(new Contact("Olympia"));
        test.AddContact(new Contact("Targus"));

        int expected = 3;
        int actual = test.GetAllContacts().Count;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DidGetContactByID() {
        Address_Book_App_Data test = new Address_Book_App_Data();
        test.AddContact(new Contact("Glup Shitto", "Naboo", "gshitto@empiremail.com", "15550707"));
        test.AddContact(new Contact("Glup Shitto", "Hoth", "gshitto@rebelmail.com", "15550655"));

        int target_key = test._contacts.First(kvp => kvp.Value.Address == "Naboo").Key;
        string expected = "Naboo";
        Contact? target_contact = test.GetContactByID(target_key);
        string? actual = (target_contact == null ? null : target_contact.Address);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DidGetContactsByName() {
        Address_Book_App_Data test = new Address_Book_App_Data();
        test.AddContact(new Contact("Saffron"));
        test.AddContact(new Contact("Saffron"));
        test.AddContact(new Contact("Vermillion"));
        test.AddContact(new Contact("Vermillion"));

        int expected = 4;
        int actual = test.GetContactsByName("Saffron").Count + test.GetContactsByName("Vermillion").Count;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DidEditContactName() {
        Address_Book_App_Data test = new Address_Book_App_Data();
        test.AddContact(new Contact("Hampter"));
        test.AddContact(new Contact("Amogus"));

        int target_key = test._contacts.First(kvp => kvp.Value.Name == "Amogus").Key;
        test.EditContactName(target_key, "Chegg");

        string expected = "Chegg";
        string? actual = test._contacts[target_key].Name;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DidEditContactAddress() {
        Address_Book_App_Data test = new Address_Book_App_Data();
        test.AddContact(new Contact("Macaroni"));
        test.AddContact(new Contact("Pepperoni"));

        int target_key = test._contacts.First(kvp => kvp.Value.Name == "Pepperoni").Key;
        test.EditContactAddress(target_key, "Marinara Blvd.");

        string expected = "Marinara Blvd.";
        string? actual = test._contacts[target_key].Address;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DidEditContactPhone() {
        Address_Book_App_Data test = new Address_Book_App_Data();
        test.AddContact(new Contact("Mario", "Oak Ave.", "mario@email.com", "5559787"));
        test.AddContact(new Contact("Luigi", "Elm St.", "luigi@email.com", "5550486"));

        int target_key = test._contacts.First(kvp => kvp.Value.Name == "Luigi").Key;
        test.EditContactPhone(target_key, "8675309");

        string expected = "8675309";
        string? actual = test._contacts[target_key].Phone;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DidEditContactEmail() {
        Address_Book_App_Data test = new Address_Book_App_Data();
        test.AddContact(new Contact("Mario", "Oak Ave.", "mario@email.com", "5559787"));
        test.AddContact(new Contact("Luigi", "Elm St.", "luigi@email.com", "5550486"));

        int target_key = test._contacts.First(kvp => kvp.Value.Name == "Mario").Key;
        test.EditContactEmail(target_key, "peach@email.com");

        string expected = "peach@email.com";
        string? actual = test._contacts[target_key].Email;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DidRemoveContact() {
        Address_Book_App_Data test = new Address_Book_App_Data();
        test.AddContact(new Contact("Foo"));
        test.AddContact(new Contact("Bar"));
        test.AddContact(new Contact("Baz"));

        int target_key = test._contacts.First(kvp => kvp.Value.Name == "Bar").Key;
        test.RemoveContact(target_key);

        int expected = 2;
        int actual = test.GetAllContacts().Count;

        Assert.Equal(expected, actual);
    }
}