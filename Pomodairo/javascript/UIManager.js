function UIManager(){
    /* CONTAINER */
    this.showContainer = function(){
        document.getElementById('container').style.display='block';
    }
    this.hideContainer = function(){
        document.getElementById('container').style.display='none';
    }
	/* TIME */  
    this.setLabelTimer = function(minutes, seconds){
    	var sec = seconds;
    	if(seconds < 10){
    		sec = '0'  + seconds;
    	}
		document.getElementById('lblTimer').innerHTML = minutes + ':' + sec;
    }

    /* TASKS */
    this.getNameNewtask = function(){
    	return document.getElementById('txtNameNewTask').value;
    }
    this.cleanControlNameNewTask = function(){
    	document.getElementById('txtNameNewTask').value = '';	
    }
    this.showControlTasks = function(){
    	if(document.getElementById('divTasks').style.display == 'none'){
    		document.getElementById('divTasks').style.display='block';
    	}
    	else{
    		document.getElementById('divTasks').style.display='none';
    	}
    }
    this.showControlNewTask = function(){
    	document.getElementById('divNewTask').style.display='block';
    }
    this.hideControlNewTask = function(){
    	document.getElementById('divNewTask').style.display='none';
    }
    this.printNewTask = function(newTask){
    	var cmbTasks = document.getElementById('cmbTasks');
    	cmbTasks.options[cmbTasks.options.length] = new Option(newTask.name, newTask.guid);
    }
    this.removeSelectedTask = function(){
    	var cmbTasks = document.getElementById('cmbTasks');
    	var position = cmbTasks.options.selectedIndex;
    	if(position > -1){
        	cmbTasks.remove(position);
    	}
    }
    this.upSelectedTask = function(){
    	var cmbTasks = document.getElementById('cmbTasks');
    	if(cmbTasks.options.selectedIndex <= 0){return;}
    	moveOptions(cmbTasks, -1);
    }
    this.downSelectedTask = function(){
    	var cmbTasks = document.getElementById('cmbTasks');
    	if(cmbTasks.options.selectedIndex >= cmbTasks.options.length){return;}
    	moveOptions(cmbTasks, +1);
    	
    }
    function moveOptions(controlSelect, upDown){
    	var position = cmbTasks.options.selectedIndex + upDown;
    	var text = cmbTasks[position].text;
    	var value = cmbTasks[position].value;
    	
    	cmbTasks[position].text = cmbTasks[cmbTasks.options.selectedIndex].text;
    	cmbTasks[position].value = cmbTasks[cmbTasks.options.selectedIndex].value;

    	cmbTasks[cmbTasks.options.selectedIndex].value = value;
    	cmbTasks[cmbTasks.options.selectedIndex].text = text;

    	cmbTasks.options.selectedIndex = position;
    }

    /* PROGRESS BAR */
    this.minimize = function(){
        document.getElementById('divProgressBar').style.display='block';
        //document.getElementById('divBtnExpand').style.display='block';
        this.hideContainer();
        this.hideControlNewTask();
        this.hideControlAbout();
        this.hideControlConfiguration();
    }
    this.expand = function(){
        this.showContainer();
        document.getElementById('divProgressBar').style.display='none';
        //document.getElementById('divBtnExpand').style.display='none';
    }
    this.updateProgressBar = function(configTime, time){
        var totalTime = configTime.seconds + (configTime.minutes * 60);
        var timeNow = time.seconds + (time.minutes * 60); 
        document.getElementById('divBar').style.width=(timeNow*100)/totalTime+'%';  
    }

    /* ABOUT */
    this.showControlAbout = function(){
    	document.getElementById('divAbout').style.display='block';
    }
    this.hideControlAbout = function(){
    	document.getElementById('divAbout').style.display='none';
    }

    /* CONFIGURATION */
    this.showControlConfiguration = function(time){
    	document.getElementById('txtNumberOfMinutes').value = time.minutes;
    	document.getElementById('txtNumberOfSeconds').value = time.seconds;

    	document.getElementById('divConfiguration').style.display='block';
    }
    this.hideControlConfiguration = function(){
    	document.getElementById('divConfiguration').style.display='none';
    }
    this.getNumberOfMinutesFromConfiguration = function(){
    	return document.getElementById('txtNumberOfMinutes').value;
    }
    this.getNumberOfSecondsFromConfiguration = function(){
    	return document.getElementById('txtNumberOfSeconds').value;
    }
    this.getTimeFromConfiguration = function(){
    	var time = new Time();
    	time.minutes = document.getElementById('txtNumberOfMinutes').value;
    	time.seconds = 	document.getElementById('txtNumberOfSeconds').value;

    	return time;
    }
}
