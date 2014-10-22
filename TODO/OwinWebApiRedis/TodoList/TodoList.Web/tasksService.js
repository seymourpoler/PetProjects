function TasksService (){
	var _url = configuration.url + '/todo'
	function getAll() {
		return $.ajax({url: _url,type: 'get'})
		.done(function(response, textStatus, jqXHR){
			console.log('get all OK');
			return response;
		})
		.fail(function(error){
			console.log('error on get');
			return [];
		});
	}
	function getById(id) {
		return $.ajax({url: _url + '/' + id, type: 'get'})
		.done(function(response, textStatus, jqXHR){
			console.log('getByid Ok ' + id);	
			return response;
		})
		.fail(function(error){
			console.log('error on get by id');
		});	
	}
	function save(task) {
		return $.ajax({url: _url, type: 'post', data: task})
		.done(function(response, textStatus, jqXHR){
			console.log('save OK', response);
			return response;
		})
		.fail(function(error){
			console.log('error on post');
			return {title:'', description:''};
		});		
	}
	function update(task) {
		return $.ajax({url: _url, type: 'put', data: task})
		.done(function(response, textStatus, jqXHR){
			console.log('update OK');
			return response;
		})
		.fail(function(error){
			console.log('error on put');
		});	
	}
	function remove(id) {
		return $.ajax({url: _url + '/' + id, type: 'delete'})
		.done(function(response, textStatus, jqXHR){
			console.log('delete OK');
			return response;
		})
		.fail(function(error){
			console.log('error on delete');
		});	
	}
	return{
		'getAll':getAll,
		'getById' : getById,
		'save':save,
		'update' : update,
		'remove' : remove
	};
}