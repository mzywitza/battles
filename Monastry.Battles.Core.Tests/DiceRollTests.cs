using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Monastry.Battles.Core
{
    [TestFixture]
    public class DiceRollTests
    {
        [Test]
        public void DiceRollContainsNumber()
        {
            var roll = new DiceRoll() {Number = 4};
            Assert.That(roll.Number, Is.EqualTo(4));
        }
    }
}
