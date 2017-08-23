﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KcpServer;

namespace TestServer
{
    class TestApplication : KcpServer.ApplicationBase
    {
        public override PeerBase CreatePeer(PeerContext peerContext)
        {
            var peertype = Encoding.UTF8.GetString(peerContext.ApplicationData);
            if (peertype == "udppeer")
            {
                return new TestUdpPeer(peerContext);
            }
            else if (peertype == "kcppeer")
            {
                return new BigBuffPeer(peerContext);
            }
            else if (peertype == "mixpeer")
            {
                return new ExPeer(peerContext);
            }
            else
            {
                Console.WriteLine($"NotImplementedPeer");
                return null;
            }
        }

        public override void Setup()
        {
            Console.WriteLine($"{nameof(TestApplication)} {nameof(Setup)} {LocalEndPoint}");
        }

        public override void TearDown()
        {
            Console.WriteLine($"{nameof(TestApplication)} {nameof(TearDown)}");
        }



    }
}
