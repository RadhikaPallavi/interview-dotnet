using Xunit;
using UserController;

public class UserControllerTest
{
    [fact]
    public void AddUserReturnsOk()
    {
        var controller = new UserController();
        string fName = "Radhika";
        string lName = "pa";
        string phNumber = "abcdefghij";

        var result = controller.AddUser(fName, lName, phNumber);

        Assert.Equal(200, result.StatusCode);
    }
}