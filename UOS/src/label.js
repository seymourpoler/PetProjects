function Label(){
    var self = this;

	self.tag = 'label';
    self.text = '';
    
    self.render = function(){
        var result = Control.prototype.render.call(this);
	return result.replace("></", ">" + this.text + "</");s
    };
}
Label.prototype = new  Control();
