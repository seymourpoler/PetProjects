function TasksService (){
	var _url = configuration.url + '/todo'
	function getAll() {
		console.log('getAll from tasksService');

		$.ajax({url: _url,type: "get"})
		.done(function(response, textStatus, jqXHR){
			console.log('get done: ', response);
			return response;
		})
		.fail(function(error){
			console.log('error on get');
		});	
	}
	function getById(id) {
		console.log('getByid from tasksService' + id);	
	}
	function save(task) {
		console.log('Save from tasksService');

		$.ajax({url: _url, type: "post", data: task})
		.done(function(response, textStatus, jqXHR){
			console.log('post done', response);
			return response;
		})
		.fail(function(error){
			console.log('error on post');
		});		
	}
	function update(task) {
		console.log('Update from tasksService');
		
		$.ajax({url: _url, type: "put", data: task})
		.done(function(response, textStatus, jqXHR){
			console.log('put done', response);
			return response;
		})
		.fail(function(error){
			console.log('error on put');
		});	
	}
	function remove(id) {
		
	}
	return{
		'getAll':getAll,
		'getById' : getById,
		'save':save,
		'update' : update,
		'remove' : remove
	};
}