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
