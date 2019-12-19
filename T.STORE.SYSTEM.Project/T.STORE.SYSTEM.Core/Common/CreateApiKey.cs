using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.Core.Common
{
    public static class CreateApiKey
    {
        /// <summary>
        /// 获取随机码
        /// </summary>
        /// <param name="count">位数</param>
        /// <returns></returns>
        public static string GetRandomCode(int count)
        {
            string[] CharArray = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string randomCode = "";
            int temp = -1;
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                if (temp != -1)
                {
                    random = new Random(i * temp * (int)DateTime.Now.Ticks);
                }
                int t = random.Next(CharArray.Length);
                temp = t;
                randomCode += CharArray[temp];
            }
            return randomCode;
        }
    }
}
