function TasksService (){
	var _url = configuration.url + '/todo'
	function getAll() {
		console.log('getAll from tasksService');
		$.ajax({
			  type: "GET",
			  url: _url,
			  //cache: false,
			  //contentType: "application/json",
			  dataType: 'jsonp',
			  success: function(data){
			     return data;
			  },
			  error: function(error){
				console.log('getall error: ' + error);
			  },
			  complete: function(){
 				console.log('getall done'); 
			  }
			});
	}
	function getById(id) {
		console.log('getByid from tasksService' + id);	
	}
	function update(task) {
		
	}
	function remove(id) {
		
	}
	return{
		'getAll':getAll,
		'getById' : getById,
		'update' : update,
		'remove' : remove
	};
}