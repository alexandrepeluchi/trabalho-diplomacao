﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidoService.Models.Preparos
{
    public class CriaPreparoBindingModel
    {
        public string Observacao { get; set; }
        public DateTime DataPreparo { get; set; }
        public bool Status { get; set; }
    }
}
