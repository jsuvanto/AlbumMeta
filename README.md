# AlbumMeta
A simple REST CRUD and search interface for artist and album metadata.


## Usage:

### GET http://localhost:port/api/artist/[id]
List all artists or returns artist *id*. Empty if none.
* *id*, identification number of the artist

### GET http://localhost:port/api/artist/search/[name]
Lists all artists whose names contain *name*
* *name*, search string

### POST http://localhost:port/api/artist
Add artist. Required values:
* *name*, name of the artist.

### GET http://localhost:port/api/album/[id]
List all albums or return album *id*. Empty if none.
* *id*, identification number of the album

### GET http://localhost:port/api/album/search/[name]
Lists all albums whose names contain *name*
* *name*, search string

### POST http://localhost:port/api/album
Add album. Required values:
* *name*, name of the album
* *artistId*, id number of the artist
* *releaseYear*, release year of the album

## Note:
PUT and DELETE should work for both artist and album, but they haven't been tested yet.
