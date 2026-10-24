chrome.extension.sendMessage({}, function(response) {
	var clips = [];
	var readyStateCheckInterval = setInterval(function() {
	if (document.readyState === "complete") {
		clearInterval(readyStateCheckInterval);
		document.addEventListener("click", function(e){
			var shift = e.shiftKey;
			var ctrl = e.ctrlKey;
			switch(true) {
				case shift && ctrl:
				console.log(JSON.stringify(clips));
				break;
				case shift:
				clips.push('Q:' + e.target.innerHTML);
				e.target.style.color = "red";
				break;
				case ctrl:
				clips.push('A:' + e.target.innerHTML);
				e.target.style.color = "green";
			}
		});
	}
	}, 10);
});