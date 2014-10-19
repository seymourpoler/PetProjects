$(document).ready(function() {
	console.log('Start OK');
	console.log(configuration.url);
	var newTask = {title:'task'};
	var taskService = new TasksService();
	
	$.when(taskService.save(newTask))
	.done(function(){
		$.when(taskService.getAll())
		.done(function(tasks){
			console.log('done tasks: ' + tasks);

			var taskUpdate = tasks[0];
			taskUpdate.Description = 'Description added';
			taskService.update(taskUpdate);
			
		});
	});
});