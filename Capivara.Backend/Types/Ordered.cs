using Capivara.Backend.Interfaces.Types;

namespace Capivara.Backend.Types;

public class Ordered<T>(T actual, Ordered<T>? last, Ordered<T>? next)  where T: ISerial
{
    public T Actual { get; set; } = actual; 
    public Ordered<T>? Last { get; set; } =  last;
    public Ordered<T>? Next { get; set; } =  next;
}