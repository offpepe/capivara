using System.Text;
// ReSharper disable ForCanBeConvertedToForeach 
// not using stateMachine

namespace Rinha2024.VirtualDb.buffer;

public static class Text
{
    public static void WriteText(this byte[] buffer, string text)
    {
        var charBytes = Encoding.UTF8.GetBytes(text);
        for (var i = 0; i < charBytes.Length; i++)
        {
            buffer[i] = charBytes[i];
        }
    }
    
    public static void WriteText(this byte[] buffer, string text, ref int position)
    {
        var charBytes = Encoding.UTF8.GetBytes(text);
        for (var i = 0; i < charBytes.Length; i++)
        {
            buffer[position] = charBytes[i];
            position++;
        }
    }
    
    public static void WriteText(this byte[] buffer, string text, Encoding encoding, ref int position)
    {
        var charBytes = encoding.GetBytes(text);
        for (var i = 0; i < charBytes.Length; i++)
        {
            buffer[position] = charBytes[i];
            position++;
        }
    }
    
    public static void WriteText(this byte[] buffer, string text, Encoding encoding)
    {
        var charBytes = encoding.GetBytes(text);
        for (var i = 0; i < charBytes.Length; i++)
        {
            buffer[i] = charBytes[i];
        }
    }

    public static string ReadText(this byte[] buffer)
    {
        return Encoding.UTF8.GetString(buffer);
    }
    
    public static string ReadText(this byte[] buffer, ref int position)
    {
        var str = Encoding.UTF8.GetString(buffer);
        position += str.Length;
        return str;
    }
    
    public static string ReadText(this byte[] buffer, Encoding encoding)
    {
        return encoding.GetString(buffer);
    }
    
    public static string ReadText(this byte[] buffer, Encoding encoding, ref int position)
    {
        var str = encoding.GetString(buffer);
        position += str.Length;
        return str;
    }
}