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

        public string Title //min 1 tegn - NOT NULL
        {
            get { return _title; }
            set
            {
                if (value == null) throw new ArgumentNullException();
                if (value.Length >= 1) _title = value;
                else throw new ArgumentException("Length must be at least one character");
            }
        }

        public string Artist //min 3 tegn - NOT NULL
        {
            get { return _artist; }
            set
            {
                if (value == null) throw new ArgumentNullException();
                if (value.Length >= 3) _artist = value;
                else throw new ArgumentException("Length must be more than 2 characters");
            }
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

        public int YearOfPublication //over år 0
        {
            get { return _yearOfPublication; }
            set
            {
                if (value > 0) _yearOfPublication = value;
                else throw new ArgumentOutOfRangeException();
            }
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
