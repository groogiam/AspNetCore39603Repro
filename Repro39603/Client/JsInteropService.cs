using Microsoft.JSInterop;

namespace Repro39603.Client
{
    public class JsInteropService
    {
        public JsInteropService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        #region Properties

        private readonly IJSRuntime _jsRuntime;

        #endregion

        public ValueTask DownloadFromStream(string fileName, Stream data)
        {
            //using causes exception
            using var streamRef = new DotNetStreamReference(data);
            return _jsRuntime.InvokeVoidAsync("downloadFileFromStream", fileName ?? string.Empty, streamRef);
        }
    }
}
