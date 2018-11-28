function Control(){
	this.id = '';
	this.tag = '';
	this.type = '';
	this.style = '';
	this.cssClass = '';
	this.disabled = false;
	this.visible = null;
	this.controls = new Array();
	this.onClick = function(){}; //event
	
	this.addCssClass = function(cssClassName){
			this.cssClass = this.cssClass.concat(" " + cssClassName);
	}
	this.removeCssClass = function(cssClassName){
		this.cssClass = this.cssClass.replace(" " + cssClassName, '');
	}
	
	this.addControl = function(control){
		this.controls.push(control);
	}

	this.renderSubControls = function(){
		var result = '';
		var domRendered = '';
		
		for(var cont = 0; cont < this.controls.length; cont++){
			domRendered = this.controls[cont].render();
			result = result.concat(domRendered);
		}
		
		return result;
	}
}

Control.prototype.render = function(){
	var result =  "<" + this.tag;

	if(this.type != ''){
		result = result.concat(" type='" + this.type + "'");
	}

	if(this.id != ''){
		result = result.concat(" id='" + this.id + "'");
	}
	
	if(this.cssClass != ''){
		result = result.concat(" class='" + this.cssClass + "'");
	}

	if(this.visible == true){
		this.style = this.style.concat('visibility:visible;');
	}
	else if(this.visible == false){
		this.style = this.style.concat('visibility:hidden;');
	}

	if(this.style != ''){
		result = result.concat(" style='" + this.style + "'");
	}

	if(this.disabled){
		result = result.concat(" disabled='disabled'");
	}

	result = result.concat(">");
	var subControls = this.renderSubControls();
	result = result.concat(subControls);
	return result.concat("</" + this.tag + ">");
}

function Div(){
	this.tag = 'div';
}
Div.prototype = new Control();

function Span(){
	this.tag = 'span';
}
Span.prototype = new Control();

function TextBox(){
	this.tag = 'input';
	this.type = 'text';
	this.text = '';
}

TextBox.prototype = new Control();
TextBox.prototyperender = function(){
	var result = Control.prototype.render.call(this);
	return retult.replace("></", "value=" + this.text + "></");
}
