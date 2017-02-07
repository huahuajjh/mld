using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLD.Entity;
using MLD.Library.Constant;
using MLD.Library.DI;

namespace MLD.UnitTest
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestAdd()
        {
            var ir = Di.GetInstance<IRepository.IRepository>(DiKey.DALKEY, true);
            for (int i = 0; i < 8; i++)
            {
                var user = new TbUser()
                {
                    Del = false,
                    Id = 0,
                    Name = "jjh3"+i,
                    Pwd = "123",
                    UserTel = (18712131210 + i).ToString(),
                    Birthday = DateTime.Parse("1989-09-13"),
                    BuyClassNum = 10,
                    CostClassNum = 0,
                    Gender = true,
                    Remarks = "remarks",
                    Validity = 2
                };
                ir.GetReposirotyFactory<TbUser>().Entity.Add(user);
            }
            
            //ir.SaveChange();
        }

        [TestMethod]
        public void TestQuery()
        {
            var ir = Di.GetInstance<IRepository.IRepository>(DiKey.DALKEY, true);
            int count = 0;
            var user = ir.GetReposirotyFactory<TbUser>().Entity.QueryByPage<int>(null,
                a=>a.Id>0,f=>f.Id,4,2,out count);
            foreach (var tbUser in user)
            {
                Console.WriteLine(tbUser.Name);
            }
        }

        [TestMethod]
        public void TestDel()
        {
            var ir = Di.GetInstance<IRepository.IRepository>(DiKey.DALKEY, true);
            ir.GetReposirotyFactory<TbUser>().Entity.Delete(1);
            ir.SaveChange();
        }

        [TestMethod]
        public void TestModify()
        {
            var ir = Di.GetInstance<IRepository.IRepository>(DiKey.DALKEY, true);
            var entity = ir.GetReposirotyFactory<TbUser>().Entity;
            var user = entity.Query(2);
            user.Name = "ls";
            ir.SaveChange();
        }


    }
}
