using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SaveLink
{
    public class DTO_Link
    {
        private int _id;
        private string _title;
        private string _url;
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
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        public DTO_Link(int id,string title, string url)
        {
            this._id = id;
            this._title = title;
            this._url = url;
        }
    }
}
