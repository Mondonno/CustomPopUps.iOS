using System;
using UIKit;
using CoreGraphics;

namespace CustomPopUps
{
    public class BasePopUp : UIView
    {
        public BasePopUp(CGSize size) : base()
        {
            nfloat lx = (UIScreen.MainScreen.Bounds.Width - size.Width) / 2;
            nfloat ly = (UIScreen.MainScreen.Bounds.Height - size.Height) / 2;

            Frame = new CGRect(new CGPoint(lx, ly), size);
            Layer.CornerRadius = Constants.LayerRadius;

            ClickOutCloseView.AddGestureRecognizer(new UITapGestureRecognizer(() => Close()));
        }

        private UIView ClickOutCloseView = new UIView();
        private UIVisualEffectView EffectView = new UIVisualEffectView(UIBlurEffect.FromStyle(Constants.BlurEffect));

        public delegate void OnCloseHandler();
        public delegate void OnOpenHandler();

        public event OnCloseHandler OnClose;
        public event OnOpenHandler OnOpen;

        public void Show()
        {
            UIWindow window = UIApplication.SharedApplication.KeyWindow;

            if (window != null)
            {
                EffectView.Frame = window.Bounds;

                window.EndEditing(true);
                window.AddSubview(EffectView);

                ClickOutCloseView.BackgroundColor = null;
                ClickOutCloseView.Frame = window.Frame;

                window.AddSubview(ClickOutCloseView);
                window.AddSubview(this);
            }

            Transform = CGAffineTransform.MakeScale(0.1f, 0.1f);
            Animate(Constants.AnimationDuration, delegate {
                Transform = CGAffineTransform.MakeScale(1, 1);
                EffectView.Alpha = Constants.EffectViewAlpha;
            }, delegate {
                OnOpen?.Invoke();
            });
        }

        public void Close()
        {
            Animate(Constants.AnimationDuration, delegate {
                Transform = CGAffineTransform.MakeScale(0.1f, 0.1f);
                EffectView.Alpha = 0;
            }, delegate {
                RemoveOnClose()
                OnClose?.Invoke();
            });
        }

        private void RemoveOnClose()
        {
            RemoveFromSuperview();
            ClickOutCloseView.RemoveFromSuperview();
            EffectView.RemoveFromSuperview();
        }
    }
}
