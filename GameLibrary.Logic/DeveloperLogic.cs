using GameLibrary.EntityFrameworkDataAccess;
using GameLibrary.Pocos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GameLibrary.Logic
{
    public class DeveloperLogic : BaseLogic<DeveloperPoco>
    {
        public DeveloperLogic(EFGenericRepository<DeveloperPoco> repository) : base(repository)
        {

        }
        public override DeveloperPoco Get(Guid id)
        {
            return _repository.Get(c => c.Id == id, x => x.Games);
        }

        public override List<DeveloperPoco> GetAll()
        {
            return _repository.GetAll(x => x.Games).ToList();
        }
        public override void Create(DeveloperPoco[] pocos)
        {
            Validate(pocos);
            base.Create(pocos);
        }
        public override void Update(DeveloperPoco[] pocos)
        {
            Validate(pocos);
            base.Update(pocos);
        }
        protected override void Validate(DeveloperPoco[] pocos)
        {
            List<Exception> exceptionList = new List<Exception>();
            foreach (DeveloperPoco poco in pocos)
            {
                if (poco.Name == null)
                {
                    exceptionList.Add(new Exception("Developer Name can't be empty"));
                }
                else if (poco.Name.Length > 50)
                {
                    exceptionList.Add(new Exception("Developer Name too long"));
                }
                else if (poco.Description != null && poco.Description.Length > 300)
                {
                    exceptionList.Add(new Exception("Developer Description too long"));
                }
            }
            if (exceptionList.Count > 0)
            {
                throw new AggregateException(exceptionList);
            }
        }
    }
}
