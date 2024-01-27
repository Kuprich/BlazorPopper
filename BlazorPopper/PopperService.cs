using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPopper;
public class PopperService(IJSRuntime jSRuntime)
{
    private readonly IJSRuntime _jSRuntime = jSRuntime;

    public async Task CreatePopperAsync(ElementReference reference, ElementReference popper, Options? options = null)
    {
        await _jSRuntime.InvokeVoidAsync("PopperWrapper.createPopper", reference, popper, options);
    }
}
