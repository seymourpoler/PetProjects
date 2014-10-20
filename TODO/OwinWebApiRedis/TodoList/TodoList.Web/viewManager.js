function ViewManager(taskService)
{
	var _taskService = taskService;

	function load(){
		$.when(_taskService.getAll())
		.done(function(tasks){
		$('#todo_form')[0].reset();
			_.each(tasks, function(task){
				$('#todo_list').append('<div>' + task.title + '</div>');
			});
		});
	}

	return{
		'load':load
	}
}