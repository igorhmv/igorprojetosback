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

            qry.AppendFormat(@"SELECT *
                                FROM dbahmv.vw_auditoria_operacional vw
                                WHERE vw.dt_auditoria >= to_date('{0}','DD/MM/YYYY') 
                                AND vw.dt_auditoria <= to_date('{1}','DD/MM/YYYY')", 
                                dt_auditoriaInicial, dt_auditoriaFinal);

            IQuery query = ObjectFactory.GetInstance<IUnitOfWork>().CurrentSession.CreateSQLQuery(qry.ToString())     
                     .AddScalar("nm_paciente", NHibernateUtil.String)
                     .AddScalar("cd_atendimento", NHibernateUtil.String)
                     .AddScalar("cd_reg_fat", NHibernateUtil.String)
                     .AddScalar("cd_reg_amb", NHibernateUtil.String)
                      .AddScalar("cd_gru_fat", NHibernateUtil.String)
                       .AddScalar("cd_pro_fat", NHibernateUtil.String)
                       .AddScalar("ds_pro_fat", NHibernateUtil.String)
                       .AddScalar("ds_motivo_auditoria", NHibernateUtil.String)
                       .AddScalar("tipo_auditoria", NHibernateUtil.String)
                       .AddScalar("nm_setor", NHibernateUtil.String)
                       .AddScalar("qt_lancamento_ant",NHibernateUtil.Int32)
                       .AddScalar("qt_lancamento", NHibernateUtil.Int32)
                       .AddScalar("qt_total_ajustado", NHibernateUtil.Int32)
                       .AddScalar("vl_total_conta_ant",NHibernateUtil.Double)
                       .AddScalar("vl_total_conta", NHibernateUtil.Double)
                       .AddScalar("exclusaoxinclusao", NHibernateUtil.Double)
                       .AddScalar("nm_usuario", NHibernateUtil.String)
                       .AddScalar("cd_usuario", NHibernateUtil.String)
                       .AddScalar("setor_usuario", NHibernateUtil.String)
                       .AddScalar("dt_auditoria", NHibernateUtil.String)
                       .AddScalar("acao", NHibernateUtil.String)
                     ;

            query.SetResultTransformer(Transformers.AliasToBean(typeof(RelatorioDto)));
            return query.List<RelatorioDto>();



        }
    }
}
