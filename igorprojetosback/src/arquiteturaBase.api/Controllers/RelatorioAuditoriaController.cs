using arquiteturaBase.application.Dto;
using arquiteturaBase.application.Interfaces.Service;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace arquiteturaBase.api.Controllers
{
    public class RelatorioAuditoriaController : ApiController
    {

        

        /// <summary>
        /// Relatorio
        /// </summary>
        [HttpGet, Route("api/relatorioauditoria/relatorio")]
        //[HttpGet, Route("api/relatorioauditoria/relatorio")]
        public Task<HttpResponseMessage> GetRelatorio(string dt_auditoriaInicial, string dt_auditoriaFinal)
        {
            try
            {
                IRelatorioAuditoriaService service = ObjectFactory.GetInstance<IRelatorioAuditoriaService>();
                IEnumerable<RelatorioDto> lstrelatorio = service.GetRelatorio(dt_auditoriaInicial,dt_auditoriaFinal);
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, lstrelatorio));
            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }

        }

    }
}