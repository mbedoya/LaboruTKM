using LaboruTKM.Common;
using LaboruTKM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;

namespace LaboruTKM.Web.Controllers.Admin
{
    public class EvaluationController : ApiController
    {
        Evaluation model = new Evaluation();
        string apiUrl = "/api/evaluation/";

        public IEnumerable<EvaluationDTO> Get()
        {

            return model.GetAll();
        }

        public EvaluationDTO Get(int id)
        {
            return model.Get(id);
        }

        public EvaluationDTO Delete(int id)
        {
            EvaluationDTO evaluation = model.Get(id);
            if (evaluation == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            model.Delete(evaluation);
            return evaluation;
        }

        public HttpResponseMessage Put(EvaluationDTO evaluation)
        {
            if (!model.Exists(evaluation.Id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            model.Update(evaluation);
            HttpResponseMessage response = Request.CreateResponse<EvaluationDTO>(HttpStatusCode.OK, evaluation);

            return response;
        }

        public HttpResponseMessage Post(EvaluationDTO evaluation)
        {
            evaluation = model.Add(evaluation);
            HttpResponseMessage response = Request.CreateResponse<EvaluationDTO>(HttpStatusCode.Created, evaluation);
            response.Headers.Location = new Uri(Request.RequestUri + apiUrl + evaluation.Id.ToString());

            return response;
        }
    }
}
