using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPopper;
public class PopperService(IJSRuntime jSRuntime) : IDisposable
{
    private readonly IJSRuntime _jSRuntime = jSRuntime;
    private DotNetObjectReference<Options>? _objRef;

    public async Task CreatePopperAsync(ElementReference reference, ElementReference popper, Options? options = null)
    {
        if (options != null){
            _objRef = DotNetObjectReference.Create(options);
        }

        await _jSRuntime.InvokeVoidAsync("PopperWrapper.createPopper", reference, popper, options, _objRef);
    }

    public void Dispose()
    {
        _objRef?.Dispose();
    }
}
