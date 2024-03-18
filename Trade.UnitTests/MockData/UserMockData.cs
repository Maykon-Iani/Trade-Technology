using MongoDB.Bson;
using Trade.Domain.Entities;

namespace Trade.UnitTests.MockData
{
    public class UserMockData
    {
        public static List<User> GetUsersData()
        {
            List<User> usersData =
        [
            new() {
                Id = ObjectId.GenerateNewId(),
                Email = "testeUser@gmail.com",
                Password = "123"

            },
             new() {
               Id = ObjectId.GenerateNewId(),
                Email = "testeUser2@gmail.com",
                Password = "12345"
            },
        ];
            return usersData;
        }
    }
}
