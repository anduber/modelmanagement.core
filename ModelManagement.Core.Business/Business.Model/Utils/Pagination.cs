using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.Utils
{
    public class Pagination
    {
        public Pagination()
        {
            Page = 0;
            PageSize = 10;
        }

        public Pagination(int page) :
            this()
        {
            Page = page;
        }

        public Pagination(int page, int pageSize)
        {
            Page = page;
            if (pageSize == 0)
            {
                PageSize = 10;
            }
            else
            {
                PageSize = pageSize;
            }
        }

        public int Page { get; set; }



        private int pageSize;

        public int PageSize
        {
            get
            {
                if (pageSize == 0)
                {
                    return 10;
                }
                else
                {
                    return pageSize;
                }
            }

            set { pageSize = value; }
        }
    }
}
