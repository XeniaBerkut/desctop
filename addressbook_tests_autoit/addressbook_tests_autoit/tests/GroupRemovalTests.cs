using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemove()
        {
            int k = app.Groups.GetGroupList().Count;
            if (k < 2)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "ForDelete"
                };

                for (int i = 2 - k; i < 2; i++)
                {
                    app.Groups.Add(newGroup);
                }                
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData group = oldGroups.First();
            app.Groups.Remove(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
