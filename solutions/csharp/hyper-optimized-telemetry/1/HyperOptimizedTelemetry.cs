public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];
        byte[] valueBytes;
        byte prefix;
        byte byteCount;

        if(reading >= ushort.MinValue && reading <= ushort.MaxValue){
            // ushort (0 a 65,535)
            valueBytes = BitConverter.GetBytes((ushort)reading);
            byteCount = 2;
            prefix = (byte)byteCount;
        }else if(reading >= (long)ushort.MaxValue + 1 && reading <= int.MaxValue){
            // int positivo (65,536 a 2,147,483,647)
            valueBytes = BitConverter.GetBytes((int)reading);
            byteCount = 4;
            prefix = (byte)(256 - byteCount);
        }else if(reading >= (long)int.MaxValue + 1 && reading <= uint.MaxValue){
            // uint (2,147,483,648 a 4,294,967,295)
            valueBytes = BitConverter.GetBytes((uint)reading);
            byteCount = 4;
            prefix = (byte)byteCount;
        }else if(reading >= (long)uint.MaxValue + 1 && reading <= long.MaxValue){
            // long positivo (4,294,967,296 a 9,223,372,036,854,775,807) 
            valueBytes = BitConverter.GetBytes(reading);
            byteCount = 8;
            prefix = (byte)(256 - byteCount);
        }else if(reading >= short.MinValue && reading <= -1){
            // short (-32,768 a -1)
            valueBytes = BitConverter.GetBytes((short)reading);
            byteCount = 2;
            prefix = (byte)(256 - byteCount);
        }else if(reading >= int.MinValue && reading <= (long)short.MinValue -1){
            // int negativo (-2,147,483,648 a -32,769)
            valueBytes = BitConverter.GetBytes((int)reading);
            byteCount = 4;
            prefix = (byte)(256 - byteCount);
        }else{
            // long negativo (-9,223,372,036,854,775,808 a -2,147,483,649)
            valueBytes = BitConverter.GetBytes(reading);
            byteCount = 8;
            prefix = (byte)(256 - byteCount);
        }

        buffer[0] = prefix;
        Array.Copy(valueBytes, 0, buffer, 1, valueBytes.Length);

        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        if(buffer == null || buffer.Length < 2)
            throw new ArgumentException("Invalid Buffer");

        byte prefix = buffer[0];
        byte byteCount;

        bool isSigned = prefix > 128;
        byteCount = isSigned ? (byte)(256 - prefix) : prefix;
        
        if(byteCount != 2 && byteCount != 4 && byteCount != 8)
            return 0;
         if(buffer.Length - 1 < byteCount)
            return 0;
        
        byte[] valueBytes = new byte[byteCount];       
        Array.Copy(buffer, 1, valueBytes, 0, byteCount);
        
        long result;

        if(isSigned){
            switch (byteCount){
                case 2:
                    result = BitConverter.ToInt16(valueBytes, 0);
                    break;
                case 4:
                    result = BitConverter.ToInt32(valueBytes, 0);
                    break;
                case 8:
                    result = BitConverter.ToInt64(valueBytes, 0);
                    break;
                default:
                    return 0;
            }
        }else{
            switch (byteCount){
                case 2:
                    result = BitConverter.ToUInt16(valueBytes, 0);
                    break;
                case 4:
                    result = BitConverter.ToUInt32(valueBytes, 0);
                    break;
                case 8:
                    result = BitConverter.ToInt64(valueBytes, 0);
                    break;
                default:
                    return 0;
            }
        }
        return result;
    }
}
