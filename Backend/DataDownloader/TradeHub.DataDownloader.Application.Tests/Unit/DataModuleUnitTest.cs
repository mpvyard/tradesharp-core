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
using NUnit.Framework;
using TradeHub.Common.Core.Constants;
using TradeHub.Common.Core.DomainModels;
using TradeHub.DataDownloader.Common.ConcreteImplementation;
using TradeHub.DataDownloader.UserInterface.Common;
using TradeHub.DataDownloader.UserInterface.Common.Messages;
using TradeHub.DataDownloader.UserInterface.DataModule.ViewModel;

namespace TradeHub.DataDownloader.Application.Tests.Unit
{
    [TestFixture]
    public class DataModuleUnitTest
    {
        /// <summary>
        /// Test LogonArrived
        /// </summary>
        [Test]
        public void LoginArrivedTest()
        {
            DataViewModel viewModel=new DataViewModel();
            foreach (var selectedProvider in viewModel.SelectedProviders)
            {
                if (selectedProvider.ProviderName==MarketDataProvider.Blackwood)
                {
                    Assert.IsFalse(selectedProvider.IsConnected);
                }
                
            }
            EventSystem.Publish<LoginArrivedMessage>(new LoginArrivedMessage{Provider = new Provider{IsConnected = true,ProviderName = MarketDataProvider.Blackwood}});
            foreach (var selectedProvider in viewModel.SelectedProviders)
            {
                if (selectedProvider.ProviderName == MarketDataProvider.Blackwood)
                {
                    Assert.IsTrue(selectedProvider.IsConnected);
                }
            }
        }

        /// <summary>
        /// Test New Symbol Subscribe
        /// </summary>
        [Test]
        public void SubscribeToNewSymbol()
        {
            DataViewModel viewModel = new DataViewModel();
            EventSystem.Publish<LoginArrivedMessage>(new LoginArrivedMessage { Provider = new Provider { IsConnected = true, ProviderName = MarketDataProvider.Blackwood } });
            SecurityPermissions securityPermissions = new SecurityPermissions { Id = Guid.NewGuid().ToString(), MarketDataProvider = MarketDataProvider.Blackwood ,Security = new Security{Symbol = "AAPL"}};
            viewModel.SelectedProvider = new Provider { IsConnected = true, ProviderName = MarketDataProvider.Blackwood };
            EventSystem.Publish<SecurityPermissions>(securityPermissions);
            
            Assert.AreEqual(1,viewModel.SecurityStatDictionary[MarketDataProvider.Blackwood].Count);
        }
    }
}
