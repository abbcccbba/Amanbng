using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts.DataProvider;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace AppRuntime
{
    public sealed class Rand
    {
        /*
         该类提供随机数
         使用演示：
        new Rand(1,8).GetValue() // 返回1到8大小的随机数

         */
        private int Return;
        public Rand(int minValue,int maxValue) 
        {
            IBuffer buffer = CryptographicBuffer.GenerateRandom(sizeof(int));
            byte[] randomBytes = buffer.ToArray();
            int randomNumber = BitConverter.ToInt32(randomBytes, 0);
            int result = (int)Math.Floor((double)(randomNumber % (maxValue - minValue + 1) + minValue));
            Return = result;
        }  
        public int GetValue() { return Return; }
    }
}
