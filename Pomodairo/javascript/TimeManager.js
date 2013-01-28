function Time(){
  this.minutes = 50;
  this.seconds = 59;
}

function TimeManager(){
	this.listeners = [];
	this.time = new Time();
	this.interval;

	this.addListener = function(type, listener){
		if(typeof this.listeners[type] == "undefined"){
			this.listeners[type] = [];
		}
		this.listeners[type].push(listener);
	}
	this.tick = function(event){

		if(!event.type){
			throw new Error("Event Object is missing type property.");
		}
		if(!event.target){
			event.target = this;
		}
		var listens = this.listeners[event.type];
		for(var cont = 0; cont< listens.length; cont++){
			listens[cont].call(this, event);
		}
	}
	this.start = function(){
		var instant = this;
		this.interval = setInterval(function(){
	        instant.updateTime();
	        instant.tick({type: "tick", time: instant.time})
	      },1000);
	}
	this.updateTime = function(){
	  if(this.time.seconds == 0){
	    this.time.seconds = 59;
	    this.time.minutes = this.time.minutes - 1;
	  }
	  else{
	    this.time.seconds = this.time.seconds - 1;
	  }
	}
	this.pause = function(){
		clearInterval(this.interval);
	}
	this.stop = function(time){
		this.pause();
    	this.time = time;
	}
}
