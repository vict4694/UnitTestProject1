using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateClassLibrary;

namespace DateUnitTestProject2
{
    [TestClass]
    public class UnitTestDate
    {
        UclDate aDate = new UclDate(2019, 2, 6);
        UclDate bDate = new UclDate(2018, 7, 5);
        UclDate cDate = new UclDate(2018, 1, 1);
        [TestMethod]
        public void TestMethod_DateConstructor()
        {
            UclDate xDate = new UclDate();
            Assert.IsNotNull(xDate, "UclDate Constructor is not working");
        }
        [TestMethod]
        public void GetYear_aDate()
        {
            //UclDate aDate = new UclDate(2019, 2, 6);
            int year = 2019;
            Assert.AreEqual(aDate.GetYear(), year);
        }
        [TestMethod]
        public void GetMonth_For_aDate()
        {
            //UclDate aDate = new UclDate(2019, 2, 6);
            Assert.AreEqual(aDate.GetMonth(), 2);
        }
        [TestMethod]
        public void GetDay_For_aDate()
        {
            Assert.AreEqual(aDate.GetDay(), 6);
        }
        [TestMethod]
        public void GetDay_For_bDate()
        {
            Assert.AreEqual(bDate.GetDay(), 5);
        }
        [TestMethod]
        public void Set_Year_Test()
        {
            int newYear = 2011;
            aDate.SetYear(newYear);
            Assert.AreEqual(aDate.GetYear(), 2011);
        }
        [TestMethod]
        public void Set_Month_Test()
        { //afhængig af GetMonth :(
            int oldDay = aDate.GetDay();
            int oldYear = aDate.GetYear();
            int newMonth;
            int oldMonth = aDate.GetMonth(); //måske bruge noget andet end aDate, for ikke at smadre senere tests?
            if (oldMonth != 11) //overkill, men sikrer sig, hvis det skal bruges på andre dates
            {
                newMonth = 11;
                aDate.SetMonth(newMonth);
            }
            else
            {
                newMonth = 12;
            }
            Assert.AreEqual(aDate.GetDay(), oldDay);
            Assert.AreEqual(aDate.GetYear(), oldYear);
            Assert.AreEqual(aDate.GetMonth(), newMonth); // bare 11 virker også.
        }

        [TestMethod]
        public void Set_Day_Test()
        {
            UclDate oldDate = aDate; //gem original
            int dayToSet = oldDate.GetDay();

            if (dayToSet == 1) //hvis dato = 1, så +1. Ellers -1
            {
                dayToSet += 1;
            }
            else
            {
                dayToSet -= 1;
            }

            aDate.SetDay(dayToSet);

            Assert.AreEqual(aDate.GetMonth(), oldDate.GetMonth()); //check om gamle er intakte
            Assert.AreEqual(aDate.GetYear(), oldDate.GetYear());
            Assert.AreEqual(aDate.GetDay(), dayToSet);
        }

