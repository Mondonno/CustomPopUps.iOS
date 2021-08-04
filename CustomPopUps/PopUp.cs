using System;
using CoreGraphics;

namespace CustomPopUps
{
    public class PopUp : BasePopUp
    {
        public PopUp(CGSize size) : base(size)
        {
            BackgroundColor = Constants.Color;
        }
        public PopUp(CGSize size, Action<PopUp> init) : this(size)
        {
            init(this);
        }
    }
}
