﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.ConsultaSatisfacao
{
    public interface IConsultaSatisfacaoService
    {
        Retorno Get(int idEstacao, DateTime? dataInicial, DateTime? dataFinal);
    }
}