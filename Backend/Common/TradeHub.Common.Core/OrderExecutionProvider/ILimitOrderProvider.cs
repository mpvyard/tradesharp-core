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

namespace TradeHub.Common.Core.OrderExecutionProvider
{
    /// <summary>
    /// Interface to be implemented by Order Execution Providers which give Limit Order functionality 
    /// </summary>
    public interface ILimitOrderProvider : IOrderExecutionProvider
    {
        /// <summary>
        /// Raised when Order is accepted by the Order Execution Provider Gateway
        /// </summary>
        event Action<Order> NewArrived;

        /// <summary>
        /// Raised when Order is Filled (Partial/Full Fill) by the Order Execution Provider Gateway
        /// </summary>
        event Action<Execution> ExecutionArrived;

        /// <summary>
        /// Raised when Order is accepted by the Order Execution Provider Gateway
        /// </summary>
        event Action<Order> CancellationArrived;

        /// <summary>
        /// Raised when Order is rejected by the Order Execution Provider Gateway
        /// </summary>
        event Action<Rejection> RejectionArrived;

        /// <summary>
        /// Sends Limit Order on the given Order Execution Provider
        /// </summary>
        /// <param name="limitOrder">TradeHub LimitOrder</param>
        void SendLimitOrder(LimitOrder limitOrder);

        /// <summary>
        /// Sends Limit Order Cancallation on the given Order Execution Provider
        /// </summary>
        /// <param name="order">TradeHub Order</param>
        void CancelLimitOrder(Order order);
    }
}
