using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using AppClasses;
using Windows.Foundation;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;

namespace AppRuntime
{
    /// <summary>
    /// 提供了一个方便的文件读写的方法
    /// </summary>
    public sealed class FileIOD
    {
             
        private string fileName;

        /// <param name="FileName">需要读写的文件路径</param>
        public FileIOD(string FileName)
        {
            fileName = FileName;
        }
        /// <summary>
        /// 模式为写文件
        /// </summary>
        /// <param name="Content">写入文件的string变量</param>
        public async void xie(string Content)
        {
            try
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile configFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(configFile, Content);
            }
            catch (Exception ex)
            {
                new MessageBox("文件流错误").e("代码：" + ex.Message);
            }
        }
        /// <summary>
        /// 模式为读文件
        /// </summary>
        /// <returns>返回读取到的文件string值</returns>
        public IAsyncOperation<string> du()
        {
            return duAsync().AsAsyncOperation();
        }

        private async Task<string> duAsync()
        {
            try
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile configFile = await localFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(configFile);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
