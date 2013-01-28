function Configuration(){
    this.time = new Time();

    this.setMinutes = function(numberOfMinutes){
      if(numberOfMinutes < 0){
        this.time.minutes =  1;
      }
      else{
        this.time.minutes = numberOfMinutes;
      }
    }
    this.setSeconds = function(numberOfSeconds){
      if(numberOfSeconds < 0){
        this.time.seconds = 59;  
      }
      else{
        this.time.seconds = numberOfSeconds;
      }
    }
    this.getMinutes = function(){
      return this.time.minutes;
    }
    this.getSeconds = function(){
    	return this.time.seconds;
    }
    this.getTime = function(){
      return {
        minutes : this.time.minutes,
        seconds : this.time.seconds
      };
    }
    this.setTime = function(time){
      this.setMinutes(time.minutes);
      this.setSeconds(time.seconds);
    }
  }