using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Korvi.PayPal.Tests
{
    [TestClass]
    public class GetTokenTests
    {
        [TestMethod]
        public void GetToken1()
        {
            var client = new PayPalClient(true,
                "AaYECKE7yGsxfx2jyXhQDUT8sQDUF2WZ-YXXuHb9q91J2eIn3_dbPZpfjwsUAWkj7zLkD5uvrXnUugzR",
                "EF8v_xfVUKe05PpwGJ5MPKPgLZcKgTMagEAhmWUEAsdYl4Sik8TFHXu0eTYEa6w5iyiXvgXPXDmxDM6y");

            client.Authenticate();

        }
    }
}
