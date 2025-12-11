using SimpleChatApp.Domain.Entities;

namespace SimpleChatApp.Data.Abstract.Repositories;

public interface IChannelRepository : IRepository<ChannelEntity>
{
    ChannelEntity GetByName(string channelName);
}