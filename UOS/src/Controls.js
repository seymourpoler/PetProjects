function Control(){
	this.id = '';
	this.tag = '';
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

	this.render = function(){
		var result =  "<" + this.tag;

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
		var subControls = renderSubControls(this.controls);
		result = result.concat(subControls);
		return result.concat("</" + this.tag + ">");
	}

	function renderSubControls(controls){
		var result = '';
		var domRendered = '';
		for(var cont = 0; cont < controls.length; cont++){
			domRendered = controls[cont].render();
			result = result.concat(domRendered);
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

function Label(){
	this.tag = 'label';
}
Label.prototype = new Control();

