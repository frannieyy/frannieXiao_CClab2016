
$(function() {
	
		var marketId = []; 
		var allLatlng = []; 
		var allMarkers = []; 
		var marketName = []; 
		var infowindow = null;
		var pos;
		var userCords;
		var tempMarkerHolder = [];
		
		var mapOptions = {
			zoom: 5,
			center: new google.maps.LatLng(37.09024, -100.712891),
			panControl: false,
			panControlOptions: {
				position: google.maps.ControlPosition.BOTTOM_LEFT
			},
			zoomControl: true,
			zoomControlOptions: {
				style: google.maps.ZoomControlStyle.LARGE,
				position: google.maps.ControlPosition.RIGHT_CENTER
			},
			scaleControl: false

		};
	

	infowindow = new google.maps.InfoWindow({
		content: "holding..."
	});
	

	map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);


    $('#chooseZip').submit(function() { 
		

		var userZip = $("#textZip").val();

		
		var accessURL;
		
		if(userZip){
			accessURL = "http://search.ams.usda.gov/farmersmarkets/v1/data.svc/zipSearch?zip=" + userZip;
		} else {
			accessURL = "http://search.ams.usda.gov/farmersmarkets/v1/data.svc/locSearch?lat=" + userCords.latitude + "&lng=" + userCords.longitude;
		}
			


			$.ajax({
				type: "GET",
				contentType: "application/json; charset=utf-8",
				url: accessURL,
				dataType: 'jsonp',
				success: function (data) {

					 $.each(data.results, function (i, val) {
						marketId.push(val.id);
						marketName.push(val.marketname);
					 });
						
					
					var counter = 0;
					$.each(marketId, function (k, v){
						$.ajax({
							type: "GET",
							contentType: "application/json; charset=utf-8",
							url: "http://search.ams.usda.gov/farmersmarkets/v1/data.svc/mktDetail?id=" + v,
							dataType: 'jsonp',
							success: function (data) {

							for (var key in data) {

								var results = data[key];
								
							
								var googleLink = results['GoogleLink'];
								var latLong = decodeURIComponent(googleLink.substring(googleLink.indexOf("=")+1, googleLink.lastIndexOf("(")));
								
								var split = latLong.split(',');
				
								var latitude = parseFloat(split[0]);
								var longitude = parseFloat(split[1]);

								myLatlng = new google.maps.LatLng(latitude,longitude);
						  
								allMarkers = new google.maps.Marker({
									position: myLatlng,
									map: map,
									title: marketName[counter],
									html: 
											'<div class="markerPop">' +
											'<h1>' + marketName[counter].substring(4) + '</h1>' + 
											'<h3>' + results['Address'] + '</h3>' +
											'<p>' + results['Products'].split(';') + '</p>' +
											'<p>' + results['Schedule'] + '</p>' +
											'</div>'
								});

								allLatlng.push(myLatlng);
								
								tempMarkerHolder.push(allMarkers);
								
								counter++;
							};
								
								google.maps.event.addListener(allMarkers, 'click', function () {
									infowindow.setContent(this.html);
									infowindow.open(map, this);
								});
								
								
								var bounds = new google.maps.LatLngBounds ();
								for (var i = 0, LtLgLen = allLatlng.length; i < LtLgLen; i++) {
								  bounds.extend (allLatlng[i]);
								}
								map.fitBounds (bounds);
								
										
							}
						});
					}); 
				}
			});

        return false; 
    });
});

