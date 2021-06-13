// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Testing;
using osu.Game.Rulesets.Scoring;
using osu.Game.Screens.Play.HUD;
using osu.Game.Skinning;

namespace osu.Game.Tests.Visual.Gameplay
{
    public class TestSceneSkinnableAccuracyCounter : SkinnableHUDComponentTestScene
    {
        [Cached]
        private ScoreProcessor scoreProcessor = new ScoreProcessor();

        protected override Drawable CreateDefaultImplementation() => new DefaultAccuracyCounter();
        protected override Drawable CreateLegacyImplementation() => new LegacyAccuracyCounter();

        [SetUpSteps]
        public void SetUpSteps()
        {
            AddStep("Set initial accuracy", () => scoreProcessor.Accuracy.Value = 1);
        }

        [Test]
        public void TestChangingAccuracy()
        {
            AddStep(@"Reset all", () => scoreProcessor.Accuracy.Value = 1);

            AddStep(@"Miss :(", () => scoreProcessor.Accuracy.Value -= 0.023);
        }
    }
}
