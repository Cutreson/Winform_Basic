using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SaveLink;
using DTO_SaveLink;

namespace BUS_SaveLink
{
    public class BUS_Link
    {
        DAL_Link dal_Link = new DAL_Link();
        public DataTable getLink()
        {
            return dal_Link.getLink();
        }
        public bool addLink(DTO_Link link)
        {
            return dal_Link.addLink(link);
        }
        public bool editLink(DTO_Link link)
        {
            return dal_Link.editLink(link);
        }

    }
}
