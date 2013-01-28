function PomodoroManager(config, taskHandler, uiHandler, soundHandler, timeHandler){
    this.time = new Time();
    this.configuration = config;
    this.interval;
    this.taskManager = taskHandler;
    this.actualTask = null;
    this.uiManager = uiHandler;
    this.soundManager = soundHandler;
    this.timeManager = timeHandler;
    
    /* TIMER */
    this.play = function(){
      this.time = getTimeFromConfiguration();
      this.timeManager.time = this.time;
      uiManager.setLabelTimer(this.time.minutes, this.time.seconds);
      this.timeManager.start();
    }

    var instant  = this;
    this.manageTime = function(event){
      if(event.type == "tick"){
        instant.uiManager.setLabelTimer(event.time.minutes, event.time.seconds);
        if(event.time.seconds <= 0 && event.time.minutes <= 0){
          instant.playAlarm();
          instant.timeManager.pause();
        }
      }
    }
    function getTimeFromConfiguration(){
      var time = this.configuration.getTime();

      if(time.seconds == 0){
        time.seconds = 59;
        if(time.minutes > 0){
          time.minutes = time.minutes -1;
        }
      }
      else{
        time.seconds = time.seconds - 1;
      }
      return time;
    }
    this.pause = function(){
     this.timeManager.pause();
    }
    this.stop = function(){
      this.timeManager.stop();
      this.time = getTimeFromConfiguration();
      this.uiManager.setLabelTimer(this.time.minutes, this.time.seconds);
    }
    this.playAlarm = function(){
      this.soundManager.playAlarm();
    }
    this.timeManager.addListener("tick", this.manageTime);

    /* tasks */
    this.showTasks = function(){
      this.uiManager.showControlTasks();
    }
    this.showNewTask = function(){
      this.uiManager.showControlNewTask();
    }
    this.hideNewTask = function(){
      this.uiManager.hideControlNewTask();
    }
    this.addNewTask = function(){
      var nameNewTask = this.uiManager.getNameNewtask();
      var newTask = new Task(nameNewTask);
      this.taskManager.saveNewTask(newTask);

      this.uiManager.printNewTask(newTask);
      this.uiManager.cleanControlNameNewTask();
    }
    this.removeTask = function(){
      this.uiManager.removeSelectedTask();
    }
    this.upTask = function(){
      this.uiManager.upSelectedTask();
    }
    this.downTask = function(){
      this.uiManager.downSelectedTask();
    }

    /* ABOUT */
    this.showAbout = function(){
      this.uiManager.showControlAbout();
    }
    this.hideAbout = function(){
      this.uiManager.hideControlAbout();
    }

    /* CONFIGURATION */
    this.showConfiguration = function(){
      var time = this.configuration.getTime();
      this.uiManager.showControlConfiguration(time);
    }
    this.hideConfiguration = function(){
      this.uiManager.hideControlConfiguration();
    }
    this.saveConfiguration = function(){
      var minutes = this.uiManager.getNumberOfMinutesFromConfiguration();
      var seconds = this.uiManager.getNumberOfSecondsFromConfiguration();
      var time = new Time();
      time.minutes = minutes;
      time.seconds = seconds; 
      this.configuration.setTime(time);
      this.hideConfiguration();
    }
}
