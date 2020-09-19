using MarsFramework.Pages;
using NUnit.Framework;
using System.Threading;

namespace MarsFramework.Test
{
    class ShareSkillTests
    {
        [TestFixture]
        class User : Global.Base
        {

            [Test]//Test Case 006
            [Category("TC-006")]
            public void AddShareSkill()
            {
                //Check if the user is able to access the "Share-Skill" function
                Thread.Sleep(5000);
                Profile ProfilePage = new Profile();
                ProfilePage.GoToShareSkill();

                //Check if the user is able to fill the "Share-Skill" details
                Thread.Sleep(3000);
                ShareSkill ShareSkillPage = new ShareSkill();
                ShareSkillPage.AddShareSkill();

            }

            [Test]//Test Case 012
            [Category("TC-012")]
            public void EditShareSkill()
            {
                //Check if the user is able to access the "Share-Skill" function
                Thread.Sleep(5000);
                Profile ProfilePage = new Profile();
                ProfilePage.GoToManageListing();

                //Check if the user is able to access the "Share-Skill" function
                Thread.Sleep(3000);
                ManageListings ManageListingPage = new ManageListings();
                ManageListingPage.EditListing();

                //Check if the user is able to fill the Edit "Share-Skill" details
                Thread.Sleep(3000);
                ShareSkill ShareSkillPage = new ShareSkill();
                ShareSkillPage.AddShareSkill();

            }

            [Test]//Test Case 013
            [Category("TC-013")]
            public void EraseShareSkill()
            {
                //Check if the user is able to access the "ManageListing" function
                Thread.Sleep(5000);
                Profile ProfilePage = new Profile();
                ProfilePage.GoToManageListing();

                //Check if the user is able to access the "ManageListing" function
                Thread.Sleep(3000);
                ManageListings ManageListingPage = new ManageListings();
                ManageListingPage.DeleteListing();

            }

        }
    }
}
