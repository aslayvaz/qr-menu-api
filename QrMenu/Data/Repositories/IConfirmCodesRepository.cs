using QrMenu.Models.ConfirmCode;

namespace QrMenu.Data.Repositories
{
    public interface IConfirmCodesRepository
	{
        Task<ConfirmCode> GetConfirmCode(string userId);
        Task<ConfirmCode> InsertConfirmCode(ConfirmCode confirmCode);
    }
}

