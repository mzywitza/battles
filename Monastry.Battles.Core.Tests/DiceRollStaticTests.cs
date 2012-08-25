using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Monastry.Battles.Core
{
    [TestFixture]
    public class DiceRollStaticTests
    {
        private IEnumerable<DiceRoll> _rolls;

        [SetUp]
        public void InitializeRolls()
        {
            _rolls = DiceRoll.Roll(10);
        }

        [Test]
        public void CanObtainNumberOfDices()
        {
            Assert.That(_rolls, Is.Not.Null);
            Assert.That(_rolls.Count(), Is.EqualTo(10));
        }

        [Test]
        public void RollsHaveInitializedDiceRollObjects()
        {
            Assert.That(_rolls.All(d=>d != null));
            Assert.That(_rolls.All(d=>d.Number != null));
        }

        [Test][Explicit("Random numbers may fail from time to time")]
        public void AllNumbersAreRolled()
        {
            var manyRolls = DiceRoll.Roll(100);
            var grouped = manyRolls.GroupBy(d => d.Number).ToList();
            Assert.That(grouped.All(g=>g.Key >= 1 && g.Key <= 6));
            Assert.That(grouped.All(g=>g.Count()>10), "Less than 10 dice with a given number"); // more than 10%
            Assert.That(grouped.All(g => g.Count() < 35), "More than 35 dice with a given number"); // less than 35%
        }
    }
}