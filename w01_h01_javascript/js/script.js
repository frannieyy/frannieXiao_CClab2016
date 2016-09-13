var oDiv = document.getElementById("div1");
    oDiv.onmousedown = function(e){
        var e = e || window.event;

        var diffX = e.clientX - oDiv.offsetLeft;
        var diffY = e.clientY - oDiv.offsetTop;

        document.onmousemove = function(e){ 
            var e = e||window.event;
            oDiv.style.left = e.clientX - diffX + 'px';
            oDiv.style.top = e.clientY -diffY + 'px';
        };
        document.onmouseup = function(){
            document.onmousemove = null;
            document.onmouseup = null;
        }
    }