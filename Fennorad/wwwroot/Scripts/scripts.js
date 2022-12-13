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

function getPosition() {
    // Simple wrapper
    return new Promise((res, rej) => {
        const options = {
            enableHighAccuracy: true,
            timeout: 5000,
            maximumAge: 0
        };
        navigator.geolocation.getCurrentPosition(res, rej, options);
    });
}

async function getGpsLocation() {
    var position = await getPosition();  // wait for getPosition to complete
    return {
        lat: position.coords.latitude,
        long: position.coords.longitude
    }
}

function resetSelect() {
    document.getElementById('downloadOptions').selectedIndex = 0;
}