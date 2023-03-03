using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquiteturaBase.application.Dto
{
    public class RelatorioDto
    {
        public string nm_paciente { get; set; }
        public string nm_convenio { get; set; }
        public string cd_atendimento { get; set; }
        public string cd_reg_fat { get; set; }
        public string cd_reg_amb { get; set; }
        public string cd_gru_fat { get; set; }
        public string cd_pro_fat { get; set; }
        public string ds_pro_fat { get; set; }
        public string ds_motivo_auditoria { get; set; }
        
        
        public string tipo_auditoria { get; set; }
        public string nm_setor { get; set; }
        public int qt_lancamento_ant { get; set; }
        public int qt_lancamento { get; set; }
        public int qt_total_ajustado { get; set; }
        
        public double vl_total_conta_ant { get; set; }
        public double vl_total_conta { get; set; }
        public double exclusaoxinclusao { get; set; }

        public string nm_usuario { get; set; }
        public string cd_usuario { get; set; }
        public string setor_usuario { get; set; }

        public string dt_auditoria { get; set; }

        public string acao { get; set; }

    }
}
