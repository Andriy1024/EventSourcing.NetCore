using System;
using Core.Aggregates;
using MeetingsManagement.Meetings.Events;

namespace MeetingsManagement.Meetings
{
    public class Meeting : EventSourcedAggregate
    {
        public string Name { get; private set; }

        public Meeting(){}

        private Meeting(Guid id, string name)
        {
            var @event = new MeetingCreated(id, name);
            Append(@event);
            Apply(@event);
        }

        public void Apply(MeetingCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
        }

        public static Meeting Create(Guid id, string name)
        {
            return new Meeting(id, name);
        }
    }
}
