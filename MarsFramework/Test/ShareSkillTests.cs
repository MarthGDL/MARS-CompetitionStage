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
                Profile ProfilePage = new Profile();
                ProfilePage.GoToShareSkill();

                //Check if the user is able to fill the "Share-Skill" details
                ShareSkill ShareSkillPage = new ShareSkill();
                ShareSkillPage.FillShareSkill(2);

                //Check if the user is able to see the Skill in the "Manage Listing" page
                ManageListings ManageListingPage = new ManageListings();
                ManageListingPage.CheckListing(2);

            }

            [Test]//Test Case 012
            [Category("TC-012")]
            public void EditShareSkill()
            {
                //Check if the user is able to access the "Share-Skill" function
                Profile ProfilePage = new Profile();
                ProfilePage.GoToManageListing();

                //Check if the user is able to access the "Share-Skill" function
                ManageListings ManageListingPage = new ManageListings();
                ManageListingPage.EditListing();

                //Check if the user is able to fill the Edit "Share-Skill" details
                ShareSkill ShareSkillPage = new ShareSkill();
                ShareSkillPage.EditShareSkill(3);

                //Check if the changes can be seen in the "Manage Listage
                ManageListings CheckListPage =new ManageListings();
                CheckListPage.CheckListing(3);
            }

            [Test]//Test Case 013
            [Category("TC-013")]
            public void EraseShareSkill()
            {
                //Check if the user is able to access the "ManageListing" page
                Profile ProfilePage = new Profile();
                ProfilePage.GoToManageListing();

                //Check if the user is able to delete the last entry of the "ManageListing" page
                ManageListings ManageListingPage = new ManageListings();
                ManageListingPage.DeleteListing();

                //Check if the changes can be seen in the "Manage Listing" page
                ManageListingPage.CompareLastEntry();

            }

        }
    }
}
