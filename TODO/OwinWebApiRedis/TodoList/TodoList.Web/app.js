$(document).ready(function() {
	console.log('Start OK');
	console.log(configuration.url);
	var newTask = {Title:'task'};
	var taskService = new TasksService();
	taskService.save(newTask);
	var tasks = taskService.getAll();
	console.log(tasks);
});