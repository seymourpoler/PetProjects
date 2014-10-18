$(document).ready(function() {
	console.log('Start OK');
	console.log(configuration.url);
	var newTask = {Title:'task'};
	var taskService = new TasksService();
	
	$.when(taskService.save(newTask))
	.then(function(x){
		$.when(taskService.getAll())
		.then(function(tasks){
			var taskUpdate = tasks[0];
			taskUpdate.Description = 'Description added';
			taskService.update(taskUpdate);
		});
	});
});