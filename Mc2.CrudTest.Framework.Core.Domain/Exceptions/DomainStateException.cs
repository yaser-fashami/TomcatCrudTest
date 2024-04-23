namespace Mc2.CrudTest.Framework.Core.Domain.Exceptions;
public class DomainStateException: Exception
{
    public string[] Parameters { get; set; }

    public DomainStateException(string message, params string[] parameters):base(message)
    {
        Parameters = parameters;
    }

    public override string ToString()
    {
        if (Parameters?.Length < 1)
        {
            return Message;
        }
        string result = Message;
        for (int i = 0; i < Parameters?.Length; i++)
        {
            string placeHolder = $"{{{i}}}";
            result = Message.Replace(placeHolder, Parameters[i]);
        }
        return result;
    }
}
