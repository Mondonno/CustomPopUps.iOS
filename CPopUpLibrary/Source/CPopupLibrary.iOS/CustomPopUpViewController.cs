
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
        public void CustomPopUpInit(CGSize size, nfloat? frame_radius = null)
        {
            //Setting size and makeing effects
            nfloat lx = (UIScreen.MainScreen.Bounds.Width - size.Width) / 2;
            nfloat ly = (UIScreen.MainScreen.Bounds.Height - size.Height) / 2;
            this.Frame = new CGRect(new CGPoint(lx, ly), size);
            effectView.Alpha = 0;
        }

        //PopUp Showing
        public void PopUp( bool animated = true, Action popAnimationFinish = null)
        {
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            effectView.Frame = window.Bounds;
            window.EndEditing(true);
            window.AddSubview(effectView);
            window.AddSubview(this);
            
            if (animated)
            {
                Transform = CGAffineTransform.MakeScale(0.1f, 0.1f);
                UIView.Animate(0.15, delegate {
                    Transform = CGAffineTransform.MakeScale(1, 1);
                    effectView.Alpha = 0.8f;
                }, delegate {
                    if (null != popAnimationFinish)
                        popAnimationFinish();
                });
            }
            else
            {
                effectView.Alpha = 0.8f;
            }
        }

        //Closing PopUp
        public void Close(bool animated = true)
        {

            if (animated)
            {
                UIView.Animate(0.15, delegate {
                    Transform = CGAffineTransform.MakeScale(0.1f, 0.1f);
                    effectView.Alpha = 0;
                }, delegate {
                    this.RemoveFromSuperview();
                    effectView.RemoveFromSuperview();
                    if (null != PopUpWillClose) PopUpWillClose();
                });
            }
            else
            {
                if (null != PopUpWillClose) PopUpWillClose();
            }

        }
        
    }
}