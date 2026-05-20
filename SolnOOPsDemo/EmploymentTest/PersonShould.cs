using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using OOPsDemo;

namespace EmploymentTest
{
    public class PersonShould
    {
        #region valid test cases
        //a Fact unit test excutes once
        //without the [Fact] annotation, the method is NOT considered a unit test
        [Fact]
        public void Successfully_Create_An_Instance_Using_The_Default_Constructor()
        {
            //Arrange (this is the setup of values need for doing the test)
            string expectFirstName = "unknown";
            string expectLastName = "unknown";
            int expectedEmploymentPositionCount = 0;

            //Act (this is the action that is under testing)
            //sut: subject under test

            Person sut = new Person();


            // //Assert (check the results of the act against expected Values)

            sut.FirstName.Should().Be(expectFirstName);
            sut.LastName.Should().Be(expectLastName);
            sut.Employmentpositions.Count().Should().Be(expectedEmploymentPositionCount);
            sut.Address.Should().BeNull();

        }

        [Fact]
        public void Successfully_Create_An_Instance_Using_The_Greedy_Constructor()
        { }

        #endregion










    }
}
