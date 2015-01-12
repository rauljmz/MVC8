using MVC8.Business;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class TestItem : IItem
    {
        private NameValueCollection _fields;
        public TestItem()
        {
            _fields = new NameValueCollection();
        }
        public string Name
        {
            get;
            set;
        }

        public string TemplateName
        {
            get;
            set;
        }

        public string this[string fieldName]
        {
            get { return _fields[fieldName]; }
            set { _fields[fieldName] = value; }
        }

        public string Url
        {
            get;
            set;
        }
    }
}
