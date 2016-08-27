﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using LionFire.Extensions.Logging;

namespace LionFire.Trading.Bots
{
    // TODO: Rename BotBase to SingleSeriesBotBase  and make a new BotBase that is more generic

    public partial class BotBase
    {
        #region Configuration

        public BotConfig BotConfig { get; set; } = new BotConfig();


        public LosingTradeLimiterConfig LosingTradeLimiterConfig { get; set; } = new LosingTradeLimiterConfig();

        #endregion

#if cAlgo
        protected virtual void OnStarting()
#else
        protected override void OnStarting()
#endif
        {
            l = this.GetLogger(this.ToString().Replace(' ', '.'), BotConfig.Log);
            
            l.LogInformation($"------- START {this} -------");
        }

        protected virtual void OnStopping()
        {
            l.LogInformation($"------- STOP {this} -------");
        }
        protected virtual void OnNewBar()
        {
        }

#region Misc

        public virtual string Label {
            get {
                return label ?? this.GetType().Name;
            }
            set {
                label = value;
            }
        }
        private string label = null;


        public Microsoft.Extensions.Logging.ILogger Logger { get { return l; } }
        protected Microsoft.Extensions.Logging.ILogger l;

#endregion
    }

    
}
