
//Initialise map variables
var map;
var marker = null;

//Initialises the Google Map,
//includes setting a function to be called when the map is clicked
function initialize() {
	var myLatlng = new google.maps.LatLng(-27.478125, 153.029228); //Default map centre (P Block)

	var mapOptions = {
		zoom: 18,
		center: myLatlng,
		disableDefaultUI: false,
		mapTypeId: google.maps.MapTypeId.ROADMAP
	};

	map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions); //Create the map object

	//Create a marker at the current location
	marker = new google.maps.Marker({
		position: myLatlng,
		map: map,
		title: 'Your Location'
	});
}

//See Google Maps API...
//Display the map in the DOM
google.maps.event.addDomListener(window, 'load', initialize);