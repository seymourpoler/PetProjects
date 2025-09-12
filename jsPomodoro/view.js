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

    self.start = function(){
        onStartClicked();
    }

    self.stop = function(){
        onStopClicked();
    }

    self.showTime = function(time){
        // throw new Error('not implemented');
    }
}

if(module && module.exports){
    module.exports	= View;
}