//source: https://gist.github.com/bfncs/2020943

var fs = require('fs')

function  Mouse(){
  var self = this;
  var MAX_LENGTH = 3;
  var prevLeftBtn, prevRightBtn, prevMiddleBtn = false;
  var onClickHandler = function(){};
  var onMoveHandler = function(){};
  var dev = typeof(mouseid) === 'number' ? 'mouse' + mouseid : 'mice';
  var buf = new Buffer(MAX_LENGTH);
  self.fileDescription = 0;

  fs.open('/dev/input/' + dev, 'r', onOpen);
  self.onClick = function(handler){
     onClickHandler = handler;
   };
   self.onMouseMove = function(handler){
     onMoveHandler = handler;
   };

   function onOpen(error, fileDescription) {
     if(error){
       console.log('error open file', error);
       return;
     }
     self.fileDescription = fileDescription;
     read(self.fileDescription);
   };

   function read(fileDescription){
     fs.read(fileDescription, buf, 0, MAX_LENGTH, null, onRead);
   }

   function onRead(err) {
     if(err){
       return;
     }
     var event = parse(buf);
     event.dev = dev;
     manageEventType(event);
     if (self.fileDescription){
       read(self.fileDescription);
     }
   }

   function parse(buffer) {
     var event = getEventFrom(buffer);
     var event = getEventTypeFrom(event);
     return event;
   }

   function getEventFrom(buffer){
     var event = {
       leftBtn:    (buffer[0] & 1  ) > 0, // Bit 0
       rightBtn:   (buffer[0] & 2  ) > 0, // Bit 1
       middleBtn:  (buffer[0] & 4  ) > 0, // Bit 2
       xSign:      (buffer[0] & 16 ) > 0, // Bit 4
       ySign:      (buffer[0] & 32 ) > 0, // Bit 5
       xOverflow:  (buffer[0] & 64 ) > 0, // Bit 6
       yOverflow:  (buffer[0] & 128) > 0, // Bit 7
       xDelta:      buffer.readInt8(1),   // Byte 2 as signed int
       yDelta:      buffer.readInt8(2)    // Byte 3 as signed int
     };
     return event;
   }

   function getEventTypeFrom(event){
     if (event.leftBtn || event.rightBtn || event.middleBtn) {
       event.type = 'button';
     } else {
       event.type = 'moved';
     }
     return event;
   }

   function manageEventType(event){
     switch (event.type) {
       case 'button':
          onClickHandler(event);
         break;
       default:
       onMoveHandler(event);
     }
   }
}

module.exports = new Mouse();
