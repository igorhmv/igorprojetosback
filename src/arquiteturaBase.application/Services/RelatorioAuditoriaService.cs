using arquiteturaBase.application.Dto;
using arquiteturaBase.application.Interfaces;
using arquiteturaBase.application.Interfaces.Service;
using HMV.Core.DataAccess;
using NHibernate;
using NHibernate.Transform;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquiteturaBase.application.Services
{
    public class RelatorioAuditoriaService : IRelatorioAuditoriaService
    {
        public IEnumerable<RelatorioDto> GetRelatorio(string dt_auditoriaInicial,string dt_auditoriaFinal)
        {
            StringBuilder qry = new StringBuilder();

            qry.AppendFormat(@"SELECT vw.nm_paciente, 
                                vw.dt_auditoria
                                FROM dbahmv.vw_auditoria_operacional vw
                                WHERE vw.dt_auditoria >= to_date('{0}','DD/MM/YYYY') 
                                AND vw.dt_auditoria <= to_date('{1}','DD/MM/YYYY')", 
                                dt_auditoriaInicial, dt_auditoriaFinal);

            IQuery query = ObjectFactory.GetInstance<IUnitOfWork>().CurrentSession.CreateSQLQuery(qry.ToString())     
                     .AddScalar("nm_paciente", NHibernateUtil.String)
                     .AddScalar("dt_auditoria", NHibernateUtil.String)
                     ;

            query.SetResultTransformer(Transformers.AliasToBean(typeof(RelatorioDto)));
            return query.List<RelatorioDto>();



        }
    }
}
