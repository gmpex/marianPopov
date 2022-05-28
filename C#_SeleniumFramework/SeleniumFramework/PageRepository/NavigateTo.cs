using SeleniumFramework.Utils;

namespace SeleniumFramework.PageRepository
{
    public static class NavigateTo
    {
        public static HomePage homePage
        {
            get
            {
                var _homePage = new HomePage(DriverUtil.driver);
                return _homePage;
            }
        }

        public static LoginPage loginPage
        {
            get
            {
                var _loginPage = new LoginPage(DriverUtil.driver);
                return _loginPage;
            }
        }

        public static DeliverySitesPage deliverySitesPage
        {
            get
            {
                var _deliverySitesPage = new DeliverySitesPage(DriverUtil.driver);
                return _deliverySitesPage;
            }
        }
    }
}
