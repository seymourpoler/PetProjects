$(document).ready(function() {
	console.log('Start OK');
	console.log(configuration.url);
	var newTask = {title:'task'};
	var taskService = new TasksService();
	var viewManager = new ViewManager(taskService);
	viewManager.load();
	
	/*
	$.when(taskService.save(newTask))
	.done(function(){
		return $.when(taskService.getAll())
		.done(function(tasks){
			console.log('done tasks: ' + tasks);

			var taskUpdate = tasks[0];
			taskUpdate.description = 'Description updated';
			taskUpdate.title = 'title Updated';
			taskUpdate.state = 'Done';
			$.when(taskService.update(taskUpdate))
			.done(function(task){
				console.log('delete id: ' + task.id);
				taskService.remove(task.id);
			});
		});
	});
	*/
});