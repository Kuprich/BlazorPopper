using Microsoft.JSInterop;

namespace BlazorPopper;

public class Instance(IJSObjectReference jsInstance,
    DotNetObjectReference<Options> objRef,
    IJSObjectReference popperWrapper) : IDisposable
{
    private readonly IJSObjectReference _jsInstance = jsInstance;
    private readonly DotNetObjectReference<Options> _objRef = objRef;
    private readonly IJSObjectReference _popperWrapper = popperWrapper;

    public async Task ForceUpdate() => await _jsInstance.InvokeVoidAsync("forceUpdate");
    public async Task Destroy() => await _jsInstance.InvokeVoidAsync("destroy");

    public async Task<State> GetStateAsync() => await _popperWrapper.InvokeAsync<State>("getStateOfInstance", _jsInstance);

    public async Task<State> Update() => await _popperWrapper.InvokeAsync<State>("updateOnInstance", _jsInstance);

    public async Task<State> SetOptions(Options options) => await _popperWrapper.InvokeAsync<State>("setOptionsOnInstance", _jsInstance, options, _objRef);

    public void Dispose()
    {
        _objRef?.Dispose();
    }


}