$(document).ready(function() {
	console.log('Start OK');
	console.log(configuration.url);
	var taskService = new TasksService();
	var tasks = taskService.getAll();
	console.log(tasks);
});