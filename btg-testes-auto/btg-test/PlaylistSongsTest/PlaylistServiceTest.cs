using btg_testes_auto.PlaylistSongs;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.PlaylistSongsTest
{
    public class PlaylistServiceTest
    {
        private readonly IPlaylistValidationService _mockPlaylistValidationService;
        private PlaylistService _sut;

        public PlaylistServiceTest()
        {
            _mockPlaylistValidationService = Substitute.For<IPlaylistValidationService>();
            _sut = new(_mockPlaylistValidationService);
        }

        [Fact]
        public void AddSongToPlaylist_ValidSong_ReturnsTrue()
        {
            // Arrange
            List<Song> songs = new List<Song>();
            Playlist playlist = new Playlist { Songs = songs, MaxSongs = 5 };

            Song song1 = new()
            {
                Title = "Faroeste Caboclo",
                Artist = "Legião Urbana"
            };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song1).Returns(true);

            // Act
            bool result = _sut.AddSongToPlaylist(playlist, song1);

            // Assert
            result.Should().BeTrue();
            _mockPlaylistValidationService.Received(1).CanAddSongToPlaylist(playlist, song1);

        }

        [Fact]
        public void AddSongToPlaylist_InvalidSong_ReturnsFalse()
        {
            // Arrange
            List<Song> songs = new List<Song>();
            Playlist playlist = new() { Songs = songs, MaxSongs = 5 };

            Song song1 = new()
            {
                Title = "Faroeste Caboblo",
                Artist = "Legião Urbana"
            };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song1).Returns(false);

            // Act
            bool result = _sut.AddSongToPlaylist(playlist, song1);

            // Assert
            result.Should().BeFalse();
            _mockPlaylistValidationService.Received(1).CanAddSongToPlaylist(playlist, song1);
        }

        [Fact]
        public void AddSongsToPlaylist_ValidSongs_AddsToPlaylist()
        {
            // Arrange
            List<Song> songs = new List<Song>();
            Playlist playlist = new Playlist { Songs = songs, MaxSongs = 3 };

            Song song1 = new()
            {
                Title = "Faroeste Caboclo",
                Artist = "Legião Urbana"
            };
            Song song2 = new()
            {
                Title = "Sereníssima",
                Artist = "Legião Urbana"
            };

            List<Song> songsToAdd = new List<Song> { song1, song2 };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, Arg.Any<Song>()).Returns(true);

            // Act
            _sut.AddSongsToPlaylist(playlist, songsToAdd);

            // Assert
            playlist.Songs.Count.Should().Be(songsToAdd.Count);
            _mockPlaylistValidationService.Received(songsToAdd.Count).CanAddSongToPlaylist(playlist, Arg.Any<Song>());
        }

    }
}
