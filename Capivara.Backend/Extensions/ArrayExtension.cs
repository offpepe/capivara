using Capivara.Backend.Interfaces.Types;
using Capivara.Backend.Types;

namespace Capivara.Backend.Extensions;

public static class ArrayExtension
{
    public static void AppendTransaction(this Transaction[] transactions, Transaction transaction)
    {
        transactions[9] = transactions[8];
        transactions[8] = transactions[7];
        transactions[7] = transactions[6];
        transactions[6] = transactions[5];
        transactions[5] = transactions[4];
        transactions[4] = transactions[3];
        transactions[3] = transactions[2];
        transactions[1] = transactions[0];
        transactions[2] = transactions[1];
        transactions[0] = transaction;
    }

    public static Ordered<T>[] ConvertIntoOrdered<T>(this T[] array) where T : ISerial
    {
        var result = new Ordered<T>[array.Length];
        Ordered<T>? last = default;
        for (var i = 0; i < array.Length; i++)
        {
            var actual = new Ordered<T>(array[i], last, default);
            if (last != null) last.Next = actual;
            last = actual;
            result[i] = actual;
        }
        return result;
    }
    
    
}