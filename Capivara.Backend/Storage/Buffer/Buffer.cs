namespace Capivara.Backend.Storage.Buffer;

public static class Buffer
{
    public static void Write(this byte[] buffer, byte[] toWriteBuffer)
    {
        for (var i = 0; i < toWriteBuffer.Length; i++)
        {
            buffer[i] = toWriteBuffer[i];
        }
    }
    
    public static void Write(this byte[] buffer, byte[] toWriteBuffer, ref int position)
    {
        foreach (var wbyte in toWriteBuffer)
        {
            buffer[position] = wbyte;
            position++;
        }
    }
}