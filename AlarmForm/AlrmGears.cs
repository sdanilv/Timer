using System;
using System.Windows.Forms;
using System.Drawing;

namespace AlarmForm
    {
    class AlarmGears
        {
        private MyTextBox textBox;
        public AlarmGears(MyTextBox textBox)
            {
            this.textBox = textBox;
            }
        public int setAlarm(string duration, char split)
            {
            string[] splitTimeStr = duration.Split(split);
            int hours = Convert.ToInt32(splitTimeStr[0]);
            int minuts = Convert.ToInt32(splitTimeStr[1]);
            if (hours > 24 || hours < 0 || minuts > 60 || minuts < 0 || hours < DateTime.Now.Hour || hours == DateTime.Now.Hour && minuts < DateTime.Now.Minute) throw new Exception();
            textBox.changeAndDisable($"{splitTimeStr[0]:00} : {splitTimeStr[1]:00}");
            DateTime date = DateTime.Now;
            DateTime alarmTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minuts, 0);
            return (int)(alarmTime - date).TotalSeconds;
            }

        public int setTimer(string durationInSring)
            {
            durationInSring = durationInSring.Replace('.', ',');
            double minuts = Convert.ToDouble(durationInSring);
            if (minuts > 1000) throw new Exception();
            DateTime dt = DateTime.Now.AddMinutes(minuts);
            textBox.changeAndDisable($"{dt.Hour: 00}:{dt.Minute: 00}");
            return (int)(minuts * 60);
            }
        public static void Bels()
            {
            Console.Beep(1000, 300);
            Console.Beep(1000, 500);
            Console.Beep(1000, 300);
            }

        public int getContinuenseOfTimers(string textContainsTime)
            {
            int continuance;
            try
                {
                if (textContainsTime.Contains(":")) continuance = setAlarm(textContainsTime, ':');
                if (textContainsTime.Contains("/")) continuance = setAlarm(textContainsTime, '/');
                else continuance = setTimer(textContainsTime);
                }
            catch (Exception)
                {
                textBox.ChangeBackgroundForRed();
                return 0;
                }
            return continuance;
            }


        }
    }
