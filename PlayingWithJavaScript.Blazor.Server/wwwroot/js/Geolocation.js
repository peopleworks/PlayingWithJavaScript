// HACK: Geolocation JavaScript Function | Source:  https://www.w3schools.com/html/html5_geolocation.asp

var stringPosition = "";

function getLocation() {

    const options = {
        enableHighAccuracy: true,
        timeout: 5000,
        maximumAge: 0
    };

    if (navigator.geolocation) {
        var coords = navigator.geolocation.getCurrentPosition(showPosition, error, options);

        return stringPosition;
    } else {
        consol.log("Geolocation is not supported by this browser.");
        return "";
    }
}

function showPosition(position) {
    stringPosition = position.coords.latitude.toString() + "|" + position.coords.longitude.toString();
}

function error(err) {
    console.warn(`ERROR(${err.code}): ${err.message}`);
}