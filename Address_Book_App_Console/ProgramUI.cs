using Address_Book_App_Repo;

namespace Address_Book_App_Console;

public class ProgramUI
{
    public readonly Address_Book_App_Data _contacts = new Address_Book_App_Data();

    public void Run() {
        RunMenu();
    }

    public void RunMenu() {
        bool WillRerun = true;
        do {
            System.Console.WriteLine("Enter the number of a command to run:\n" + 
            "1. Create new contact\n" + 
            "2. See all contacts\n" + 
            "3. Search contacts by ID\n" + 
            "4. Search contacts by name\n" + 
            "5. Edit contact name\n" + 
            "6. Edit contact address\n" + 
            "7. Remove contact\n" + 
            "8. Exit application");

            string? response = Console.ReadLine();

            switch (response) {
                case "1":
                    CreateContact();
                    System.Console.ReadKey();
                    break;
                case "2":
                    SeeAllContacts();
                    System.Console.ReadKey();
                    break;
                case "3":
                    FindContactByID();
                    System.Console.ReadKey();
                    break;
                case "4":
                    FindContactsByName();
                    System.Console.ReadKey();
                    break;
                case "5":
                    EditContactName();
                    System.Console.ReadKey();
                    break;
                case "6":
                    EditContactAddress();
                    System.Console.ReadKey();
                    break;
                case "7":
                    RemoveContact();
                    System.Console.ReadKey();
                    break;
                case "8":
                    System.Console.WriteLine("Exiting...");
                    WillRerun = false;
                    break;
                default:
                    System.Console.WriteLine("Input not recognized. Press Enter to return to menu.\n");
                    System.Console.ReadKey();
                    break;
            }

        } while (WillRerun);
    }

    private static string GetPlaceholderString(string? s) {
        // Used by program to fill empty contact properties for display purposes.
        if (s == null || s == "") {
            return "-";
        } else {
            return s;
        }
    }

    private static int AskValidID(string? input) {
        try {
            return Convert.ToInt32(input);
        } catch (Exception e) {
            System.Console.WriteLine(e.Message);
            return 0;
        }
    }

    private void CreateContact() {
        System.Console.Clear();
        System.Console.WriteLine("*** --- Create Contact --- ***\n");

        System.Console.WriteLine("Name: ");
        string newName = GetPlaceholderString(Console.ReadLine());

        System.Console.WriteLine("Address: ");
        string newAddress = GetPlaceholderString(Console.ReadLine());

        System.Console.WriteLine("Email: ");
        string newEmail = GetPlaceholderString(Console.ReadLine());

        System.Console.WriteLine("Phone (numbers only): ");
        string newPhone = GetPlaceholderString(Console.ReadLine());

        Contact contact;
        try {
            contact = new Contact(newName, newAddress, newEmail, newPhone);
        } catch (Exception e) {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine("Returning to menu...");
            return;
        }

        System.Console.WriteLine($"Contact [ID:{contact.ContactID}] created.");

        _contacts.AddContact(contact);

        System.Console.WriteLine($"Contact [ID:{contact.ContactID}] added to contacts.");
    }

    private void SeeAllContacts() {
        System.Console.Clear();
        System.Console.WriteLine("*** --- See All Contacts --- ***");

        List<Contact> currentContacts = _contacts.GetAllContacts();

        if (currentContacts.Count == 0) {
            System.Console.WriteLine("No Contacts.");
        } else {
            foreach (var c in currentContacts) {
                System.Console.WriteLine($"Contact {c.Name} [ID {c.ContactID}]");
            }
        }
    }

    private void FindContactByID() {
        System.Console.Clear();
        System.Console.WriteLine("*** --- Search Contacts by ID --- ***");

        List<Contact> currentContacts = _contacts.GetAllContacts();

        System.Console.WriteLine("Enter ID: ");

        int targetID = AskValidID(System.Console.ReadLine());
        if (targetID == 0) {
            System.Console.WriteLine("Returning to menu..."); 
            return; 
        }

        Contact? target = _contacts.GetContactByID(targetID);

        if (target != null) {
            System.Console.WriteLine($"Contact: {target.Name}, {target.ContactID}, {target.Email}, {target.Address}, {target.Phone}");
        } else {
            System.Console.WriteLine("Contact not found.");
        }
    }

    private void FindContactsByName() {
        System.Console.Clear();
        System.Console.WriteLine("*** --- Search Contacts by Name --- ***");

        System.Console.WriteLine("Name: ");
        string? name = System.Console.ReadLine();
        if (name == null) {
            System.Console.WriteLine("No name entered. Returning to menu...");
            return;
        } else {
            List<Contact> results = _contacts.GetContactsByName(name);
            if (results.Count == 0) {
                System.Console.WriteLine("No contacts found by name given.");
                return;
            }
            foreach (var c in results) {
                System.Console.WriteLine($"Contact {c.Name} [ID {c.ContactID}]");
            }
        }
    }

    private void EditContactName() {
        System.Console.Clear();
        System.Console.WriteLine("*** --- Edit Contact Name --- ***");

        System.Console.WriteLine("ID: ");

        int targetID = AskValidID(System.Console.ReadLine());
        if (targetID == 0) {
            System.Console.WriteLine("Returning to menu...");
            return;
        }

        Contact? contact = _contacts.GetContactByID(targetID);
        if (contact == null) {
            System.Console.WriteLine("Contact not found. Returning to menu...");
            return;
        }

        System.Console.WriteLine("Name: ");
        string? name = System.Console.ReadLine();
        if (name == null || name == "") {
            System.Console.WriteLine("Invalid name. Returning to menu...");
            return;
        }

        contact.Name = name;
        System.Console.WriteLine($"Contact {contact.ContactID} name changed.");
    }

    private void EditContactAddress() {
        System.Console.Clear();
        System.Console.WriteLine("*** --- Edit Contact Address --- ***");

        System.Console.WriteLine("ID: ");

        int targetID = AskValidID(System.Console.ReadLine());
        if (targetID == 0) {
            System.Console.WriteLine("Returning to menu...");
            return;
        }

        Contact? contact = _contacts.GetContactByID(targetID);
        if (contact == null) {
            System.Console.WriteLine("Contact not found. Returning to menu...");
            return;
        }

        System.Console.WriteLine("Address: ");
        string? address = System.Console.ReadLine();
        if (address == null || address == "") {
            System.Console.WriteLine("Invalid address. Returning to menu...");
            return;
        }

        contact.Address = address;
        System.Console.WriteLine($"Contact {contact.ContactID} address changed.");
    }

    private void RemoveContact() {
        System.Console.Clear();
        System.Console.WriteLine("*** --- Remove Contact --- ***");

        System.Console.WriteLine("ID: ");

        int targetID = AskValidID(System.Console.ReadLine());
        if (targetID == 0) {
            System.Console.WriteLine("Returning to menu...");
            return;
        }

        Contact? contact = _contacts.GetContactByID(targetID);
        if (contact == null) {
            System.Console.WriteLine("Contact not found. Returning to menu...");
            return;
        }

        System.Console.WriteLine($"Removing contact [ID: {contact.ContactID}]...");
        _contacts.RemoveContact(targetID);
    }
}