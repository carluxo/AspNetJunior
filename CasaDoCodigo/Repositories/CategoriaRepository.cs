using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task Salvar(string nome)
        {
            if (ObterPeloNome(nome) == null)
            {
                dbSet.Add(new Categoria(nome));
            }

            await contexto.SaveChangesAsync();
        }

        public Categoria ObterPeloNome(string nome)
        {
            return dbSet.Where(c => c.Nome == nome).SingleOrDefault();
        }
    }
}
