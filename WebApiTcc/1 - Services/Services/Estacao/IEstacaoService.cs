﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Estacao
{
    public interface IEstacaoService
    {
        IEnumerable<Estacao> GetAll();
        Estacao Post(Estacao estacao);
        Estacao GetById(int id);
        Estacao Put(Estacao estacao);
        void Delete(int idEstacao);
    }
}
