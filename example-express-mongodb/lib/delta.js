/*! delta v1.0.0
https://github.com/albertojs
*/
(function(delta){

	delta.Label = function(domId){
		var self = this;

		self.setText = function(text){
			$('#' + domId).text(text);
		};

		self.getText = function(){
			return $('#' + domId).text();
		};

		self.clear = function(){
			  $('#' + domId).empty();
		};

		self.hide = function(miliseconds){
			$('#' + domId).hide(miliseconds);
		};

		self.show = function(miliseconds){
			$('#' + domId).show(miliseconds);
		};

		self.toggle = function(miliseconds){
			$('#' + domId).toggle(miliseconds);
		};

		self.onHover = function(callback){
			$('#' + domId).hover(function(){
				callback()
			});
		};
	};

	delta.Panel = function(domId){
		var self = this;

		self.hide = function(miliseconds){
			$('#' + domId).hide(miliseconds);
		};

		self.show = function(miliseconds){
			$('#' + domId).show(miliseconds);
		};

		self.toggle = function(miliseconds){
			$('#' + domId).toggle(miliseconds);
		};

		self.onHover = function(callback){
			$('#' + domId).hover(function(){
				callback()
			});
		};

		self.setHtml = function(html){
			$('#' + domId).append(html);
		};

		self.clear = function(){
			$('#' + domId).empty();
		};
	};

	delta.TextBox = function(domId){
		var self = this;

		self.getText = function(){
			return $('#' + domId).val();
		};

		self.setText = function(text){
			$('#' + domId).val(text);
		};

		self.hide = function(miliseconds){
			$('#' + domId).hide(miliseconds);
		};

		self.show = function(miliseconds){
			$('#' + domId).show(miliseconds);
		};

		self.toggle = function(miliseconds){
			$('#' + domId).toggle(miliseconds);
		};

		self.clear = function(){
			$('#' + domId).val('');
		};

		self.focus = function(){
			$('#' + domId).focus();
		};

		self.onKeyPress = function(callback){
			$('#' + domId).keypress(function(){
				callback();
			});
		};

		self.onKeyRelease = function(callback){
			$('#' + domId).keyup(function() {
		        callback();
		    });
		};
	};

	delta.Button = function(domId){
		var self = this;

		self.onClick = function(callback){
			$('#' + domId).click(function(){
				callback();
			});
		};

		self.getText = function(){
			return $('#' + domId).val();
		};

		self.setText = function(text){
			$('#' + domId).val(text);
		};

		self.hide = function(miliseconds){
			$('#' + domId).hide(miliseconds);
		};

		self.show = function(miliseconds){
			$('#' + domId).show(miliseconds);
		};

		self.toggle = function(miliseconds){
			$('#' + domId).toggle(miliseconds);
		};

		self.focus = function(){
			$('#' + domId).focus();
		};
	};

	delta.CheckBox = function(domId){
		var self = this;

		self.isChecked = function(){
			return $('#' + domId).prop('checked');
		};

		self.show = function(miliseconds){
			$('#' + domId).show(miliseconds);
		};

		self.hide = function(miliseconds){
			$('#' + domId).hide(miliseconds);
		};

		self.toggle = function(miliseconds){
			$('#' + domId).toggle(miliseconds);
		};

		self.check = function(){
			$('#' + domId).prop('checked', true);
		};

		self.unCheck = function(){
			$('#' + domId).prop('checked', false);
		};

		self.focus = function(){
			$('#' + domId).focus();
		};

		self.onChange = function(callback){
			$('#' + domId).change(function(){
				callback();
			});
		};
	};

	delta.RadioButton = function(domId){
		var self = this;

		self.hide = function(miliseconds){
			$('#' + domId).hide(miliseconds);
		};

		self.show = function(miliseconds){
			$('#' + domId).show(miliseconds);
		};

		self.check = function(){
			$('#' + domId).prop('checked', true);
		};

		self.unCheck = function(){
			$('#' + domId).prop('checked', false);
		};

		self.focus = function(){
			$('#' + domId).focus();
		};

		self.toggle = function(miliseconds){
			$('#' + domId).toggle(miliseconds);
		};

		self.isChecked = function(){
			return $('#' + domId).prop('checked');
		};

		self.onChange = function(callback){
			$('#' + domId).change(function(){
				callback();
			});
		};
	};

	delta.DropDownList = function(domId){
		var self = this;

		self.hide = function(miliseconds){
			$('#' + domId).hide(miliseconds);
		};

		self.show = function(miliseconds){
			$('#' + domId).show(miliseconds);
		};

		self.toggle = function(miliseconds){
			$('#' + domId).toggle(miliseconds);
		};

		self.focus = function(){
			$('#' + domId).focus();
		};

		self.onChange = function(callback){
			$('#' + domId).change(function(){
				callback();
			});
		};

		self.setSelectedIndex = function(index){
			$('#' + domId).prop('selectedIndex', index);
		};

		self.getSelectedIndex = function(){
			return $('#' + domId).prop('selectedIndex');
		};

		self.setSelectedValue = function(value){
			$('#' + domId).val(value);
		};

		self.getSelectedValue = function(){
			return $('#' + domId).val();
		};

		self.setSelectedText = function(text){
			$('#' + domId + ' option:contains(' + text + ')').attr('selected', true);
		};

		self.getSelectedText = function(){
			return $('#' + domId + ' option:selected').text();
		};

		self.add = function(value, text, index){
			if(index)
				$('#' + domId + ' option').eq(index).before($('<option></option>').val(value).html(text));
			else
				$('#' + domId).append($('<option></option>').val(value).html(text));
		};

		self.removeByIndex = function(index){
			$('#' + domId + ' option:eq(' + index + ')').remove();
		};

		self.removeByValue = function(value){
			$('#' + domId + ' option[value=' + value + ']').remove();
		};

		self.removeByText = function(text){
			$('#' + domId + ' option:contains(' + text + ')').remove();
		};

		self.clear = function(){
			$('#' + domId).find('option').remove();
		};

	};

	delta.List = function(domId){
		var self = this;

		self.clear = function(){
			$('#' + domId).empty();
		};

		self.addItem = function(item){
			$('#' + domId).append(
        $("<li id='" + item.id + "'>" + item.name + "</li>"));
		};

		self.addHtmlItem = function(htmlItem){
			$('#' + domId).append(htmlItem);
		};


		self.removeItem = function(itemId){
				$('#' + domId).find(itemId).remove();
		};
	};

	delta.Client = function(){
		var self = this;

		self.get = function(url, successCallback, errorCallback){
			$.ajax({
					url: url,
					type: "GET",
					success: function(response) {
		            	successCallback(JSON.parse(response));
		        	},
					error: function (response) {
		            	errorCallback(JSON.parse(response));
		        	}
				});
		};

		self.post = function(data, url, successCallback, errorCallback)
		{
			$.ajax({
					url: url,
					data: JSON.stringify(data),
					type: "POST",
					contentType: "application/json",
					success: function(response) {
		            	successCallback(JSON.parse(response));
		        	},
					error: function (response) {
		            	errorCallback(JSON.parse(response));
		        	}
				});
		};
	};

	delta.Redirector = function(){
		var self = this;

		self.redirect = function(url){
			window.location = url;
		};
	};

	delta.CookieManager = function(){
		var self = this;

		self.set = function(name, value, expirationInDays){
			if(expirationInDays)
				$.cookie(name, value,{ expires : expirationInDays });
			else
				$.cookie(name, value);
		};

		self.get = function(name){
			return $.cookie(name);
		};

		self.remove = function(name){
			$.removeCookie(name);
		};
	};

}(window.delta = window.delta || {}))
