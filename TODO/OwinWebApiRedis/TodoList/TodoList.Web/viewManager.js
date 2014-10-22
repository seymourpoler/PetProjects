function ViewManager(taskService)
{
	var _taskService = taskService;
	
	function load(){
		$.when(_taskService.getAll())
		.done(function(tasks){
			cleanAll();
			loadAllTasksIntoControls(tasks);
		});
	}

	function setUpRemoveTask(){
		$('.remove_task').click( function() {
					var idTask = $(this).attr('id');
					_taskService.remove(idTask);
					$(this).parent().fadeOut();
					cleanTaskControls();
				});
	}

	function setUpUpdateTask(){
		$('.update_task').click( function() {
					var idTask = $(this).attr('id');
					loadTaskIntoControls(idTask);
				});
	}

	function setUpButtonUpdate(){
		$('#btnUpdate').click( function() {
					var idTask = $(this).attr('id');
					var task = getTaskFromControls();
					$.when(_taskService.update(task))
					.done(function(){
						cleanTaskControls();
						load();
					})
				});
	}

	function loadAllTasksIntoControls(tasks){
		_.each(tasks, function(task){
				$('#todo_list').prepend('<div>' + task.title + ' ' + task.description + ' <a id=' + task.id + ' href=\'#\' class="remove_task">Remove</a> <a id=' + task.id + ' href=\'#\' class="update_task">Update</a></div>');
				setUpRemoveTask();
				setUpUpdateTask();
				setUpButtonUpdate();
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

	function cleanAll(){
		$('#todo_list').empty();
		cleanTaskControls();
	}
	function cleanTaskControls(){
		$('#txtId').val('');
		$('#txtTitle').val('');
		$('#txtDescription').val('');	
	}

	return{
		'load': load
	}
}