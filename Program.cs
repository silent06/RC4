using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace KvHashHandler
{
    class Program
    {


        static void Main(string[] args)
        {

            byte[] xzpFile = File.ReadAllBytes("Images.xzp");
            byte[] Key = { 0x2D, 0x3C, 0x6A, 0xC8, 0x51, 0x74, 0x51, 0x71, 0x26, 0x68, 0x6D, 0xAD, 0x64, 0x37, 0x48, 0xA6 };//xzp Key
            Console.WriteLine("Writing XZP for backup....");
            File.WriteAllBytes("Decrypted_Images.xxp", xzpFile);
            Console.WriteLine("Encrypting XZP....");
            HashHandler.Utils.RC4(ref xzpFile, Key);
            Console.WriteLine("Writing XZP....");
            File.WriteAllBytes("Encrypted_Images.xxp", xzpFile);
            Console.WriteLine("Done!");
            //Console.ReadKey();
        }
    }
}
