using CandidateHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CandidateHub.Services;

namespace CandidateHub.Controllers
{
    public class CandidateController : ApiController
    {
        private CandidateRepository candidateRepository;
        public CandidateController()
        {
            this.candidateRepository = new CandidateRepository();
        }
        public Candidate[] Get()
         {
             return this.candidateRepository.GetCandidates();
         }
        public HttpResponseMessage Post(Candidate candidate)
         {
            if (ModelState.IsValid)
            {
            this.candidateRepository.SaveData(candidate);
             var response = Request.CreateResponse<Candidate>(System.Net.HttpStatusCode.Created,candidate);
             return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
             
         }
        public HttpResponseMessage Put(int Id, [FromBody] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                this.candidateRepository.SaveData(candidate);
                var response = Request.CreateResponse<Candidate>(System.Net.HttpStatusCode.Created, candidate);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }
        
        }

    }
