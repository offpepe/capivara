﻿namespace Rinha2024.VirtualDb.buffer;

public static class Boolean
{
    public static void WriteBoolean(this byte[] buffer, bool value)
    {
        if (value) buffer[0] = 1;
        buffer[0] = 0;
    }
    
    public static void WriteBoolean(this byte[] buffer, bool value, ref int position)
    {
        if (value) buffer[position] = 1;
        buffer[position] = 0;
    }
}