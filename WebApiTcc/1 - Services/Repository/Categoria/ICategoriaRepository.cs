﻿using System.Collections.Generic;

namespace Data.Repository.Categoria
{
    public interface ICategoriaRepository
    {
        IEnumerable<Services.Categoria.Categoria> GetAll();
        Services.Categoria.Categoria Post(Services.Categoria.Categoria categoria);
        Services.Categoria.Categoria GetById(int idCategoria);
        Services.Categoria.Categoria Put(Services.Categoria.Categoria categoria);
        void Delete(int id);
    }
}
