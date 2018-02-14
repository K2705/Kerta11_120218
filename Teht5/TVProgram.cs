using System;

namespace Teht5
{

    [Serializable()]
    class TVProgram
    {
        public string Name { get; set; }
        public string Channel { get; set; }
        public string Info { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

        public TVProgram(string Name, string Channel, DateTime BeginTime, DateTime EndTime, string Info)
        {
            this.Name = Name;
            this.Channel = Channel;
            this.Info = Info;
            this.BeginTime = BeginTime;
            this.EndTime = EndTime;
        }

        public override string ToString()
        {
            return Name + " (" + Channel + ") " + BeginTime.TimeOfDay + " - " + EndTime.TimeOfDay + " : " + Info;
        }
    }
}
