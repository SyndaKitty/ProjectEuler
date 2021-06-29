using System;

class Program {
    static void Main(string[] args) {
        var monthDays = new int[]{31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

        int dayCount = 1; // Jan 1, 1901 was a tuesday
        int result = 0;

        for (int year = 1901; year <= 2000; year++) {
            for (int month = 0; month <= 11; month++) {
                if (dayCount % 7 == 6) {
                    result++;
                }
                
                int days = monthDays[month];
                if (month == 1 && year % 4 == 0 && year % 400 > 0) {
                    // Leap year
                    days = 29;
                }
                dayCount += days;
            }
        }

        Console.WriteLine(result);
    }
}