function ViewManager(taskService)
{
	var _taskService = taskService;
	
	function remove(id){
		console.log('remove' + id);
		_taskService.remove(id);
	}

	function load(){
		$.when(_taskService.getAll())
		.done(function(tasks){
		$('#todo_form')[0].reset();
			_.each(tasks, function(task){
				$('#todo_list').prepend('<div>' + task.title + ': ' + task.description + ' <a id=' + task.id + ' href=\'#\' class="a_remove_todo">Remove</a> <a id=' + task.id + ' href=\'#\' class="a_update_todo">Update</a></div>');
				$('.a_remove_todo').click( function() {
					var idTask = $(this).attr('id');
					_taskService.remove(idTask);
					$(this).parent().fadeOut();
				});
				$('.a_update_todo').click( function() {
					var idTask = $(this).attr('id');
					var taskForUpdate = _taskService.getById(idTask);
					console.log(taskForUpdate);
				});
			});
		});
	}

	function loadTask(task)
	{

	}

	function update(){

	}
	return{
		'load': load,
		'remove': remove,
		'update': update
	}
}