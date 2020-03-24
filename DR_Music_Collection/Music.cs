using System;

namespace DR_Music_Collection
{
    public class Music
    {
        private int _id;
        private string _title;
        private string _artist;
        private string _album;
        private string _recordLabel;
        private double _duration;
        private int _yearOfPublication;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }

        public string Album
        {
            get { return _album; }
            set { _album = value; }
        }

        public string RecordLabel
        {
            get { return _recordLabel; }
            set { _recordLabel = value; }
        }
        public double Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public int YearOfPublication
        {
            get { return _yearOfPublication; }
            set { _yearOfPublication = value; }
        }

        public Music(int Id, string Title, string Artist, string Album, string RecordLabel, double Duration, int YearOfPublication)
        {
            _id = Id;
            _title = Title;
            _artist = Artist;
            _album = Album;
            _recordLabel = RecordLabel;
            _duration = Duration;
            _yearOfPublication = YearOfPublication;
        }

        public Music()
        {

        }

        public override string ToString()
        {
            return "Id: " + "" + Id + "" + "Title: " + "" + Title + "" + "Artist: " + "" + Artist + "" + "Album: " + "" + Album + "" + "Recordlabel: " + "" + RecordLabel + "" + "Duration: " +
                   "" + Duration + "" + "Year of publication: " + "" + YearOfPublication;
        }

    }
}
