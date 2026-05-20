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
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);
            sut.Address.Should().BeNull();

        }

        [Fact]
        public void Successfully_Create_An_Instance_Using_The_Greedy_Constructor()
        {
            //Arrange (this is the setup of values need for doing the test)
            string expectFirstName = "Baljeet";
            string expectLastName = "Kaur";
            int expectedEmploymentPositionCount = 0;

            //Act (this is the action that is under testing)
            //sut: subject under test

            Person sut = new Person("Baljeet","Kaur", null,null);


            // //Assert (check the results of the act against expected Values)

            sut.FirstName.Should().Be(expectFirstName);
            sut.LastName.Should().Be(expectLastName);
            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);
            sut.Address.Should().BeNull();




        }

        #endregion

        #region Testing Methods
        // add new Employment test method

        [Fact]
        public void Add_new_employment_to_the_collection()
        {
            // arrange
            Employment one = new Employment("HL 1", SupervisoryLevel.TeamLeader, DateTime.Parse("2024/10/10"), 7.8);
            Employment two = new Employment("PG II", SupervisoryLevel.TeamLeader, DateTime.Parse("2020/04/04"), 4.5);

            List<Employment> employments  = new List<Employment>();
            employments.Add(one);
            employments.Add(two);

            Person sut = new Person("Baljeet", "Kaur", null, employments);
            
            //build expect new employment
            Employment three = new Employment("SUP I", SupervisoryLevel.Supervisor,
                               DateTime.Today);

            //reuse the current collection and add the new expected employment
            //employments.Add(three);

            //another way of setting up the expected employment collect is to
            //  create a second list and add all employments to the second list
            List<Employment> expectedEmployments = new List<Employment>();
            expectedEmployments.Add(one);
            expectedEmployments.Add(two);
            expectedEmployments.Add(three);

            int expectedEmploymentPositionCount = 3;
            // act
            sut.AddEmployment(three);

            // assert

            sut.EmploymentPositions.Count().Should().Be(expectedEmploymentPositionCount);



        }


        #endregion










    }
}
