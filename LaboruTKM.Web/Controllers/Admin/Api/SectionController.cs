using LaboruTKM.Common;
using LaboruTKM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LaboruTKM.Web.Controllers.Admin.Api
{
    public class SectionController : ApiController
    {
        Section model = new Section();

        public SectionDTO Get(int id)
        {
            return model.Get(id);
        }
    }
}
