﻿using PedidoService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Services.Preparos
{
    public interface IPreparoManager
    {
        Preparo BuscaPorId(int id);
        IEnumerable<Preparo> BuscaTodos();
    }
}