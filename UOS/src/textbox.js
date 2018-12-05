function TextBox(){
    var self = this;
	this.tag = 'input';
	this.type = 'text';
    this.text = '';
    
    self.render = function(){
        return "<input type='text'/>";
    };
}