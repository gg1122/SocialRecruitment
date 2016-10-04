using System;
namespace Langben.IBLL
{
    public partial interface IAccountBLL
    {
        bool ChangePassword(string personName, string oldPassword, string newPassword);
        Langben.DAL.Account ValidateUser(string userName, string password);
    }
}
