# AlbumMeta
A simple REST CRUD and search interface for artist and album metadata.


## Usage:

### GET http://localhost:port/api/artist/[id]
* *id*, identification number of the artist
List all artists or returns artist *id*. Empty if none.

### GET http://localhost:port/api/artist/search/[name]
* *name*, search string
Lists all artists whose names contain *name*

### POST http://localhost:port/api/artist
Add artist. Required values:
* *name*, name of the artist.

### GET http://localhost:port/api/album/[id]
* *id*, identification number of the album
List all albums or return album *id*. Empty if none.

### GET http://localhost:port/api/album/search/[name]
* *name*, search string
Lists all albums whose names contain *name*

### POST http://localhost:port/api/album
Add album. Required values:
* *name*, name of the album
* *artistId*, id number of the artist
* *releaseYear*, release year of the album

Also PUT and DELETE should work for both artist and album, but they haven't been tested yet.
