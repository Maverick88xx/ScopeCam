using System.Data.OleDb;

namespace ScopeCam.UserStoriesScreens.MainScreen.View.Interfaces
{
    public interface IPaymentDB
    {
        // Properties
        string RecognizedLPNumberText { get; }
        OleDbConnection DatabaseConnection { get; }

        //Methods
        void OpenTheBarrier();
    }
}
