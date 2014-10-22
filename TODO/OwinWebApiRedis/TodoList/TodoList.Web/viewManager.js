function ViewManager(taskService, viewTaskUpdateManager)
{
	var _taskService = taskService;
	var _viewTaskUpdateManager = viewTaskUpdateManager;
	
	function load(){
		$.when(_taskService.getAll())
		.done(function(tasks){
			_viewTaskUpdateManager.loadAllTasksIntoControls(tasks);
		});
	}

	return{
		'load': load
	}
}