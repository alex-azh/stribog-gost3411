using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stribog_Crypto
{
    class Program
    {
        static string ByteToStringByte(string s)
        {
            string resp = "{";
            int i = 0;
            byte[] test = { };
            while (i < s.Length)
            {
                resp += "0x" + s[i] + s[i + 1] + ",";
                Console.WriteLine(Convert.ToInt32(resp));
                i += 2;
                s.Substring(i);
            }
            resp = resp.Substring(0, resp.Length - 1);
            resp += "}";
            return resp;
        }
        static void Main(string[] args)
        {
            // Инициализация объектов, в которых будет хеширование
            StriBOG Stri256 = new StriBOG(256);
            StriBOG Stri512 = new StriBOG(512);

            // Преобразование сообщения в виде цифр в байты
            //ByteToStringByte("323130393837363534333231303938373635343332313039383736353433323130393837363534333231303938373635343332313039383736353433323130");
            byte[] m1 = { 0x32, 0x31, 0x30, 0x39,
                0x38, 0x37, 0x36, 0x35, 0x34, 0x33, 0x32, 0x31, 0x30, 0x39, 0x38, 0x37, 0x36, 0x35, 0x34, 0x33,
                0x32, 0x31, 0x30, 0x39, 0x38, 0x37, 0x36, 0x35, 0x34, 0x33, 0x32, 0x31, 0x30, 0x39, 0x38, 0x37, 
                0x36, 0x35, 0x34, 0x33, 0x32, 0x31, 0x30, 0x39, 0x38, 0x37, 0x36, 0x35, 0x34, 0x33, 0x32, 0x31, 
                0x30, 0x39, 0x38, 0x37, 0x36, 0x35, 0x34, 0x33, 0x32, 0x31, 0x30 };

            // Хеширование по 256 и 512 байт соответственно
            byte[] res = Stri256.HashProgram(m1);
            byte[] res2 = Stri512.HashProgram(m1);
            string len256 = BitConverter.ToString(res);
            string len512 = BitConverter.ToString(res2);
            Console.WriteLine($"256 bytes:\n{len256}");
            Console.WriteLine($"512 bytes:\n{len512}");
            Console.ReadKey();
        }
    }
}
