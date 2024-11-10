using Lab01Ak.Models;

namespace LaboratoriumASPNET.Models.Services;

public class MemoryContactService : IContactService
{
    private Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1,
            new ContactModel
            {
                FirstName = "Jane",
                LastName = "Smith",
                Category = Category.Friend,
                Id = 2,
                Email = "jane.smith@yahoo.com",
                PhoneNumber = "07777777777",
                BirthDate = new DateTime(1990, 5, 15)

            }
        },
        
        {
            2,
            new ContactModel
            {
                FirstName = "Michael",
                LastName = "Johnson",
                Category = Category.Business,
                Id = 3,
                Email = "michael.johnson@outlook.com",
                PhoneNumber = "06666666666",
                BirthDate = new DateTime(1985, 8, 23)

            }
        },
        {
            3,
            new ContactModel
            {
                FirstName = "Emily",
                LastName = "Brown",
                Category = Category.Family,
                Id = 4,
                Email = "emily.brown@hotmail.com",
                PhoneNumber = "05555555555",
                BirthDate = new DateTime(2000, 12, 3)

            }
        }
    };

    private int _index = 3;

    public void Add(ContactModel model)
    {
        model.Id = ++_index;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel contact)
    {
        if (_contacts.ContainsKey(contact.Id))
        {
            _contacts[contact.Id] = contact;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        _contacts.TryGetValue(id, out var contact);
        return contact;
    }
}
