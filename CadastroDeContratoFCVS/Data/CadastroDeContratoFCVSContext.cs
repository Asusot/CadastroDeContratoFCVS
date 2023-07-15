using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroDeContratoFCVS.Models;

namespace CadastroDeContratoFCVS.Data
{
    public class CadastroDeContratoFCVSContext : DbContext
    {
        public CadastroDeContratoFCVSContext (DbContextOptions<CadastroDeContratoFCVSContext> options)
            : base(options)
        {
        }

        public DbSet<CadastroDeContratoFCVS.Models.Contrato> Contrato { get; set; }
    }
}
