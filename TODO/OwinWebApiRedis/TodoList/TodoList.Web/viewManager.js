function ViewManager(taskService)
{
	var _taskService = taskService;

	var idTodoList = '#todo_list';
	var idTxtId = '#txtId';
	var idTxtUpdateTitle = '#txtUpdateTitle';
	var idTxtSaveTitle = '#txtSaveTitle';
	var idTxtUpdateDescription = '#txtUpdateDescription';
	var idTxtSaveDescription = '#txtSaveDescription';
	var idSelectUpdateState = '#selectUpdateState';
	var idSelectSaveState = '#selectSaveState';
	var idLabelInformation = '#lblInformation';

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
			.fail(function(error){
				console.log('error on Save from viewManager');
				$('#lblInformation').html(error.responseText);
			});
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
			.fail(function(error){
				console.log('error on Update from viewManager');
				$(idLabelInformation).html(error.responseText);
			});
		});
	}

	function loadAllTasksIntoControls(tasks){
		cleanAll();
		_.each(tasks, function(task){
				$(idTodoList).prepend('<div>' + task.title + ' ' + task.description + ' <a id=' + task.id + ' href=\'#\' class="remove_task">Remove</a> <a id=' + task.id + ' href=\'#\' class="update_task">Update</a></div>');
			});
	}

	function loadTaskForUpdateIntoControls(idTask)
	{
		$.when(_taskService.getById(idTask))
		.done(function(task){
			$(idTxtId).val(task.id);
			$(idTxtUpdateTitle).val(task.title);
			$(idTxtUpdateDescription).val(task.description);
			$(idSelectUpdateState).val(task.state);
		});
	}

	function getTaskFromControlsForUpdating()
	{
		var task = new Task();
		task.id = $(idTxtId).val();
		task.title = $(idTxtUpdateTitle).val();
		task.description = $(idTxtUpdateDescription).val();
		task.state = $(idSelectUpdateState).val();
		return task;
	}

	function getTaskFromControlsForSaving()
	{
		var task = new Task();
		task.title = $(idTxtSaveTitle).val();
		task.description = $(idTxtSaveDescription).val();
		task.state = $(idSelectSaveState).val();
		return task;
	}

	function cleanAll(){
		$(idTodoList).empty();
		cleanTaskControls();
	}

	function cleanTaskControls(){
		$('#txtId').val('');
		$(idTxtUpdateTitle).val('');
		$(idTxtUpdateDescription).val('');
		$(idSelectUpdateState).val('1');	
		$(idTxtSaveTitle).val('');
		$(idTxtSaveDescription).val('');	
		$(idSelectSaveState).val('1');
		$(idLabelInformation).html('');	
	}

	return{
		'load': load
	}
}