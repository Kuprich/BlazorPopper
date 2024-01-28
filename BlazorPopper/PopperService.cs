using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPopper;
public class PopperService(IJSRuntime jSRuntime) : IDisposable
{
    private readonly IJSRuntime _jSRuntime = jSRuntime;
    private DotNetObjectReference<Options>? _objRef;

    public async Task<Instance> CreatePopperAsync(ElementReference reference, ElementReference popper, Options? options = null)
    {
        options ??= new Options();
        _objRef = DotNetObjectReference.Create(options);
        var popperWrapper = await _jSRuntime.InvokeAsync<IJSObjectReference>("import", "./PopperWrapper.js");
        var jsInstance = await popperWrapper.InvokeAsync<IJSObjectReference>("createPopper", reference, popper, options, _objRef);
        return new Instance(jsInstance, _objRef, popperWrapper);
    }

    public void Dispose() => _objRef?.Dispose();
}
