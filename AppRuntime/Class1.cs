using AppClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Security.Credentials;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;

namespace AppRuntime
{
    public sealed class Idt
    {
        public static IAsyncOperation<bool> WindowsHello(string HelloName)
        {
            return AsyncInfo.Run(async (cancellationToken) =>
            {
                try
                {
                    if (await KeyCredentialManager.IsSupportedAsync()) // 检查用户的设备是否支持 Windows Hello
                    {
                        // 请求用户输入PIN码
                        KeyCredentialRetrievalResult keyCredentialRetrievalResult = await KeyCredentialManager.RequestCreateAsync(HelloName,
                            KeyCredentialCreationOption.ReplaceExisting);

                        if (keyCredentialRetrievalResult.Status == KeyCredentialStatus.Success)
                        {
                            // 验证PIN码
                            KeyCredential keyCredential = keyCredentialRetrievalResult.Credential;
                            IBuffer message = CryptographicBuffer.GenerateRandom(32); // 生成一个随机的消息用于签名
                            KeyCredentialOperationResult keyCredentialOperationResult = await keyCredential.RequestSignAsync(message);

                            if (keyCredentialOperationResult.Status == KeyCredentialStatus.Success)
                            {
                                // PIN码验证成功
                                return true;
                            }
                            else
                            {
                                // PIN码验证失败
                                return false;
                            }
                        }
                        else
                        {
                            // 创建密钥凭据失败
                            new MessageBox("错误").e("无法创建密钥凭据");
                            return false;
                        }
                    }
                    else
                    {
                        new MessageBox("错误").e("您的设备不支持 Windows Hello");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    new MessageBox("无法验证身份").e("代码：" + ex.Message);
                    return false;
                }
            });
        }
    }

}
