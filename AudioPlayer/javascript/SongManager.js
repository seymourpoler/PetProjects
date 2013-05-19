function Song(){
  this.guid = generateNewGUID();
  this.name = '';
  this.file = '';
  this.seconds = 0;

  function generateNewGUID (){
      var S4 = function ()
      {
          return Math.floor(
                  Math.random() * 0x10000 /* 65536 */
              ).toString(16);
      };

      return (
              S4() + S4() + "-" +
              S4() + "-" +
              S4() + "-" +
              S4() + "-" +
              S4() + S4() + S4()
          );
    }

  return {
    guid : this.guid,
    name: this.name,
    file: this.file,
    duration: this.seconds
  }
}

function SongManager(){
	this.songs = [];

	this.addNewSong = function(newSong){
		this.songs.push(newSong);
	}

	this.removeSong = function(newSong){
		songs.push(newSong);
	}

	this.removeSongByGuid = function(song){
    var aux;
    var position = 0;
    var actualSong;
    var resultSong;
    while (position < this.songs.length) {
      actualTask = this.songs[position];
      if(actualSong.guid != song.guid){
        resultSong.push(actualSong);
      }
      position ++;
    }
    this.songs = resultSong;
  }
} 