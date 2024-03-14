using FluentNHibernate.Mapping;

namespace ProducerLogic.LogMessages
{
    public class LogMessageMap : ClassMap<LogMessage>
    {
        public LogMessageMap()
        {
            Id(x => x.Id);

            Map(x => x.ExternalId).CustomType<string>().Access.CamelCaseField(Prefix.Underscore);
        }
    }
}
