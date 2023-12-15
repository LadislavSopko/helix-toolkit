using HelixToolkit.Wpf.SharpDX;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Text;


namespace HelixToolkit.SharpDX.Core.Tests
{
    [TestFixture]
    public class EffectsManagerTests
    {
        [Test]
        public void InitializationTest()
        {
            var effectsManager = new DefaultEffectsManager();
            foreach (var techName in effectsManager.RenderTechniques)
            {
                var tech = effectsManager[techName];
                Assert.That(!tech.IsNull);
                foreach (var passName in tech.ShaderPassNames)
                {
                    var p = tech[passName];
                    Assert.That(!p.IsNULL);
                }
            }
            effectsManager.Dispose();
            var liveObjects = global::SharpDX.Diagnostics.ObjectTracker.FindActiveObjects();
            ClassicAssert.AreEqual(0, liveObjects.Count);
        }
    }
}
