using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWN.CustomerApi.Service.Controllers;
using Xunit;

namespace TWN.CustomerApi.Service.Test
{
    public class AliveControllerTest
    {
        private readonly AliveController _aliveController;

        public AliveControllerTest()
        {
            this._aliveController = new AliveController();
        }

        [Fact]
        public void AliveTest()
        {
            var result = _aliveController.Get();

            Assert.IsType<OkResult>(result);
        }
    }
}