        [TestMethod]
        public void GetDateStringYMD_Test()
        {
            Assert.AreEqual(aDate.GetDatoStringYMD(), "2019-02-06");
        }
        [TestMethod]
        public void GetDatoStringDMY_Test()
        {
            Assert.AreEqual("06-02-19", aDate.GetDatoStringDMY());
        }
        [TestMethod]
        public void GetQuater_Test()
        {
            Assert.AreEqual(aDate.GetQuater(), 1); //
        }
        [TestMethod]
        public void GetMonthTxt_Test()
        {
            Assert.AreEqual(aDate.GetMonthTxt(), "Februar");
        }
        [TestMethod]
        public void GetQuaterTxt_Test()
        {
            Assert.AreEqual(aDate.GetQuaterTxt(), "Januar kvartal"); //det hedder sgu da første kvartal
        }
        [TestMethod]
        public void MoveToNextDate_Test()
        {
            aDate.MoveToNextDate();
            Assert.AreEqual(aDate.GetDay(), 7);
        }
        [TestMethod]
        public void MoveToPrevDate_Test()
        {
            aDate.MoveToPrevDate();
            cDate.MoveToPrevDate();
            Assert.AreEqual(aDate.GetDay(), 5);
            Assert.AreEqual(cDate.GetDay(), 31);
        }
        [TestMethod]
        public void MoveDays_Positive_Numbers_Test()
        {
            aDate.MoveDays(2);
            Assert.AreEqual(aDate.GetDay(), 8);
            Assert.AreEqual(aDate.GetMonth(), 2);
            Assert.AreEqual(aDate.GetYear(), 2019);

        }
        [TestMethod]
        public void MoveDays_Negative_Numbers_Test()
        {
            aDate.MoveDays(-2);
            Assert.AreEqual(aDate.GetDay(), 4);
            Assert.AreEqual(aDate.GetMonth(), 2);
            Assert.AreEqual(aDate.GetYear(), 2019);
        }
        [TestMethod]
        public void GetDayNumber_Test() // kunne lave et +1 loop frem til aDate
        {
            UclDate firstDay = new UclDate(2019, 1, 2);
            UclDate lastDay = new UclDate(2018, 12, 31);
            Assert.AreEqual(firstDay.GetDayNumber(), 2);
            Assert.AreEqual(lastDay.GetDayNumber(), 365);

        }
        [TestMethod]
        public void GetDayNumber_FalseDate_Test()
        {
            UclDate falseLastDate = new UclDate(2019, 31, 12);
            Assert.AreEqual(falseLastDate.GetDayNumber(), 365);
        }
        [TestMethod]
        public void GetMonthTxt_FalseDate_Test()
        {
            UclDate falseLastDate = new UclDate(2019, 31, 12);
            Assert.AreEqual(falseLastDate.GetMonthTxt(), "måned #31");
        } // okay, så "GetDayNumber()" accepterer ulovlige datoer. ooog den bytter om på dato-format
        // på et tidspunkt. øøøh. 
        [TestMethod]
        public void SetDayNumber_First_Day_Test()
        {
            aDate.SetDayNumber(1991, 5);
            Assert.AreEqual(aDate.GetMonthTxt(), "Januar");
            Assert.AreEqual(aDate.GetDay(), 5);
        }
        [TestMethod]
        public void SetDayNumber_Last_Day_Test() //der må være en måned, der ikke eksisterer
        {
            aDate.SetDayNumber(1991, 365);
            Assert.AreEqual(aDate.GetMonth(), 12);
            Assert.AreEqual(aDate.GetDay(), 31);
        }
        [TestMethod]
        public void GetAbsDayNumber_Test()
        {
            //ej, nu gider jeg altså ikke mere i dag. Her er de sidste opgaver
            /*
            GetAbsDayNumber
            der returnere dagnr fra 1 / 1 år
             

            
GetWeekDay	
der returnere ugedagen for datoen som tal.
1=mandag, 2=tirsdag   osv.


            
GetWeek
der returnerer ugenr.
ugen "tilhører" det år hvori torsdagen falder.


                    int GetAbsDayNumber();
        string GetDatoStringDMY();
        string GetDatoStringYMD();
        int GetDay();
        int GetDayNumber();
        int GetMonth();
        string GetMonthTxt();
        int GetQuater();
        string GetQuaterTxt();
        ushort GetWeek();
        ushort GetWeekDay();
        int GetYear();
        void MoveDays(int antalDage);
        void MoveToNextDate();
        void MoveToPrevDate();
        void SetDay(int newDay);
        void SetDayNumber(int nyAar, int dagnr);
        void SetMonth(int newMmonth);
        void SetMonthAlternative(int newMonth);
        void SetYear(int newYear);
        void SetYearAlternative(int newYear);
            */
        }
        [TestMethod]
        public void Xdd_Xdd()
        { }
    }

}
