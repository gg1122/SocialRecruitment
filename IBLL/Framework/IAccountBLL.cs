using System;
namespace Langben.IBLL
{
    public partial interface IAccountBLL
    {
        Common.Account Register(string name, string phoneNumber, string password, string inviteCode, ref string message);
        bool ChangePassword(string personName, string oldPassword, string newPassword);
        Langben.DAL.Account ValidateUser(string userName, string password);
    }
}
