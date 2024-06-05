
using Microsoft.Data.SqlClient;
class UserRepo

{
    private readonly string _connectionString;

    public UserRepo(string connString)
    {
        _connectionString = connString;
    }


    public User? AddUser(User u)
    {

        using SqlConnection connection = new(_connectionString);
        connection.Open();

        string sql = "INSERT INTO dbo.[User] OUTPUT inserted.* VALUES (@Username, @Password, @Role)";

        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@Username", u.UserName);
        cmd.Parameters.AddWithValue("@Password", u.Password);
        cmd.Parameters.AddWithValue("@Role", u.Role);

        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            //If Read() found data -> then extract it.
            User newUser = BuildUser(reader); //Helper Method for doing that repetitive task
            return newUser;
        }
        else
        {
            //Else Read() found nothing -> Insert Failed. :(
            return null;
        }
    }
    public User? ViewUser(int id)
    {
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            string sql = "SELECT * FROM dbo.[User] WHERE Id = @Id";

            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                User newUser = BuildUser(reader);
                return newUser;
            }

            return null;

        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    //VIEW ALL
    public List<User>? GetAllUsers()
    {
        List<User> users = [];

        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            string sql = "SELECT * FROM dbo.[User]";

            using SqlCommand cmd = new(sql, connection);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                User newUser = BuildUser(reader);
                users.Add(newUser);
            }

            return users;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public User? UpdateUser(User u)
    {
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            string sql = "UPDATE dbo.[User] SET Username = @Username, Password = @Password, Role = @Role OUTPUT inserted.* WHERE Id = @Id";

            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Id", u.Id);
            cmd.Parameters.AddWithValue("@Username", u.UserName);
            cmd.Parameters.AddWithValue("@Password", u.Password);
            cmd.Parameters.AddWithValue("@Role", u.Role);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                User newUser = BuildUser(reader);
                return newUser;
            }

            return null;

        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }

    }
    public User? DeleteUser(User u)
    {
        try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "DELETE FROM dbo.[User] OUTPUT deleted.* WHERE Id = @Id";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Id", u.Id);

            //Execute the Query
            using var reader = cmd.ExecuteReader();

            //Extract the Results
            if (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                User newUser = BuildUser(reader);
                return newUser;
            }

            return null; //Didnt find anyone :(

        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    //Helper Method
    private static User BuildUser(SqlDataReader reader)
    {
        User newUser = new();
        newUser.Id = (int)reader["Id"];
        newUser.UserName = (string)reader["Username"];
        newUser.Password = (string)reader["Password"];
        newUser.Role = (string)reader["Role"];

        return newUser;
    }

    // UserUtil login = new();

    // public User AddUser(User u)
    // {
    //     u.Id = login.idCounter++;

    //     login.logins.Add(u.Id, u);
    //     return u;
    // }
    // public User? ViewUser(int id)
    // {
    //     if (login.logins.ContainsKey(id))
    //     {
    //         User selectedUser = login.logins[id];
    //         return selectedUser;
    //     }
    //     else
    //     {
    //         Console.WriteLine("You have not registered.");
    //         return null;
    //     }
    // }

    // //VIEW ALL
    // public List<User> GetAllUsers()
    // {
    //     return [.. login.logins.Values];
    // }

    // public User? UpdateUser(User u)
    // {
    //     try
    //     {
    //         login.logins[u.Id] = u;
    //         return u;
    //     }
    //     catch (Exception)
    //     {
    //         Console.WriteLine("You have not registered.");
    //         return null;
    //     }

    // }
    // public User? DeleteUser(User u)
    // {
    //     bool didRemove = login.logins.Remove(u.Id);

    //     if (didRemove)
    //     {
    //         return u;
    //     }
    //     else
    //     {
    //         Console.WriteLine("You have not registered.");
    //         return null;
    //     }
    // }

}
