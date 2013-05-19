

function AudioPlayer(){
	var theAudio;

	function playSong(song){
    theAudio = new Audio(song);
    console.log('play the song: ' + theAudio.src);
    theAudio.play();
	}

	function pauseSong(){
    console.log('AudioPlayer.pause');
    theAudio.pause();
	}

function stopSong(){
    console.log('AudioPlayer.stop');
    theAudio.pause();
    theAudio.currentTime = 0;
    theAudio = null;
    delete theAudio;
  }

  return {
    playSong:playSong,
    pauseSong: pauseSong,
    stopSong:stopSong
  }
}
