using Foundation;
using System;
using System.Diagnostics;
using UIKit;
using CoreGraphics;
using CustomPopUps;

namespace Test.iOS
{
    public partial class ViewController : UIViewController
    {
        public UIFont Font { get; set; } = UIFont.FromName("Futura", 15);

        public ViewController(IntPtr handle) : base(handle)
        {
            NavigationController.NavigationBarHidden = true;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var button = new UIButton(UIButtonType.System);
            var popup = GetFeaturesPopUp();

            nfloat btnHeight = 40;
            button.Frame = GetCenter(View, 140, btnHeight);
            button.Font = Font;

            button.SetTitle("Click to show popup!", UIControlState.Normal);
            button.SetTitleColor(UIColor.Black, UIControlState.Normal);

            button.TouchUpInside += (object sender, EventArgs e) => {
                popup.Show();
            };
            View.AddSubview(button);
        }

        private PopUp GetFeaturesPopUp()
        {
            var size = new CGSize(300, 300);
            var popup = new PopUp(size);

            var closeButton = new UIButton(UIButtonType.System);
            closeButton.Frame = new CGRect(90, popup.Frame.Height - 60, 120, 60);

            closeButton.Font = Font;

            closeButton.SetTitle("Close", UIControlState.Normal);
            closeButton.SetTitleColor(UIColor.Red, UIControlState.Normal);

            closeButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                popup.Close();
            };

            var titleLabel = new UILabel() {
                Frame = new CGRect(10, 10, 290, 50),
                Text = "Hello in custom popups!",
                Font = UIFont.FromName("Futura", 25),
                TextColor = UIColor.Blue
            };

            var descriptionLabel = new UILabel()
            {
                Frame = new CGRect(10, 90, 290, 120),
                Text = "All features and avaiblities are avaible on our Github",
                Font = Font,
                TextColor = UIColor.Black
            };

            descriptionLabel.LineBreakMode = UILineBreakMode.TailTruncation;
            descriptionLabel.Lines = 0;

            popup.AddSubview(titleLabel);
            popup.AddSubview(descriptionLabel);
            popup.AddSubview(closeButton);

            popup.OnOpen += () =>
            {
                Debug.WriteLine("[INFO] PopUp is here!");
            };

            return popup;
        }

        private CGRect GetCenter(UIView view, nfloat width, nfloat height)
        {
            return new CGRect(0, view.Frame.Height / 2 + height + (height / 2), view.Frame.Width / 2 + width + (width / 2), height);
        }

        [Obsolete]
        private CGRect GetBottomCenter(UIView view, nfloat width, nfloat height)
        {
            return new CGRect(0, view.Frame.Height - height, view.Frame.Width / 2 + width, height);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}