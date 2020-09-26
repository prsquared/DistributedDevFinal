using GameLibrary.EntityFrameworkDataAccess;
using GameLibrary.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.Logic
{
    public abstract class BaseLogic<Poco> where Poco : IPoco
    {
        protected EFGenericRepository<Poco> _repository;
        public BaseLogic(EFGenericRepository<Poco> repository)
        {
            _repository = repository;
        }

        protected virtual void Validate(Poco[] pocos)
        {
            return;
        }

        public virtual Poco Get(Guid id)
        {
            return _repository.GetSingle(c => c.Id == id);
        }

        public virtual List<Poco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual void Create(Poco[] pocos)
        {
            foreach (Poco poco in pocos)
            {
                if (poco.Id == Guid.Empty)
                {
                    poco.Id = Guid.NewGuid();
                }
            }

            _repository.Add(pocos);
        }

        public virtual void Update(Poco[] pocos)
        {
            _repository.Update(pocos);
        }

        public void Delete(Poco[] pocos)
        {
            _repository.Remove(pocos);
        }
    }
}
