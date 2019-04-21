using Forum.Core.Entities;
using Forum.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Connection.Services
{
    public class ThemeService
    {
        public TestDatabase TestDb;

        public ThemeService()
        {
            TestDb = new TestDatabase();
        }

        public bool Create(string name, string description, int forumId)
        {
            //тут проверяем, есть ли тип данных с названием Theme в системе учёта, то есть посылаем запрос с проверкой
            if (!TestDb.EntityTypes.Contains("Theme"))
            {
                //если нет, то создаем, добавляем нужные поля
                TestDb.EntityTypes.Add("Theme");
            }

            if (!TestDb.EntityTypes.Contains("Theme"))
            {
                return false;
            }

            //после чего добавляем уже сам экзепляр Темы с нужным нам названием и описанием
            try
            {
                TestDb.Themes.Add(new Theme(name, description, forumId));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
