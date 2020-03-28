﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Banco.Busca
{
    public class GeradorDeDevedores
    {
        public ICollection<string> GeraLista()
        {
            List<string> nomes = new List<string>();
            for (int i = 0; i < 30000; i++)
            {
                nomes.Add($"Devedor {i}");
            }
            return nomes;
        }
    }
}
