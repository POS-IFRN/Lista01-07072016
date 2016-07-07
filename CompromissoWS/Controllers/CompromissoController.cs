using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompromissoWS.Controllers
{
    public class CompromissoController : ApiController
    {
        // GET: api/Compromisso
        public IEnumerable<Models.Compromisso> Get()
        {
            Models.AgendaDataContext dc = new Models.AgendaDataContext();
            var r = from c in dc.Compromissos select c;
            return r.ToList();
        }

        // POST: api/Compromisso
        public void Post([FromBody]string value)
        {
            List<Models.Compromisso> x = JsonConvert.DeserializeObject
            <List<Models.Compromisso>>(value);
            Models.AgendaDataContext dc = new Models.AgendaDataContext();
            dc.Compromissos.InsertAllOnSubmit(x);
            dc.SubmitChanges();
        }

        // PUT: api/Compromisso/5
        public void Put(int id, [FromBody]string value)
        {
            Models.Compromisso x = JsonConvert.DeserializeObject
            <Models.Compromisso>(value);
            Models.AgendaDataContext dc = new Models.AgendaDataContext();
            Models.Compromisso com = (from c in dc.Compromissos
                                     where c.id == id
                                     select c).Single();
            com.descricao = x.descricao;
            com.local = x.local;
            com.realizado = x.realizado;
            com.data = x.data;
            dc.SubmitChanges();
        }

        // DELETE: api/Compromisso/5
        public void Delete(int id)
        {
            Models.AgendaDataContext dc = new Models.AgendaDataContext();
            Models.Compromisso com = (from c in dc.Compromissos
                                     where c.id == id
                                     select c).Single();
            dc.Compromissos.DeleteOnSubmit(com);
            dc.SubmitChanges();
        }

    }
}
