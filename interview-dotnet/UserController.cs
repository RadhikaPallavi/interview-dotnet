using System.Data;
using System.Data.Client;

public class UserController 
{
    [httpPost]
    public IActionResult AddUser(string fName, string lName, string phNumber)
    {
        using ( var sqlConnect = new  SqlConnection("MyConnectionString"))
        {
            sqlConnect.Open();
            //Considering there is a Stored Procedure names "AddUser" using the following three inputs.
            using( var command = new SqlConnection("AddUser", sqlConnect))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@FirstName", SqlDbType.Varchar).value = fName;
                command.Parameters.Add("@LasatName", SqlDbType.Varchar).value = lName;
                command.Parameters.Add("@PhoneNumber", SqlDbType.Varchar).value = phNumber;

                command.ExecuteNonQuery();
            }
        }
        return  Ok();
    }

    [httpPost]
    public async Task<IActionResult> ReadFile(IFormFile file)
    {
        if(file != null || file.length >0)
        {
            using  (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek()>=0)
                {
                    console.Writeline( await reader.ReadLineAsunc());
                }

            }
            return OK(await reader.ReadToEndAsynch());
        }
    }
}