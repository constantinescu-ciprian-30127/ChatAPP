using Chat_app_Client;
using System.Data;
using MySql.Data.MySqlClient;
using Xunit;
using Xunit.Sdk;
using XUnitPriorityOrderer; // am instalat XUnitPriorityOrderer

namespace TestProject1
{
    [TestCaseOrderer(CasePriorityOrderer.TypeName, CasePriorityOrderer.AssembyName)]
    public class UnitTest1
    {
        MySqlConnection conn;
        String username = "admin";
        String password = "admin";
        String ipAddress = "255.255.255.255:99999";


        [Fact, Order(1)]
        public void GetConnStringFromAppConfigTest()
        {
            
            string actualString = Account.connectionString;
            string expectedString = "Server=localhost;Database=proiect;Uid=root;Password=;";
            Assert.Equal(expectedString, actualString);
        }

        [Fact, Order(1)]
        public void ConnectAndDisconnectFromDatabaseTest()
        {
            conn = new MySqlConnection(Account.connectionString);
            conn.Open();
            ConnectionState connected = conn.State;
            conn.Close();
            ConnectionState disconnected = conn.State;
            Assert.Equal(ConnectionState.Open, connected);
            Assert.Equal(ConnectionState.Closed, disconnected);
        }
        
       


        [Fact, Order(2)]
        public void AddUserTest()
        {
            Assert.Equal(true, Account.addUser(username, password));
            Assert.Equal(false, Account.addUser(username, password));
        }

        [Fact, Order(3)]
        public void CheckUserPasswordTest()
        {
            String goodPassword = password;
            String badPassword = "1";
            Assert.Equal(true, Account.checkUser(username, goodPassword));
            Assert.Equal(false, Account.checkUser(username, badPassword));

        }

        [Fact, Order(3)]
        public void SearchUserTest()
        {
            Assert.Equal(true, Account.searchUser(username));
            Assert.Equal(false, Account.searchUser("ADMIN1"));
        }

        [Fact, Order(3)]
        public void UpdateUserIPTest()
        {
            Assert.Equal(true, Account.updateUserIP(username, ipAddress));
        }

        [Fact, Order(3)]
        public void UpdateIsLoggedTest()
        {
            Assert.Equal(true, Account.updateUserStatus(username, false));
            Assert.Equal(true, Account.updateUserStatus(username, true));
        }

        [Fact, Order(4)]
        public void GetAllLoggedUsersTest()
        {
            Dictionary<String, String> loggedUsers = new Dictionary<String, String>();
            loggedUsers.Add(username, ipAddress);
            Assert.Equal(loggedUsers.Keys, Account.getAllLoggedUsers().Keys);
            Assert.Equal(loggedUsers.Values, Account.getAllLoggedUsers().Values);
        }

        [Fact, Order(5)]
        public void GetUserIPByUserNameTest()
        {
            Assert.Equal(ipAddress, Account.getUserIPByUsername(username));
            Assert.Equal("", Account.getUserIPByUsername("ADMIN1"));
        }

        [Fact, Order(6)]
        public void GetUsernameByIPTest() 
        {
            Assert.Equal(username, Account.getUsernameByIP(ipAddress));
            Assert.Equal("", Account.getUsernameByIP("0.0.0.0:00000"));
        }

        [Fact, Order(7)]
        public void GetUserStatusTest()
        {
            Assert.Equal(true, Account.getUserStatus(username));
        }


        [Fact, Order(8)]
        public void RemoveUserTest()
        {
            Assert.Equal(true, Account.removeUser(username));
        }
    }
}