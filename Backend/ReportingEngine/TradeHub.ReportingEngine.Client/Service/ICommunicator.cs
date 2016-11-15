/***************************************************************************** 
* Copyright 2016 Aurora Solutions 
* 
*    http://www.aurorasolutions.io 
* 
* Aurora Solutions is an innovative services and product company at 
* the forefront of the software industry, with processes and practices 
* involving Domain Driven Design(DDD), Agile methodologies to build 
* scalable, secure, reliable and high performance products.
* 
* TradeSharp is a C# based data feed and broker neutral Algorithmic 
* Trading Platform that lets trading firms or individuals automate 
* any rules based trading strategies in stocks, forex and ETFs. 
* TradeSharp allows users to connect to providers like Tradier Brokerage, 
* IQFeed, FXCM, Blackwood, Forexware, Integral, HotSpot, Currenex, 
* Interactive Brokers and more. 
* Key features: Place and Manage Orders, Risk Management, 
* Generate Customized Reports etc 
* 
* Licensed under the Apache License, Version 2.0 (the "License"); 
* you may not use this file except in compliance with the License. 
* You may obtain a copy of the License at 
* 
*    http://www.apache.org/licenses/LICENSE-2.0 
* 
* Unless required by applicable law or agreed to in writing, software 
* distributed under the License is distributed on an "AS IS" BASIS, 
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
* See the License for the specific language governing permissions and 
* limitations under the License. 
*****************************************************************************/


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeHub.Common.Core.DomainModels.OrderDomain;
using TradeHub.Common.Core.Repositories.Parameters;

namespace TradeHub.ReportingEngine.Client.Service
{
    /// <summary>
    /// Blueprint for the communicators to give functionality to Reproting Engine Client
    /// </summary>
    public interface ICommunicator
    {
        /// <summary>
        /// Raised when Order Report is received from Reporting Engine
        /// </summary>
        event Action<IList<object[]>> OrderReportReceivedEvent; 

        /// <summary>
        /// Raised when Profit Loss Report is received from Reporting Engine
        /// </summary>
        event Action<ProfitLossStats> ProfitLossReportReceivedEvent; 

        /// <summary>
        /// Indicates if the communication medium is open or not
        /// </summary>
        /// <returns></returns>
        bool IsConnected();

        /// <summary>
        /// Opens necessary connections to start 
        /// </summary>
        void Connect();

        /// <summary>
        /// Closes communication channels
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Send Order Report request to Reporting Engine
        /// </summary>
        /// <param name="parameters">Search parameters to be used for report</param>
        void RequestOrderReport(Dictionary<OrderParameters, string> parameters);

        /// <summary>
        /// Send Profit Loss Report request to Reporting Engine
        /// </summary>
        /// <param name="parameters">Search parameters to be used for report</param>
        void RequestProfitLossReport(Dictionary<TradeParameters, string> parameters);
    }
}
