using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _10._05._2018
{
    public class MusicCDs : Product
    {
        public enum MusicType { Jazz, Pop, Rock, Blues, TSM };
        private GetSqlConnect database;
        private string MusicCDSinger;
        private string MusicCDType;
        private string MusicCDIssue;
        public string MusicCDSinger_
        {
            get { return MusicCDSinger; }
            set { MusicCDSinger = value; }
        }
        public string MusicCDType_
        {
            get { return MusicCDType; }
            set { MusicCDType = value; }
        }
        public string MusicCDIssue_
        {
            get { return MusicCDIssue; }
            set { MusicCDIssue = value; }
        }
      
    }
}

