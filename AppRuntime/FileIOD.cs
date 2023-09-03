using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using AppClasses;
using Windows.Foundation;

namespace AppRuntime
{
    /*
     FileIOD类是一个能够简单的实现文件读写的类
    演示：
    写入： new FileIOD("文件名.txt").xie("这里可以写需要写的内容");
    读取： string 读取的结果 = await new FileIOD("文件名").du();
     */

    public sealed class FileIOD
    {
             
        private string fileName;
        public FileIOD(string FileName)
        {
            fileName = FileName;
        }
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
