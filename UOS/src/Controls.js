function Control(){
	this.id = '';
	this.tag = '';
	this.style = '';
	this.controls = new Array();
	this.render = function(){
		var result = '';
		if(this.id != ''){
			result = "<" + this.tag +" id='" + this.id + "'></"+ this.tag + ">";
		}
		else{
			result = "<" + this.tag + "></" + this.tag + ">";
		}
		return result;
	}
}

function Div(){
	this.tag = 'div';
}

Div.prototype = new Control();

function Span(){
	this.tag = 'span';
}

Span.prototype = new Control();

