using System.Data;
using DataAccess.Command;
using DataAccess.Interfaces;
using Moq;
using NUnit.Framework;

namespace DataAccess.Unit.Tests
{
    [TestFixture]
    public class DatabaseCommandInstanceProviderTest
    {
        private Mock<IDatabaseConnectionProvider> _connectionProvider;
        private Mock<IDbConnection> _connection;
        private DatabaseCommandProvider _databaseCommandInstaceProvider;
        private Mock<ITransactionManager> _transactionManager;

        [SetUp]
        public void SetUp()
        {
            _connectionProvider = new Mock<IDatabaseConnectionProvider>();
            _connection = new Mock<IDbConnection>();
            _connectionProvider.Setup(x => x.GetOpenConnection()).Returns(_connection.Object);
            _transactionManager = new Mock<ITransactionManager>();
            _databaseCommandInstaceProvider = new DatabaseCommandProvider(_connectionProvider.Object, _transactionManager.Object);
        }

        [Test]
        public void ShouldCreateNewCommandForConnection()
        {
            //When
            _databaseCommandInstaceProvider.CreateCommandForCurrentConnection();

            //Then
            _connectionProvider.Verify(x => x.GetOpenConnection(), Times.Once());
        }
    }
}