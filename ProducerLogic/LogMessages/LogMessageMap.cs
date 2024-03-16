using FluentNHibernate.Mapping;

namespace ProducerLogic.LogMessages
{
    public class LogMessageMap : ClassMap<LogMessage>
    {
        public LogMessageMap()
        {
            Id(x => x.Id);

            Map(x => x.ExternalId).CustomType<string>().Access.CamelCaseField(Prefix.Underscore).Length(36);
            Map(x => x.Content).CustomType<string>();
            Map(x => x.ErrorMessage).CustomType<string>().Access.CamelCaseField(Prefix.Underscore).Length(500).Nullable();

            References(x => x.Status);
            References(x => x.EventType);
        }
    }
}
