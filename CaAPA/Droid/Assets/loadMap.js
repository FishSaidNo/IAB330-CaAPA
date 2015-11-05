
//Initialise map variables
var map;
var marker = null;

var startActive = false; //true if user selecting start location
var endActive = false; //true if user selecting end location
// var coordStart = {lat: -27.473395, lng: 153.028936};
// var coordEnd = {lat: -27.47044, lng: 153.025968};
var coordStart;
var coordEnd;

//Initialize markers for directions
var markerStart = null;
var markerEnd = null;

//Create labels to be displayed with the temp markers
var startMarkerLabel = new google.maps.InfoWindow({
    content: 'Your starting point. Now set the destination.'
});
var endMarkerLabel = new google.maps.InfoWindow({
    content: 'Your destination. Now set the starting point.'
});



//Initialises the Google Map,
//includes setting a function to be called when the map is clicked
function initialize() {
	var myLatlng = new google.maps.LatLng(-27.478125, 153.029228); //Default map centre (P Block)

	var mapOptions = {
		zoom: 16,
		center: myLatlng,
		disableDefaultUI: false,
		mapTypeId: google.maps.MapTypeId.ROADMAP
	};

	map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions); //Create the map object
	
	//Create label for the marker
	locationMarkerLabel = new google.maps.InfoWindow({
		content: 'Current Location'
	});
	//Create a marker at the current location
	marker = new google.maps.Marker({
		position: myLatlng,
		map: map,
		title: 'Your Location'
	});
	locationMarkerLabel.open(map, marker);
	
	//Initialize directionsDisplay variable, to be used by the direction service.
	var directionsDisplay = new google.maps.DirectionsRenderer({
		map: map
	});

	//Initialize the request containing the destination, origin and travel mode; to be used by the direction service.
	var directionRequest = {
		destination: coordEnd,
		origin: coordStart,
		travelMode: google.maps.TravelMode.WALKING
	};	
	
	//Initialize the Directions Service.
	var directionsService = new google.maps.DirectionsService();
	
	
	//Add event listener to the map (for onclick event)
	google.maps.event.addListener(map, 'click', function(event) {
		
		if (startActive || endActive) {
			
			if (startActive) {
				coordStart = event.latLng; //Update location with user's selection'
				startActive = false; //Deactivate button
				$('#btnStart').removeClass('active btn-success').addClass('btn-warning'); //Visually deactivate button	
				
				//Create temp marker if both locations have not been set
				if (!coordEnd) {
					//Delete temp marker
					if (markerStart) { markerStart.setMap(null); }
					if (markerEnd) { markerEnd.setMap(null); }
					markerStart = new google.maps.Marker({
						title: 'Starting Location',
						map: map,
						position: coordStart,
						label: 'A'
					});	
					startMarkerLabel.open(map, markerStart);
				}
			}
			if (endActive) {
				coordEnd = event.latLng;
				endActive = false;
				$('#btnEnd').removeClass('active btn-success').addClass('btn-warning');
				
				//Create temp marker if both locations have not been set
				if (!coordStart) {
					//Delete temp markers
					if (markerStart) { markerStart.setMap(null); }
					if (markerEnd) { markerEnd.setMap(null); }
					markerStart = new google.maps.Marker({
						title: 'Starting Location',
						map: map,
						position: coordEnd,
						label: 'B'
					});	
					endMarkerLabel.open(map, markerStart);
				}				
			}
			
			if (coordStart && coordEnd) {
				//Delete temp marker
				if (markerStart) { markerStart.setMap(null); }
				if (markerEnd) { markerEnd.setMap(null); }
				
				//Update direction request
				directionRequest = {
					destination: coordEnd,
					origin: coordStart,
					travelMode: google.maps.TravelMode.WALKING
				};	
				//Pass the directions request to the directions service.
				directionsService.route(directionRequest, function(response, status) {
					if (status == google.maps.DirectionsStatus.OK) {
						// Display the route on the map.
						directionsDisplay.setDirections(response);
					}
				});
			}		
		}	
		
	});	//End onclick function  
} //End function

//See Google Maps API...
//Display the map in the DOM
google.maps.event.addDomListener(window, 'load', initialize);