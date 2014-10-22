function ViewTaskUpdateManager(taskService){

	var _taskService = taskService;
	var idTxtId = '#txtId';
	var idTxtTitle = '#txtUpdateTitle';
	var idTxtDescription = '#txtUpdateDescription';

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
		cleanAll();
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
			$(idTxtId).val(task.id);
			$(idTxtTitle).val(task.title);
			$(idTxtDescription).val(task.description);
		});
	}

	function getTaskFromControls()
	{
		var task = new Task();
		task.id = $(idTxtId).val();
		task.title = $(idTxtTitle).val();
		task.description = $(idTxtDescription).val();
		return task;
	}

	function cleanAll(){
		$('#todo_list').empty();
		cleanTaskControls();
	}
	function cleanTaskControls(){
		$('#txtId').val('');
		$('#txtUpdateTitle').val('');
		$('#txtDescription').val('');	
	}

	return {
		'loadAllTasksIntoControls': loadAllTasksIntoControls
	};
}