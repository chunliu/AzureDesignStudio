class DotnetCallHelper {
    static callerInstance;
    static methodName;
    static SetCallHelper(caller, method) {
        DotnetCallHelper.callerInstance = caller;
        DotnetCallHelper.methodName = method;
    }
}

window.dotnetCallHelper = DotnetCallHelper;

window.registerForUpdateAvailableNotification = (caller, methodName) => {
    window.dotnetCallHelper.SetCallHelper(caller, methodName);
    window.registerServiceWorker();
};

window.registerServiceWorker = () => {
    if (!('serviceWorker' in navigator)) {
        const errorMessage = `This browser doesn't support service workers`;
        console.error(errorMessage);
    }
    else {
        navigator.serviceWorker.register('/service-worker.js')
            .then(registration => {
                console.info(`Service worker registration successful (scope: ${registration.scope})`);

                setInterval(() => {
                    registration.update();
                }, 1000 * 60 * 60); // Check every 1 hour.

                registration.onupdatefound = () => {
                    window.dotnetCallHelper.callerInstance.invokeMethodAsync(window.dotnetCallHelper.methodName).then();
                };
            })
            .catch(error => {
                console.error('Service worker registration failed with error:', error);
            });
    }
}