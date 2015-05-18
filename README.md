# Playlist Converter
Converts iTunes playlists to Spotify playlists.

![alt text](https://github.com/pihalve/playlist-converter/screenshot.png "Screenshot of main application window")

# How to use

First you select an iTunes playlist (must be in XML format). This will import the songs of the playlist into the list view of the application main window.

Then you press "Convert to Spotify playlist" button. This will initiate a Spotify search for each song in the list view. If a match is found for a song, that song will have the note icon changed into a Spotify icon. Songs for which no match is found will be marked with a grey background and will not get a Spotify icon. When the conversion is done a "Drag me to Spotify" button will appear. You can now drag this into an appropriate playlist in Spotify, and the songs will be added to that Spotify playlist.

If you go to "View->Advanced" and then expand the Playlist Converter window (or drag the horizontal scroll bar) you will see the Spotify search result for each song in the list view.

# How the Spotify search works

By default songs will be searched by all 4 fields, meaning that there will be searched by artist, album, year and track (if these are available in the song info imported from iTunes). Also, by default info appearing in parentheses in artist, album and track  fields will be ignored in the search. All this can be configured by going to the "File->Search Settings" dialog.

There is also the possibility to ignore specific words in the search. These words can be specified in the "Remove occurrences of these words" text field. The words should be delimited by whitespace. By default no words are ignored.

Additionally, there is defined a fallback sequence that will be used in case a match cannot be found for a song. The default fallback search sequence is "Exclude year from search", "Exclude album from search", "Remove words from search" and in that order. So if a song is not found, then an additional search is performed where year is excluded. If the song is still not found, another search is performed where album is excluded. In case the song still is not found, a search will be performed where occurrences of the specified words are ignored. The fallback search sequence can be changed in "File->Search Settings" dialog.

Notes:

- The search is implemented so that it will always try to find the earliest occurrence of a song. This is to increase the likelihood of finding the original release of the song. This was actually one of the main reasons why I created this application, because other playlist converters did not seem to care about this at all, and I got annoyed by getting playlists full of digitally remastered versions with "wrong" year.
- I was doing some experimentation with country filtering, but I have not been able to make it function as I had hoped, so that setting is currently disabled in the "File->Search Settings" dialog.
