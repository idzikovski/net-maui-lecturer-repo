using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using RealEstate.Interfaces;
using RealEstate.ViewModels;

namespace RealEstate.UnitTests
{
    public class LoginViewModelTests
    {
        private LoginViewModel _sut;
        private Interfaces.IPreferences _preferences;

        [SetUp]
        public void Setup()
        {
            _preferences = Substitute.For<Interfaces.IPreferences>();
            _preferences.Get(LoginViewModel.IsLoggedInKey, false).Returns(false);

            _sut = new LoginViewModel(_preferences);

        }

        [Test]
        public void WhenWrongPasswordIsProvided_ErrorLabelIsShown()
        {
            
            _sut.Username = "Ivan";
            _sut.Password = "WrongPassword";

            _sut.LoginCommand.Execute(null);

            _sut.LoginErrorPresent.Should().BeTrue();
        }
    }
}
