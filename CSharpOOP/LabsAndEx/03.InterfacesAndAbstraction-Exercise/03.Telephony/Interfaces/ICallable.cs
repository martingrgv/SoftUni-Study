namespace PhoneManufactory.Interfaces;
public interface ICallable
{
	public void Call(string number);
	public bool isNumberValid(string number);
}

