using MongoDB.Driver;
using QrMenu.Models.ConfirmCode;
using QrMenu.Models.Restaurant;

namespace QrMenu.Data.Repositories
{
    public class ConfirmCodesRepository: IConfirmCodesRepository
    {
        private readonly IMongoCollection<ConfirmCode> confirmCodes;

        public ConfirmCodesRepository(IMongoDatabase database)
		{
            confirmCodes = database.GetCollection<ConfirmCode>("confirmationCodes");
        }
        public async Task<ConfirmCode> GetConfirmCode(string userId)
        {
            var confirmCode = await confirmCodes.Find(u => u.UserId == userId).FirstOrDefaultAsync();

            if (confirmCode is null) return null;

            return confirmCode;
            
        }

        public async Task<ConfirmCode> InsertConfirmCode(ConfirmCode confirmCode)
        {
            try
            {
                await confirmCodes.InsertOneAsync(confirmCode);
            }
            catch(Exception err)
            {
                Console.WriteLine(err.ToString());
                return null;
            }
            return confirmCode;
        }
    }
}

