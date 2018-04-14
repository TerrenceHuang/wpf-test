using System;
using System.Windows;

namespace DateTime {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            //dateTimeTest();
            getDateInfoString(WhatDay.Today);
            getDateInfoString(WhatDay.Tomorrow);
        }

        void dateTimeTest() {

            System.DateTime dateTime = new System.DateTime();
            System.DateTime now = System.DateTime.Now;
            System.DateTime utcNow = System.DateTime.UtcNow;
            System.DateTime today = System.DateTime.Today;

            Console.WriteLine(dateTime);
            Console.WriteLine(now);
            Console.WriteLine(utcNow);
            Console.WriteLine(today);

            Console.WriteLine(today.ToString("M/d") + " " + today.DayOfWeek);
        }

        // get "M/d(week)" in chinese
        void getDateInfoString(WhatDay whatDay) {

            // get the dateTime
            System.DateTime dateTime = System.DateTime.Today;

            switch (whatDay) {

                case WhatDay.Today:

                    
                    break;
                case WhatDay.Tomorrow:

                    dateTime = dateTime.AddDays(60);
                    break;
            }

            Console.WriteLine(dateTime.ToString("M/d"));

            //​ get chinese week
            Console.WriteLine(dateTime.DayOfWeek);

            string chineseWeekName = "";
            switch (dateTime.DayOfWeek) {

                case DayOfWeek.Sunday:

                    chineseWeekName = "日";
                    break;
                case DayOfWeek.Monday:

                    chineseWeekName = "一";
                    break;
                case DayOfWeek.Tuesday:

                    chineseWeekName = "二";
                    break;
                case DayOfWeek.Wednesday:

                    chineseWeekName = "三";
                    break;
                case DayOfWeek.Thursday:

                    chineseWeekName = "四";
                    break;
                case DayOfWeek.Friday:

                    chineseWeekName = "五";
                    break;
                case DayOfWeek.Saturday:

                    chineseWeekName = "六";
                    break;
            }
            Console.WriteLine(chineseWeekName);
        }

        public enum WhatDay {

            Today,
            Tomorrow
        }
    }
}
