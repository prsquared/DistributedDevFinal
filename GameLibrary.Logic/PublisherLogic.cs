using GameLibrary.EntityFrameworkDataAccess;
using GameLibrary.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.Logic
{
    public class PublisherLogic : BaseLogic<PublisherPoco>
    {
        public PublisherLogic(EFGenericRepository<PublisherPoco> repository) : base(repository)
        {

        }

        public override PublisherPoco Get(Guid id)
        {
            return _repository.Get(c => c.Id == id, x => x.Developers);
        }

        public override List<PublisherPoco> GetAll()
        {
            return _repository.GetAll(x => x.Developers).ToList();
        }
        public override void Create(PublisherPoco[] pocos)
        {
            Validate(pocos);
            base.Create(pocos);
        }
        public override void Update(PublisherPoco[] pocos)
        {
            Validate(pocos);
            base.Update(pocos);
        }
        protected override void Validate(PublisherPoco[] pocos)
        {
            List<Exception> exceptionList = new List<Exception>();
            foreach (PublisherPoco poco in pocos)
            {
                if (poco.Name == null)
                {
                    exceptionList.Add(new Exception("Publisher Name can't be empty"));
                }
                else if (poco.Name.Length > 50)
                {
                    exceptionList.Add(new Exception("Publisher Name too long"));
                }
                else if (poco.Description != null && poco.Description.Length > 300)
                {
                    exceptionList.Add(new Exception("Publisher Description too long"));
                }
            }
            if (exceptionList.Count > 0)
            {
                throw new AggregateException(exceptionList);
            }
        }
    }
}
