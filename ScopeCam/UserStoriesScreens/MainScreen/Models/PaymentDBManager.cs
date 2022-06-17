using System;

using System.Data.OleDb;

namespace ScopeCam.UserStoriesScreens.MainScreen.Models
{
    public class PaymentDBManager
    {
        public OleDbConnection DatabaseConnection { get; set; }
        public string RecognizedLPNumber { get; set; }

        private bool isLPNumberFound = false;

        private string currentDate = DateTime.Now.ToString(UserStoriesGeneralConstants.kMainDateFormat);

        // Фіксована плата за користування парковкою протягом одного дня
        private const int kParkingDayFee = 20;

        public bool FindLPNumberInDB()
        {
            // Розпочати підключення до БД
            DatabaseConnection.Open();

            string fetchLPNumbersQuery = "SELECT Number_car FROM Paid WHERE Balance>=" + 
                                         kParkingDayFee                                + 
                                         " OR Last_payment='"                          + 
                                         currentDate                                   + 
                                         "'";

            // Зробити запит вибірки до БД
            OleDbCommand fetchLPNumbersCommand = new OleDbCommand(fetchLPNumbersQuery, DatabaseConnection);

            // Змінна для зчитування потоку данних із джерела тільки в прямому порядку
            OleDbDataReader lpNumbersDBReader;

            // Присвоєння зчитування, буде утримувати відкритим з’єднання 
            // з БД поки воно не буде закрите явним способом
            lpNumbersDBReader = fetchLPNumbersCommand.ExecuteReader();

            // Цикл для зчитування данних
            while (lpNumbersDBReader.Read())
            {
                // Якщо розпізнаний номер є у БД сплачених номерів, то -
                if (lpNumbersDBReader.GetString(0).ToString() == RecognizedLPNumber)
                {
                    // Queries
                    string updatePaidBalanceQuery = "UPDATE Paid SET Balance = Balance - " + 
                                                    kParkingDayFee                         + 
                                                    " WHERE Number_car='"                  + 
                                                    RecognizedLPNumber                     + 
                                                    "' AND Last_payment<>'"                + 
                                                    currentDate                            + 
                                                    "'";

                    string updatePaidLastPaymentQuery = "UPDATE Paid SET Last_payment ='" + 
                                                        currentDate                       + 
                                                        "' WHERE Number_car='"            + 
                                                        RecognizedLPNumber                + 
                                                        "'";

                    string updatePaymentHistoryPaymentTotalQuery = "UPDATE Payment_history SET Payment_total = Payment_total + " + 
                                                                    kParkingDayFee                                               + 
                                                                    " WHERE Number_car='"                                        + 
                                                                    RecognizedLPNumber                                           + 
                                                                    "' AND Last_payment<>'"                                      + 
                                                                    currentDate                                                  + 
                                                                    "'";

                    string updatePaymentHistoryLastPaymentQuery = "UPDATE Payment_history SET Last_payment ='" + 
                                                                  currentDate                                  + 
                                                                  "' WHERE Number_car='"                       + 
                                                                  RecognizedLPNumber                           + 
                                                                  "'";
                    // end Queries


                    // DB Commands
                    OleDbCommand updatePaidBalanceCommand                = new OleDbCommand(updatePaidBalanceQuery,                DatabaseConnection);
                    OleDbCommand updatePaymentHistoryPaymentTotalCommand = new OleDbCommand(updatePaymentHistoryPaymentTotalQuery, DatabaseConnection);
                    OleDbCommand updatePaidLastPaymentCommand            = new OleDbCommand(updatePaidLastPaymentQuery,            DatabaseConnection);
                    OleDbCommand updatePaymentHistoryLastPaymentCommand  = new OleDbCommand(updatePaymentHistoryLastPaymentQuery,  DatabaseConnection);
                    // end DB Commands

                    OleDbDataReader updateLPDbReader;

                    updateLPDbReader = updatePaidBalanceCommand.ExecuteReader();
                    updateLPDbReader.Read();

                    updateLPDbReader = updatePaymentHistoryPaymentTotalCommand.ExecuteReader();
                    updateLPDbReader.Read();

                    updateLPDbReader = updatePaidLastPaymentCommand.ExecuteReader();
                    updateLPDbReader.Read();

                    updateLPDbReader = updatePaymentHistoryLastPaymentCommand.ExecuteReader();
                    updateLPDbReader.Read();

                    updateLPDbReader.Close();

                    isLPNumberFound = true;

                    break;
                }
            }

            // Закрити потік для зчитування
            lpNumbersDBReader.Close();

            // Закрити з’єднання з БД
            DatabaseConnection.Close();

            return isLPNumberFound;
        }
    }
}
