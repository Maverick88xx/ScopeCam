using ScopeCam.UserStoriesScreens.MainScreen.View.Interfaces;
using ScopeCam.UserStoriesScreens.MainScreen.Models;

namespace ScopeCam.UserStoriesScreens.MainScreen.Presenter
{
    public class PaymentDBPresenter
    {
        IPaymentDB mainView;

        public PaymentDBPresenter(IPaymentDB view)
        {
            mainView = view;
        }

        public void FindLPNumberInDB()
        {
            PaymentDBManager paymentDBManager = new PaymentDBManager
            {
                DatabaseConnection = mainView.DatabaseConnection,
                RecognizedLPNumber = mainView.RecognizedLPNumberText
            };

            if (paymentDBManager.FindLPNumberInDB() == true)
            {
                mainView.OpenTheBarrier();
            }
        }
    }
}
