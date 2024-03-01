﻿using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Mexc.Net.Objects.Sockets.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mexc.Net.Objects.Sockets.Subscriptions
{
    internal class MexcErrorSubscription : SystemSubscription<MexcResponse>
    {
        public override HashSet<string> ListenerIdentifiers { get; set; } = new HashSet<string> { "0" };

        public MexcErrorSubscription(ILogger logger) : base(logger, false)
        {
        }

        public override Task<CallResult> HandleMessageAsync(SocketConnection connection, DataEvent<MexcResponse> message)
        {
            _logger.LogError("Server Error: {Error}", message.Data.Message);
            return Task.FromResult(new CallResult(null));
        }
    }
}
