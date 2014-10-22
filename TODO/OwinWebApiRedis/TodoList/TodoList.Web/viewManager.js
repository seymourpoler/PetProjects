function ViewManager(taskService)
{
	var _taskService = taskService;
	
	function load(){
		$.when(_taskService.getAll())
		.done(function(tasks){
		$('#todo_form')[0].reset();
			_.each(tasks, function(task){
				$('#todo_list').prepend('<div>' + task.title + ' <a id=' + task.id + ' href=\'#\' class="remove_task">Remove</a> <a id=' + task.id + ' href=\'#\' class="update_task">Update</a></div>');
				$('.remove_task').click( function() {
					var idTask = $(this).attr('id');
					_taskService.remove(idTask);
					$(this).parent().fadeOut();
				});
				$('.update_task').click( function() {
					var idTask = $(this).attr('id');
					loadTaskIntoControls(idTask);
				});
				$('#btnUpdate').click( function() {
					var idTask = $(this).attr('id');
					var task = getTaskFromControls();
					_taskService.update(task);
					cleanControls();
				});
			});
		});
	}

	function loadTaskIntoControls(idTask)
	{
		$.when(_taskService.getById(idTask))
		.done(function(task){
			$('#txtId').val(task.id);
			$('#txtTitle').val(task.title);
			$('#txtDescription').val(task.description);
		});
	}

	function getTaskFromControls()
	{
		var task = new Task();
		task.id = $('#txtId').val();
		task.title = $('#txtTitle').val();
		task.description = $('#txtDescription').val();
		return task;
	}

	function cleanControls(){
		$('#txtTitle').val('');
			$('#txtDescription').val('');	
	}

	return{
		'load': load
	}
}