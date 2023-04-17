using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace HashHandler
{

    class Utils
    {

        public static void RC4(ref byte[] Data, byte[] Key)
        {
            byte[] array = new byte[256];
            byte[] array2 = new byte[256];
            int i;
            for (i = 0; i < 256; i++)
            {
                array[i] = (byte)i;
                array2[i] = Key[i % Key.GetLength(0)];
            }
            int num = 0;
            for (i = 0; i < 256; i++)
            {
                num = (num + (int)array[i] + (int)array2[i]) % 256;
                byte b = array[i];
                array[i] = array[num];
                array[num] = b;
            }
            num = (i = 0);
            for (int j = 0; j < Data.GetLength(0); j++)
            {
                i = (i + 1) % 256;
                num = (num + (int)array[i]) % 256;
                byte b = array[i];
                array[i] = array[num];
                array[num] = b;
                int num2 = (int)(array[i] + array[num]) % 256;
                Data[j] ^= array[num2];
            }
        }
    }
}
