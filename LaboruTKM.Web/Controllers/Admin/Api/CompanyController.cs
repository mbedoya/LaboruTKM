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
    public class CompanyController : ApiController
    {
        Company model = new Company();
        string apiUrl = "/api/company/";

        public IEnumerable<CompanyDTO> Get()
        {

            return model.GetAll();
        }

        public CompanyDTO Get(int id)
        {
            return model.Get(id);
        }

        public CompanyDTO Delete(int id)
        {
            CompanyDTO element = model.Get(id);
            if (element == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            model.Delete(element);
            return element;
        }

        public HttpResponseMessage Put(CompanyDTO element)
        {
            if (!model.Exists(element.Id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            model.Update(element);
            HttpResponseMessage response = Request.CreateResponse<CompanyDTO>(HttpStatusCode.OK, element);

            return response;
        }

        public HttpResponseMessage Post(CompanyDTO element)
        {
            element = model.Add(element);
            HttpResponseMessage response = Request.CreateResponse<CompanyDTO>(HttpStatusCode.Created, element);
            response.Headers.Location = new Uri(Request.RequestUri + apiUrl + element.Id.ToString());

            return response;
        }
    }
}
