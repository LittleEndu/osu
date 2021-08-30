// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Osu.Objects.Drawables;
using osu.Game.Skinning;

namespace osu.Game.Rulesets.Osu.Skinning.Legacy
{
    public class LegacyReverseArrow : Sprite
    {
        [Resolved]
        private ISkinSource skin { get; set; }

        [Resolved]
        private DrawableHitObject drawableHitobject { get; set; }

        private Drawable proxy;

        [BackgroundDependencyLoader]
        private void load()
        {
            Texture = skin.GetTexture("reversearrow");
            drawableHitobject.HitObjectApplied += _ =>
            {
                if (IsDisposed)
                    return; // probably needs to unsubscribe and dispose of the proxy instead of just returning forever

                if (!HasProxy)
                    proxy = CreateProxy();

                ((Container)proxy.Parent)?.Remove(proxy); // remove the proxy from any wrong containers
                ((LegacyMainCirclePiece)((DrawableSliderRepeat)drawableHitobject).DrawableSlider.HeadCircle.CirclePiece.Drawable).ReverseArrowContainer.Add(proxy);
            };
        }
    }
}
