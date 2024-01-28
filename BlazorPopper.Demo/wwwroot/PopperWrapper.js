window.PopperWrapper = {
    createPopper: (reference, popper, options, objRef) => {
        options.onFirstUpdate = (state) => {
            const stateCopy = {
                placement: state.placement
            }
            objRef.invokeMethodAsync('CallOnFirstUpdate', stateCopy)
        };

        if (options) {
            Popper.createPopper(reference, popper, options);
            return;
        }
        Popper.createPopper(reference, popper);
    }
}