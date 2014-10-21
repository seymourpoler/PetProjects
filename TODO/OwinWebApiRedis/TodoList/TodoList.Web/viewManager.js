function ViewManager(taskService)
{
	var _taskService = taskService;
	
	function remove(id){
		console.log('remove' + id);
		_taskService.remove(id);
		this.load();
	}

	function load(){
		$.when(_taskService.getAll())
		.done(function(tasks){
		$('#todo_form')[0].reset();
			_.each(tasks, function(task){
				$('#todo_list').prepend('<div>' + task.title + ' <a id=' + task.id + ' href=\'#\' class="a_todo">Remove</a></div>');
				$('.a_todo').click( function() {
					var idTask = $(this).attr('id');
					console.log('viewManager remove from a id: ' + $(this).attr('id'));
					_taskService.remove(idTask);
					//$(this).parents('div').fadeOut();
					$(this).parent().fadeOut();
				});
			});
		});

	}

	return{
		'load': load,
		'remove': remove
	}
}