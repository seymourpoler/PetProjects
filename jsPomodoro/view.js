function View(){
    let self = this;

    let onStartClicked;
    let onStopClicked;

    self.subscribeToOnStartClicked = function(handler){
        onStartClicked = handler;
    }

    self.subscribeToOnStopClicked = function(handler){
        onStopClicked = handler;
    }

    self.subscribeToOnResetClicked = function(handler){
        if(!document.getElementById("reset")){
            return;
        }
        document.getElementById("reset").addEventListener('click', function(){
            handler();
        });
    }

    self.start = function(){
        onStartClicked();
    }

    self.stop = function(){
        onStopClicked();
    }

    self.showTime = function(time){
        if(!document.getElementById('minutes') || !document.getElementById('seconds')){
            return;
        }
        document.getElementById('minutes').innerHTML = time.minutes;
        document.getElementById('seconds').innerHTML = time.seconds.toString().padStart(2, '0');
    }
}

if(module && module.exports){
    module.exports	= View;
}