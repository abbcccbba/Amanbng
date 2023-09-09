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
    /// <summary>
    /// 提供了一个简单的随机数获取方法 参考：new Rand(1,5).GetValue()
    /// </summary>
    public sealed class Rand
    {
        private uint Return;
        /// <summary>
        /// 定义随机数范围
        /// </summary>
        /// <param name="minValue">随机数最小值</param>
        /// <param name="maxValue">随机数最大值</param>
        public Rand(int minValue,int maxValue) 
        {
            Return = (CryptographicBuffer.GenerateRandomNumber() % (uint)(maxValue+1)) + (uint)minValue;
        }  
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <returns>返回随机数</returns>
        public uint GetValue() { return Return; }
    }
}
