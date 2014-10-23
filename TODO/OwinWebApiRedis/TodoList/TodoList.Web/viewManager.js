function ViewManager(taskService)
{
	var _taskService = taskService;
	
	var idTxtId = '#txtId';
	var idTxtUpdateTitle = '#txtUpdateTitle';
	var idTxtSaveTitle = '#txtSaveTitle';
	var idTxtUpdateDescription = '#txtUpdateDescription';
	var idTxtSaveDescription = '#txtSaveDescription';

	setUpButtonSave();
	setUpButtonUpdate();

	function load(){
		$.when(_taskService.getAll())
		.done(function(tasks){
			$.when(loadAllTasksIntoControls(tasks))
			.done(function(){
				setUpRemoveTask();
				setUpUpdateTask();
			});
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
			loadTaskForUpdateIntoControls(idTask);
		});
	}

	function setUpButtonSave(){
		$('#btnSave').click( function() {
			var task = getTaskFromControlsForSaving();
			$.when(_taskService.save(task))
			.done(function(){
				cleanAll();
				load();
			})
		});
	}

	function setUpButtonUpdate(){
		$('#btnUpdate').click( function() {
			var task = getTaskFromControlsForUpdating();
			$.when(_taskService.update(task))
			.done(function(){
				cleanAll();
				load();
			})
		});
	}

	function loadAllTasksIntoControls(tasks){
		cleanAll();
		_.each(tasks, function(task){
				$('#todo_list').prepend('<div>' + task.title + ' ' + task.description + ' <a id=' + task.id + ' href=\'#\' class="remove_task">Remove</a> <a id=' + task.id + ' href=\'#\' class="update_task">Update</a></div>');
			});
	}

	function loadTaskForUpdateIntoControls(idTask)
	{
		$.when(_taskService.getById(idTask))
		.done(function(task){
			$(idTxtId).val(task.id);
			$(idTxtUpdateTitle).val(task.title);
			$(idTxtUpdateDescription).val(task.description);
		});
	}

	function getTaskFromControlsForUpdating()
	{
		var task = new Task();
		task.id = $(idTxtId).val();
		task.title = $(idTxtUpdateTitle).val();
		task.description = $(idTxtUpdateDescription).val();
		return task;
	}

	function getTaskFromControlsForSaving()
	{
		var task = new Task();
		task.title = $(idTxtSaveTitle).val();
		task.description = $(idTxtSaveDescription).val();
		return task;
	}

	function cleanAll(){
		$('#todo_list').empty();
		cleanTaskControls();
	}

	function cleanTaskControls(){
		$('#txtId').val('');
		$(idTxtUpdateTitle).val('');
		$(idTxtUpdateDescription).val('');
		$(idTxtSaveTitle).val('');
		$(idTxtSaveDescription).val('');	
	}

	return{
		'load': load
	}
}