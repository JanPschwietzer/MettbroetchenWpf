using System.Net.Mail;

namespace MettbrötchenWpf.MVVM;

public static class Helpers
{
    public static bool EmailisValid(string email)
    { 
        var valid = true;
            
        try
        { 
            var emailAddress = new MailAddress(email);
        }
        catch
        {
            valid = false;
        }

        return valid;
    }
}