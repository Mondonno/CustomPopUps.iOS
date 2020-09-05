using Foundation;
using System;
using UIKit;
using CPopupLibrary;
using CoreGraphics;

namespace CustomPopUpDemo
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        { 
        }
        public void PopWillClose()
        {

        }
        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
           
            UILabel label = new UILabel(new CGRect(100, 100, 70, 40));
            label.Font = UIFont.SystemFontOfSize(30);
            
            this.View.AddSubview(label);
            this.View.AddGestureRecognizer(new UITapGestureRecognizer(async () => {
                YourCustomizePopup popup = new YourCustomizePopup();
                popup.PopUpWidth = 300;
                popup.PopUpHeight = 200;
                await popup.ShowPopUp();
                void PopWillClose()
                {
                    label.Text = popup.DemoTextView.Text;
                }
                popup.PopUpWillClose += PopWillClose;
            }));

            



        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}