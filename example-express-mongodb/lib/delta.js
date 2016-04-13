/*! delta v1.0.0
https://github.com/albertojs
*/

(function(delta){

	delta.Label = function(domId){
		var self = this;
		var label = $('#' + domId);

		self.setText = function(text){
			label.text(text);
		};

		self.getText = function(){
			return label.text();
		};

		self.clear = function(){
			  label.empty();
		};

		self.hide = function(miliseconds){
			label.hide(miliseconds);
		};

		self.show = function(miliseconds){
			label.show(miliseconds);
		};

		self.toggle = function(miliseconds){
			label.toggle(miliseconds);
		};

		self.onHover = function(callback){
			label.hover(function(){
				callback()
			});
		};
	};

	delta.Panel = function(domId){
		var self = this;
		var panel = $('#' + domId);

		self.hide = function(miliseconds){
			panel.hide(miliseconds);
		};

		self.show = function(miliseconds){
			panel.show(miliseconds);
		};

		self.toggle = function(miliseconds){
			panel.toggle(miliseconds);
		};

		self.onHover = function(callback){
			panel.hover(function(){
				callback()
			});
		};

		self.setHtml = function(html){
			panel.append(html);
		};

		self.clear = function(){
			panel.empty();
		};
	};

	delta.TextBox = function(domId){
		var self = this;
		var textBox = $('#' + domId);

		self.getText = function(){
			return textBox.val();
		};

		self.setText = function(text){
			textBox.val(text);
		};

		self.hide = function(miliseconds){
			textBox.hide(miliseconds);
		};

		self.show = function(miliseconds){
			textBox.show(miliseconds);
		};

		self.toggle = function(miliseconds){
			textBox.toggle(miliseconds);
		};

		self.clear = function(){
			textBox.val('');
		};

		self.focus = function(){
			textBox.focus();
		};

		self.onKeyPress = function(callback){
			textBox.keypress(function(){
				callback();
			});
		};

		self.onKeyRelease = function(callback){
			textBox.keyup(function() {
		        callback();
		    });
		};
	};

	delta.Button = function(domId){
		var self = this;
		var button = $('#' + domId);

		self.onClick = function(callback){
			button.click(function(){
				callback();
			});
		};

		self.getText = function(){
			return button.val();
		};

		self.setText = function(text){
			button.val(text);
		};

		self.hide = function(miliseconds){
			button.hide(miliseconds);
		};

		self.show = function(miliseconds){
			button.show(miliseconds);
		};

		self.toggle = function(miliseconds){
			button.toggle(miliseconds);
		};

		self.focus = function(){
			button.focus();
		};
	};

	delta.CheckBox = function(domId){
		var self = this;
		var checkBox = $('#' + domId);

		self.isChecked = function(){
			return checkBox.prop('checked');
		};

		self.show = function(miliseconds){
			checkBox.show(miliseconds);
		};

		self.hide = function(miliseconds){
			checkBox.hide(miliseconds);
		};

		self.toggle = function(miliseconds){
			checkBox.toggle(miliseconds);
		};

		self.check = function(){
			checkBox.prop('checked', true);
		};

		self.unCheck = function(){
			checkBox.prop('checked', false);
		};

		self.focus = function(){
			checkBox.focus();
		};

		self.onChange = function(callback){
			checkBox.change(function(){
				callback();
			});
		};
	};

	delta.RadioButton = function(domId){
		var self = this;
		var radioButton = $('#' + domId);

		self.hide = function(miliseconds){
			radioButton.hide(miliseconds);
		};

		self.show = function(miliseconds){
			radioButton.show(miliseconds);
		};

		self.check = function(){
			radioButton.prop('checked', true);
		};

		self.unCheck = function(){
			radioButton.prop('checked', false);
		};

		self.focus = function(){
			radioButton.focus();
		};

		self.toggle = function(miliseconds){
			radioButton.toggle(miliseconds);
		};

		self.isChecked = function(){
			return radioButton.prop('checked');
		};

		self.onChange = function(callback){
			radioButton.change(function(){
				callback();
			});
		};
	};

	delta.DropDownList = function(domId){
		var self = this;
		var dropDownList = $('#' + domId);

		self.hide = function(miliseconds){
			dropDownList.hide(miliseconds);
		};

		self.show = function(miliseconds){
			dropDownList.show(miliseconds);
		};

		self.toggle = function(miliseconds){
			dropDownList.toggle(miliseconds);
		};

		self.focus = function(){
			dropDownList.focus();
		};

		self.onChange = function(callback){
			dropDownList.change(function(){
				callback();
			});
		};

		self.setSelectedIndex = function(index){
			dropDownList.prop('selectedIndex', index);
		};

		self.getSelectedIndex = function(){
			return dropDownList.prop('selectedIndex');
		};

		self.setSelectedValue = function(value){
			dropDownList.val(value);
		};

		self.getSelectedValue = function(){
			return dropDownList.val();
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
				dropDownList.append($('<option></option>').val(value).html(text));
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
			dropDownList.find('option').remove();
		};

	};

	delta.List = function(domId){
		var self = this;
		var list = $('#' + domId);

		self.clear = function(){
			list.empty();
		};

		self.addItem = function(item){
			list.append(
        $("<li id='" + item.id + "'>" + item.name + "</li>"));
		};

		self.addHtmlItem = function(htmlItem){
			list.append(htmlItem);
		};

		self.removeItem = function(itemId){
				list.find(itemId).remove();
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

		self.post = function(data, url, successCallback, errorCallback){
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

		self.delete = function(url, successCallback, errorCallback){
			$.ajax({
	      url: url,
	      type: 'DELETE'
	    })
	    .done(function() {
	      successCallback();
	    })
	    .fail(function(error) {
	      errorCallback(error);
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
