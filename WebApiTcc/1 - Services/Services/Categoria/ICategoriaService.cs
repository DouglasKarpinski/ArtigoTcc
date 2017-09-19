using System.Collections.Generic;

namespace Data.Services.Categoria
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetAll();
        Categoria Post(Categoria categoria);
        Categoria GetById(int idCategoria);
    }
}
