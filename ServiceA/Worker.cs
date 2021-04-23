﻿using Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceA
{
    public class Worker 
        : BackgroundService
    {
        readonly IBus bus;

        public Worker(IBus bus)
        {
            this.bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await bus.Publish(new Message($"The time is {DateTimeOffset.Now}"));
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
