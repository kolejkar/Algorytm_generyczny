using Generyczny;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.Unit
{
    public class PopulacjaTestSuite
    {
        [Theory]
        [MemberData(nameof(MappingData))]
        public void Schould_mapping_cities(int[,] a, int r1, int r2, int r3, int r4, int r5, int r6)
        {
            //Arrange
            Populacja populacja = new Populacja();

            //int[,] map = { {5, 6, 1}, {6, 2, 4} };

            //Act
            var sur = populacja.Sort(a);

            //Assert
            Assert.Equal(r1, sur[0, 0]);
            Assert.Equal(r2, sur[1, 0]);

            Assert.Equal(r3, sur[0, 1]);
            Assert.Equal(r4, sur[1, 1]);

            Assert.Equal(r5, sur[0, 2]);
            Assert.Equal(r6, sur[1, 2]);
        }

        public static IEnumerable<object[]> MappingData =>
        new List<object[]>
        {
            new object[] { new int[,] { {5, 6, 1}, {6, 2, 4} }, 5, 2, 1, 4, 0, 0 },
            new object[] { new int[,] { {6, 5, 1}, {2, 6, 4} }, 5, 2, 1, 4, 0, 0 },
            new object[] { new int[,] { {6, 1, 5}, {2, 4, 6} }, 5, 2, 1, 4, 0, 0 },
            new object[] { new int[,] { {2, 6, 7}, {3, 6, 2} }, 7, 3, 6, 6, 0, 0 },
            new object[] { new int[,] { {2, 6, 7}, {3, 6, 4} }, 2, 3, 6, 6, 7, 4 },
        };

        [Theory]
        [MemberData(nameof(CompeteData))]
        public void Schould_mapping_complete(int[] kan, int[,] map, int r1, int  r2, int r3, int r4)
        {
            //Arrange
            Populacja populacja = new Populacja();
            //int[] kan = { 3, 7, 6, 4, 2, 1, 7 };
            //int[,] map = { { 2, 1, 7 }, { 2, 1, 5 } };

            //Act
            var sur = populacja.Mapping(kan, map);

            //Assert
            Assert.Equal(r1, sur[0]);
            Assert.Equal(r2, sur[1]);
            Assert.Equal(r3, sur[2]);
            Assert.Equal(r4, sur[3]);
        }

        public static IEnumerable<object[]> CompeteData =>
        new List<object[]>
        {
            new object[] {new int[] { 3, 7, 6, 4, 2, 1, 7 }, new int[,] { { 2, 1, 7 }, { 2, 1, 5 } }, 3, 5, 6, 4 },
            new object[] {new int[] { 1, 3, 5, 4, 4, 1, 7 }, new int[,] { { 6, 2, 7 }, { 4, 1, 7 } }, 2, 3, 5, 6 }
        };
    }
}
