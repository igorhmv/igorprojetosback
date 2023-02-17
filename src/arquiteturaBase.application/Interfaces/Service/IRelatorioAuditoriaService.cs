using arquiteturaBase.application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquiteturaBase.application.Interfaces.Service
{
    public interface IRelatorioAuditoriaService
    {
        IEnumerable<RelatorioDto> GetRelatorio(string dt_auditoriaInicial, string dt_auditoriaFinal);
    }
}
