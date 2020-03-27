using System;

namespace DR_Music_Collection
{
    public class MusicRecords
    {
        private int _id;
        private string _title;
        private string _artist;
        private string _album;
        private string _recordLabel;
        private int _durationInSeconds;
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

        public string Artist //min 2 tegn - NOT NULL
        {
            get { return _artist; }
            set
            {
                if (value == null) throw new ArgumentNullException();
                if (value.Length >= 2) _artist = value;
                else throw new ArgumentException("Length must be at least 2 characters");
            }
        }

        public string Album //min 2 tegn - NOT NULL
        {
            get { return _album; }
            set
            {
                if (value == null) throw new ArgumentNullException();
                if (value.Length >= 2) _album = value;
                else throw new ArgumentException("Length must be at least 2 characters");
            }
        }

        public string RecordLabel //min 2 tegn - NOT NULL
        {
            get { return _recordLabel; }
            set
            {
                if (value == null) throw new ArgumentNullException();
                if (value.Length >= 2) _recordLabel = value;
                else throw new ArgumentException("Length must be at least 2 characters");
            }
        }

        public int DurationInSeconds //over 60 sec
        {
            get { return _durationInSeconds; }
            set
            {
                if (value > 60) _durationInSeconds = value;
                else throw new ArgumentOutOfRangeException();
            }
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

        public MusicRecords(int Id, string Title, string Artist, string Album, string RecordLabel, int DurationInSeconds, int YearOfPublication)
        {
            _id = Id;
            _title = Title;
            _artist = Artist;
            _album = Album;
            _recordLabel = RecordLabel;
            _durationInSeconds = DurationInSeconds;
            _yearOfPublication = YearOfPublication;
        }

        public MusicRecords()
        {

        }

        public override string ToString()
        {
            return "Id: " + "" + Id + "" + "Title: " + "" + Title + "" + "Artist: " + "" + Artist + "" + "Album: " + "" + Album + "" + "Recordlabel: " + "" + RecordLabel + "" + "Duration: " +
                   "" + DurationInSeconds + "" + "Year of publication: " + "" + YearOfPublication;
        }

    }
}
