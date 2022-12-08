window.getDimensions = function () {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
};

window.clipboardCopy = {
    copyText: function (text) {
        navigator.clipboard.writeText(text)
            .catch(function (error) {
                alert(error);
            });
    }
};

function scrollWindowToBottom() {
    var height = document.body.scrollHeight;
    window.scrollTo(0, height);
}