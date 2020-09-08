
// <-----/ FAQ \----->
// Q. What happen when i do this.ShowPopUp() here?
// A. The app will be show 2 popups, do not reccomended
// Q. Where i can find an updates for this library?
// A. You can find us on github: https://github.com/Mondonno/CustomPopUps.iOS/
// Q. Where i can find full tutorial how to customize this popup?
// A. Soon we share some tutorials on our project github wiki
// <-----/ FAQ \----->

using System;
using UIKit;
using CoreGraphics;
using Foundation;
using System.Threading.Tasks;

namespace CPopupLibrary
{
    public class CustomPopUpViewController : UIView
    {
        
        public delegate void PopWillCloseHandler();

        //You can use it to handle the closing PopUp event
        public event PopWillCloseHandler PopUpWillClose;

        private UIVisualEffectView effectView = new UIVisualEffectView(UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark));

        //Initializing PopUp
        public void CustomPopUpInit(CGSize size, nfloat?  FrameRadius = null)
        {
            //Setting size and makeing effects
            nfloat lx = (UIScreen.MainScreen.Bounds.Width - size.Width) / 2;
            nfloat ly = (UIScreen.MainScreen.Bounds.Height - size.Height) / 2;
            this.Frame = new CGRect(new CGPoint(lx, ly), size);
            if(FrameRadius == null) FrameRadius = 0;
            this.Layer.CornerRadius = FrameRadius;
            effectView.Alpha = 0;
        }

        //PopUp Showing
        public void PopUp( bool animated = true, Action popAnimationFinish = null)
        {
            //Setting UIWindow to show popup
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            //Setting effect view frame
            effectView.Frame = window.Bounds;
            //Editing windows
            window.EndEditing(true);
            window.AddSubview(effectView);
            window.AddSubview(this);
            //Checking if animated
            if (animated)
            {
                //Transforming to 0.1f Scale to make animation
                Transform = CGAffineTransform.MakeScale(0.1f, 0.1f);
                //Animating UIView by Core Grpahics
                UIView.Animate(0.15, delegate {
                    //Making other animations
                    Transform = CGAffineTransform.MakeScale(1, 1);
                    effectView.Alpha = 0.8f;
                }, delegate {
                    
                    //Running event
                    if (null != PopUpWillOpen)
                        PopUpWillOpen();
                });
            }
            else
            {
                //Changing alpha in effect view
                effectView.Alpha = 0.8f;
            }
        }

        //Closing PopUp
        public void Close(bool animated = true)
        {
            //Checking if animated
            if (animated)
            {
                //Animating UIView by Core Grpahics
                UIView.Animate(0.15, delegate {
                    //Making other animations
                    Transform = CGAffineTransform.MakeScale(0.1f, 0.1f);
                    effectView.Alpha = 0;
                }, delegate {
                    //Removing from View Controller PopUp and Effects
                    this.RemoveFromSuperview();
                    effectView.RemoveFromSuperview();
                    //Running event (PopUpWillClose)
                    if (null != PopUpWillClose) PopUpWillClose();
                });
            }
            else
            {
                //Running event (PopUpWillClose)
                if (null != PopUpWillClose) PopUpWillClose();
            }

        }
    
    }
}