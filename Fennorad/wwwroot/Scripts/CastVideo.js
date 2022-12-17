
var CastPlayer = function () {
    //...
    /* Cast player variables */
    /** @type {cast.framework.RemotePlayer} */
    this.remotePlayer = null;
    /** @type {cast.framework.RemotePlayerController} */
    this.remotePlayerController = null;
    //...
};

let castPlayer = new CastPlayer();
window['__onGCastApiAvailable'] = function (isAvailable) {
    if (isAvailable) {
        castPlayer.initializeCastPlayer();
    }
};

CastPlayer.prototype.initializeCastPlayer = function () {

    var options = {};

    // Set the receiver application ID to your own (created in
    // the Google Cast Developer Console), or optionally
    // use the chrome.cast.media.DEFAULT_MEDIA_RECEIVER_APP_ID
    options.receiverApplicationId = chrome.cast.media.DEFAULT_MEDIA_RECEIVER_APP_ID;

    // Auto join policy can be one of the following three:
    // ORIGIN_SCOPED - Auto connect from same appId and page origin
    // TAB_AND_ORIGIN_SCOPED - Auto connect from same appId, page origin, and tab
    // PAGE_SCOPED - No auto connect
    options.autoJoinPolicy = chrome.cast.AutoJoinPolicy.ORIGIN_SCOPED;
    options.androidReceiverCompatible = true;

    cast.framework.CastContext.getInstance().setOptions(options);
    let credentialsData = new chrome.cast.CredentialsData("{\"userId\": \"fennorad\"}");
    cast.framework.CastContext.getInstance().setLaunchCredentialsData(credentialsData);

    this.remotePlayer = new cast.framework.RemotePlayer();
    this.remotePlayerController = new cast.framework.RemotePlayerController(this.remotePlayer);
    this.remotePlayerController.addEventListener(
        cast.framework.RemotePlayerEventType.IS_CONNECTED_CHANGED, async function () {
            if (!castPlayer.remotePlayer.isConnected) {
                console.log('RemotePlayerController: Player disconnected');
                // Update local player to disconnected state
            }
            // POTENTIALLY LOAD VIDEO HERE
            var videoId = await DotNet.invokeMethodAsync("Fennorad", "ChosenVideo");
            var mediaInfo = new chrome.cast.media.MediaInfo('https://www.youtube.com/'.concat(videoId), 'video/mp4');
            var request = new chrome.cast.media.LoadRequest(mediaInfo);
            castSession.loadMedia(request).then(
                function () { console.log('Load succeed'); },
                function (errorCode) {
                    console.log('Error code: ' + errorCode);
                }
            ).bind(this);
    });
};


CastPlayer.prototype.setupRemotePlayer = function () {


    // Setup remote player volume right on setup
    // The remote player may have had a volume set from previous playback
    if (this.remotePlayer.isMuted) {
        this.playerHandler.mute();
    }
    
    this.hideFullscreenButton();
    this.remotePlayerController.addEventListener(
        cast.framework.RemotePlayerEventType.IS_PAUSED_CHANGED,
        function () {
            if (this.remotePlayer.isPaused) {
                this.playerHandler.pause();
            } else {
                this.playerHandler.play();
            }
        }.bind(this)
    );

    this.remotePlayerController.addEventListener(
        cast.framework.RemotePlayerEventType.IS_MUTED_CHANGED,
        function () {
            if (this.remotePlayer.isMuted) {
                this.playerHandler.mute();
            } else {
                this.playerHandler.unMute();
            }
        }.bind(this)
    );

    this.remotePlayerController.addEventListener(
        cast.framework.RemotePlayerEventType.VOLUME_LEVEL_CHANGED,
        function () {
            var newVolume = this.remotePlayer.volumeLevel * FULL_VOLUME_HEIGHT;
            var p = document.getElementById('audio_bg_level');
            p.style.height = newVolume + 'px';
            p.style.marginTop = -newVolume + 'px';
        }.bind(this)
    );

};