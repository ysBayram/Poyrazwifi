function initMap(id, config) {
	
	if ($('#'+id).length>0) {
    // Do something
		var myLatlng = new google.maps.LatLng(config.lat, config.lng);
		var myOptions = {
			zoom: config.zoom,
			disableDefaultUI: config.disableDefaultUI,
			center: myLatlng,
			mapTypeId: config.type,
			zoomControlOptions: {
				style: google.maps.ZoomControlStyle.DEFAULT
			}
		};
		var map = new google.maps.Map(document.getElementById(id), myOptions);
		
		for (var i in config.markers) {
			var marker = new google.maps.Marker({
				position: new google.maps.LatLng(config.markers[i].lat, config.markers[i].lng),
				map: map,
				title: config.markers[i].title
			});
		}
		
	}
}