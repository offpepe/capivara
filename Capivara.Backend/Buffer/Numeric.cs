
namespace Rinha2024.VirtualDb.buffer;

public static class Numeric
{
    public static int ReadInteger(this byte[] buffer)
    {
        return BitConverter.ToInt32(buffer);
    }
    
    public static int ReadInteger(this byte[] buffer, ref int position)
    {
        var result = BitConverter.ToInt32(buffer, position);
        position += sizeof(int);
        return result;
    }
    
    public static long ReadLong(this byte[] buffer)
    {
        return BitConverter.ToInt64(buffer);
    }
    
    public static long ReadLong(this byte[] buffer, ref int position)
    {
        var result = BitConverter.ToInt64(buffer, position);
        position += sizeof(long);
        return result;
    }

    
    public static double ReadDouble(this byte[] buffer)
    {
        return BitConverter.ToDouble(buffer);
    }
    
    public static double ReadDouble(this byte[] buffer, ref int position)
    {
        var result = BitConverter.ToDouble(buffer, position);
        position += sizeof(double);
        return result;
    }
    
    public static float ReadFloat(this byte[] buffer)
    {
        return BitConverter.ToSingle(buffer);
    }
    
    public static float ReadFloat(this byte[] buffer, ref int position)
    {
        var result = BitConverter.ToSingle(buffer, position);
        position += sizeof(float);
        return result;
    }
    
    public static decimal ReadDecimal(this byte[] buffer, ref int position)
    {
        var result = (decimal) BitConverter.ToSingle(buffer, position); 
        position += sizeof(float);
        return result;
    }
    
    public static void WriteNumeric(this byte[] buffer, int value)
    {
        var bytes = BitConverter.GetBytes(value);
        for (var i = 0; i < 4; i++)
        {
            buffer[i] = bytes[i];
        }
    }

    public static void WriteNumeric(this byte[] buffer, int value, ref int position)
    {
        var bytes = BitConverter.GetBytes(value);
        for (var i = 0; i < 4; i++)
        {
            buffer[position] = bytes[i];
            position++;
        }
    }
    
    

    public static void WriteNumeric(this byte[] buffer, long value)
    {
        var bytes = BitConverter.GetBytes(value);
        for (var i = 0; i < 8; i++)
        {
            buffer[i] = bytes[i];
        }
    }

    public static void WriteNumeric(this byte[] buffer, long value, ref int position)
    {
        var bytes = BitConverter.GetBytes(value);
        for (var i = 0; i < 8; i++)
        {
            buffer[position] = bytes[i];
            position++;
        }
    }

    public static void WriteNumeric(this byte[] buffer, float value)
    {
        var bytes = BitConverter.GetBytes(value);
        for (var i = 0; i < 8; i++)
        {
            buffer[i] = bytes[i];
        }
    }

    public static void WriteNumeric(this byte[] buffer, float value, ref int position)
    {
        var intbytes = BitConverter.GetBytes(value);
        for (var i = 0; i < 8; i++)
        {
            buffer[position] = intbytes[i];
            position++;
        }
    }

    public static void WriteNumeric(this byte[] buffer, double value, ref int position)
    {
        var intbytes = BitConverter.GetBytes(value);
        for (var i = 0; i < 8; i++)
        {
            buffer[position] = intbytes[i];
            position++;
        }
    }

    public static void WriteNumeric(this byte[] buffer, double value)
    {
        var intbytes = BitConverter.GetBytes(value);
        for (var i = 0; i < 8; i++)
        {
            buffer[i] = intbytes[i];
        }
    }

    public static void WriteNumeric(this byte[] buffer, decimal value)
    {
        var intbytes = value.ToByteArray();
        for (var i = 0; i < 8; i++)
        {
            buffer[i] = intbytes[i];
        }
    }

    public static void WriteNumeric(this byte[] buffer, decimal value, ref int position)
    {
        var intbytes = value.ToByteArray();
        for (var i = 0; i < 8; i++)
        {
            buffer[position] = intbytes[i];
            position++;
        }
    }

    private static byte[] ToByteArray(this decimal value)
    {
        var bits = decimal.GetBits(value);
        var byteArray = new byte[bits.Length * sizeof(int)];
        Buffer.BlockCopy(bits, 0, byteArray, 0, byteArray.Length);
        return byteArray;
    }

}