using GameLibrary.EntityFrameworkDataAccess;
using GameLibrary.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Logic
{
    public class GameLogic : BaseLogic<GamePoco>
    {
        public GameLogic(EFGenericRepository<GamePoco> repository) : base(repository)
        {

        }

        public override void Create(GamePoco[] pocos)
        {
            Validate(pocos);
            base.Create(pocos);
        }
        public override void Update(GamePoco[] pocos)
        {
            Validate(pocos);
            base.Update(pocos);
        }
        protected override void Validate(GamePoco[] pocos)
        {
            List<Exception> exceptionList = new List<Exception>();
            foreach (GamePoco poco in pocos)
            {
                if (poco.Name == null)
                {
                    exceptionList.Add(new Exception("Game Name can't be empty"));
                }
                else if (poco.Name.Length > 50)
                {
                    exceptionList.Add(new Exception("Game Name too long"));
                }
                else if (poco.Description != null && poco.Description.Length > 300)
                {
                    exceptionList.Add(new Exception("Game Description too long"));
                }
            }
            if (exceptionList.Count > 0)
            {
                throw new AggregateException(exceptionList);
            }
        }
    }
}
