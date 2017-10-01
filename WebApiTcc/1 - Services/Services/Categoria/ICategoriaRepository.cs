using System.Collections.Generic;

namespace Repository.Repository.Categoria
{
    public interface ICategoriaRepository
    {
        IEnumerable<Data.Services.Categoria.Categoria> GetAll();
        Data.Services.Categoria.Categoria Post(Data.Services.Categoria.Categoria categoria);
        Data.Services.Categoria.Categoria GetById(int idCategoria);
        Data.Services.Categoria.Categoria Put(Data.Services.Categoria.Categoria categoria);
        void Delete(int id);
    }
}
