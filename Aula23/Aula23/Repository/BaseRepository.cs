using Aula23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula23.Repository
{
    public abstract class BaseRepository<T> where T : BaseModels
    {
        static List<T> lista = new List<T>();
        static int id = 1;
        
        public void Create(T model)
        {
            model.Id = id;
            lista.Add(model);
            id++;
        }
        public List<T> Read()
        {
            return lista;
        }
        public T Read(int id)
        {
            return lista.Find(t => t.Id == id);
        }
        public void Update(T model)
        {
            int index = lista.FindIndex(t => t.Id == model.Id);
            if(index != -1)
            {
                lista[index] = model;
            }
        }
        public void Delete(int id)
        {
            T model = Read(id);
            if(model != null)
            {
                lista.Remove(model);
            }
        }
    }
}