using System;
using System.Collections.Generic;

namespace Adapter2
{
    /// Клієнтський клас, який є споживачом інтерфейсу ITarget
    public class ThirdPartySystem
    {
        private readonly ITarget _timetableTarget;

        public ThirdPartySystem(ITarget timetableTarget)
        {
            _timetableTarget = timetableTarget;

        }

        public void ShowTimetable()
        {
            List<string> trainList = _timetableTarget.GetTrainList();

            Console.WriteLine("Trains....");

            foreach (var item in trainList)
            {
                Console.Write(item);
            }

        }
    }

    /// <summary>
    /// Інтерфейс, який очікується клієнтом
    /// </summary>
    public interface ITarget
    {
        List<string> GetTrainList();
    }

    /// <summary>
    /// Клас який необхідний для роботи клієнта, але містить несумісний з ним інтерфейс
    /// </summary>
    public class OldTrainTimeTable
    {
        public string[][] GetTimetable()
        {
            string[][] timetable = new string[4][];

            timetable[0] = new[] { "97", "Kuyiv - Kovel", "every day	02:07 02:15	06:00" };
            timetable[1] = new[] { "855", "Kuyiv - Rivne", "every day	20:24 20:24" };
            timetable[2] = new[] { "847", "Kuyiv - Rivne", "every day" };
            timetable[3] = new[] { "84", "Kovel - Odesa", "from 27/10/2013 on odd" };

            return timetable;
        }
    }

    /// <summary>
    /// Клас Адаптер, який приводить Adaptee до Target
    /// </summary>
    public class TrainAdapter : ITarget
    {
        private readonly OldTrainTimeTable _oldBadSystem;

        public TrainAdapter()
        {
            _oldBadSystem = new OldTrainTimeTable();  
        }

        public List<string> GetTrainList()
        {
            var trainList = new List<string>();

            string[][] timetable = _oldBadSystem.GetTimetable();

            foreach (string[] train in timetable)
            {
                trainList.Add(train[0]);
                trainList.Add(",");
                trainList.Add(train[1]);
                trainList.Add(",");
                trainList.Add(train[2]);
                trainList.Add("\n");
            }

            return trainList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ITarget itarget = new TrainAdapter();

            var client = new ThirdPartySystem(itarget);
            client.ShowTimetable();

            Console.ReadKey();
        }
    }
}
