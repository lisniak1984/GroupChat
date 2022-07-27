//Специальное меню для пользователя и чата
//Возможность просмотра всего чата со стороны группы
//+Должно быть видно от кого это сообщение
//+Возможность добавления человек и удаления из группы
//+Возможность войти в аккаунт человека и выйти
//+Возможность написать сообщение в группу от имени человека
//+Просмотр чата от имени человека
User user1 = new User("Fedja", "fedor123", "fff");
User user2 = new User("Gena", "gena123", "ggg");
User user3 = new User("Anna", "ana123", "aaa");

Group group = new Group();
group.AddUser(user1);
group.AddUser(user2);
group.AddUser(user3);



group.ShowGroup();
group.ToString();

class User
{
    public string FirstName { get; private set; }
    public string Login { get; private set; }
    private string _password;
    private bool _loggedIn;

    public User(string firstName, string login, string password, bool loggedIn = false)
    {
        FirstName = firstName;
        Login = login;
        _password = password;
        _loggedIn = loggedIn;
    }
    public User()
    {
    }
    public bool SignIn(string login, string password)
    {

        if (Login == login && _password == password)
        {
            _loggedIn = true;
            return true;
        }
        else if (Login == login && _password != password)
            Console.WriteLine("Wrong password");
        return false;
    }//+
    public string WriteMesage(string mesage)//+
    {
        if (!_loggedIn)
        {
            Console.WriteLine($"{Login} is logout");
            return null;
        }

        return FirstName + ": " + mesage;
    }
    public void Info(User user)
    {
        Console.WriteLine($"\nName: {FirstName}, Login: {Login}");
    }

}
class Group
{
    private string[] _chat = new string[1];

    public User[] _users = new User[5];
    public string Name { get; private set; }

    public Group()
    {
    }
    public Group(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Метод который выводит
    /// </summary>
    
    public bool AddUser(User user)//+
    {
        for (int i = 0; i < _users.Length; i++)
        {
            if (_users[i]?.Login == user.Login)
            {
                Console.WriteLine("Пользователь с таким логином уже есть");
                return false;
            }

            if (_users[i] == null)
            {
                _users[i] = user;
                return true;
            }
        }
        return false;
    }
    public void ShowChat()
    {
        foreach (var item in _chat)
        {
            Console.WriteLine(item);
        }
    }//+
    public void ShowUsers()
    {
        for (int i = 0; i < _users.Length; i++)
        {
            _users[i]?.Info(_users[i]);
        }

    }//+
    public User FindByLogin(string login)
    {
        for (int i = 0; i < _chat.Length; i++)
        {
            if (_users[i].Login == login)
                return _users[i];
        }
        return null;
    }//+
    public void DeleteUser(string login)
    {
        for (int i = 0; i < _chat.Length; i++)
            if (_users[i].Login == login)
                _users[i] = null;
    }//+

    public void AddMesage(string mesage)
    {
        _chat[_chat.Length - 1] = mesage;
        Array.Resize(ref _chat, _chat.Length + 1);
    }//+
    public void UserMenu()
    {
        string login = default;
        string password = default;
        Console.WriteLine("Enter login and password\nLogin...");
        login = Console.ReadLine();
        Console.WriteLine("Password...");
        password = Console.ReadLine();
        User user = FindByLogin(login);

        if (user == null)
            return;

        if (!user.SignIn(login, password))
            return;

        // Napisat' soobshenie
        // Vyjti iz menu (= vyhod iz akkaunta)
        // Menjat' znachenie SignIn (true, false).

    }
    public void Menu()
    {
        ShowChat();
        string choice = Console.ReadLine();
        
        Console.WriteLine("\nUser menu - press '1'\nGroup menu - press '2'");

        if (choice == "1")
        {
            Console.WriteLine();
            // user menu. Sozdat' i vyzyvat'
        }
        if (choice == "2")//Show chat, Show users, Add user, Delete user.
        {

        }
        
        
        else
        {
            Console.WriteLine("Wrong choice");
        }
    }
}