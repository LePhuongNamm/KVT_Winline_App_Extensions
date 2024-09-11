using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Source.WebUI.Utils
{
    public static class JSRuntimeExtensions
    {
        public static async Task<bool> Confirm(this IJSRuntime jsRuntime,string message)
        {
            return await jsRuntime.InvokeAsync<bool>("DoSomethingConfirm", message);
        }

        public static async Task Aleft(this IJSRuntime jsRuntime, string message)
        {
            try
            {
                await jsRuntime.InvokeVoidAsync("DoSomethingAleft", message);
            }
            catch { }
        }

        public static async Task Loading(this IJSRuntime jsRuntime, bool isShow)
        {
            try
            {
                await jsRuntime.InvokeVoidAsync("DoSomethingLoading", isShow);
            }
            catch { }
        }

        public static async Task Notification(this IJSRuntime jsRuntime, string message)
        {
            try
            {
                await jsRuntime.InvokeVoidAsync("DoSomethingNotification", message);
            }
            catch { }
        }

        public static async Task DownloadTemplate(this IJSRuntime jsRuntime, string fileName, DotNetStreamReference streamRef)
        {
            try
            {
                await jsRuntime.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
            }
            catch { }
        }
    }
}
