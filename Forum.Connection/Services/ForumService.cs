namespace Forum.Connection.Services
{
    using Forum.Core.Entities;
    using Forum.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    public class ForumService
    {
        public TestDatabase TestDb;

        public ForumService()
        {
            TestDb = new TestDatabase();
        }

        public bool Create(string name, string description)
        {
            //тут проверяем, есть ли тип данных с названием Forum в системе учёта, то есть посылаем запрос с проверкой
            if (!TestDb.EntityTypes.Contains("Forum"))
            {
                //если нет, то создаем, добавляем нужные поля
                TestDb.EntityTypes.Add("Forum");
            }

            if (!TestDb.EntityTypes.Contains("Forum"))
            {
                return false;
            }

            //после чего добавляем уже сам экзепляр форума с нужным нам названием и описанием
            try
            {
                TestDb.Forums.Add(new Forum(name, description));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(string name, string newName, string description)
        {
            //находим форум по названию, меняем информацию
            var index = TestDb.Forums.FindIndex(x => x.Name == name);
            if (index != -1)
            {
                TestDb.Forums[index] = new Forum(newName, description);
                return true;
            }
            return false;
        }

        public bool Delete(string name)
        {
            //находим форум по названию, удаляем его экземпляр
            try
            {
                var forum = TestDb.Forums.Find(x => x.Name == name);
                if (forum != null)
                {
                    TestDb.Forums.Remove(forum);
                }
                return false;
            }
            catch
            {
                return false;
            }


        }

        public Forum Get(string name)
        {
            //находим форум по названию, получаем его экземпляр
            return TestDb.Forums.Find(x => x.Name == name);
        }

        public Forum GetByName(string name)
        {
            var forum = TestDb.Forums.Find(x => x.Name == name);
            return forum;
        }

        public List<Forum> GetAllForums()
        {
            return TestDb.Forums;
        }
    }
}
