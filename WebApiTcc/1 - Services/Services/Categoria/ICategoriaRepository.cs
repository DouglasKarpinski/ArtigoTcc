using System.Collections.Generic;

namespace Data.Services.Categoria
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetAll();
        Categoria Post(Categoria categoria);
        Categoria GetById(int idCategoria);
        Categoria Put(Categoria categoria);
        void Delete(int id);
    }
}
