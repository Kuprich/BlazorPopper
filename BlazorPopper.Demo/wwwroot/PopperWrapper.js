window.PopperWrapper = {
    createPopper: (reference, popper, options) => {
        if (options) {
            Popper.createPopper(reference, popper, options);
            return;
        }
        Popper.createPopper(reference, popper);
    }
}