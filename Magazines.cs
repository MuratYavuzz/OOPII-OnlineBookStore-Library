using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace _10._05._2018
{
    public class Magazines : Product
    {
        private GetSqlConnect database;
        public enum _MagazineType { BilimKültür, Edebiyat, Sinema, Mizah, Bilim };
        private string MagazineIssue;
        private string MazagineType;
        public string MagazineIssue_
        {
            get { return MagazineIssue; }
            set { MagazineIssue = value; }
        }
        public string MagazineType_
        {
            get { return MagazineType; }
            set { MagazineType = value; }
        }

        public string MagazineType { get; private set; }

    }
}


