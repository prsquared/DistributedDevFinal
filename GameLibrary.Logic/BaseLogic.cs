using GameLibrary.EntityFrameworkDataAccess;
using GameLibrary.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.Logic
{
    public abstract class BaseLogic<TPoco> where TPoco : IPoco
    {
        protected IDataRepository<TPoco> _repository;
        public BaseLogic(IDataRepository<TPoco> repository)
        {
            _repository = repository;
        }

        protected virtual void Validate(TPoco[] pocos)
        {
            return;
        }

        public virtual TPoco Get(Guid id)
        {
            return _repository.Get(c => c.Id == id);
        }

        public virtual List<TPoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual void Create(TPoco[] pocos)
        {
            foreach (TPoco poco in pocos)
            {
                if (poco.Id == Guid.Empty)
                {
                    poco.Id = Guid.NewGuid();
                }
            }

            _repository.Create(pocos);
        }

        public virtual void Update(TPoco[] pocos)
        {
            _repository.Update(pocos);
        }

        public void Delete(TPoco[] pocos)
        {
            _repository.Remove(pocos);
        }
    }
}
