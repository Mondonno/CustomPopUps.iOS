﻿
// <-----/ FAQ \----->
// Q. What happen when i do this.ShowPopUp() here?
// A. The app will be show 2 popups, do not reccomended
// Q. Where i can find an updates for this library?
// A. You can find us on github: https://github.com/Mondonno/CustomPopUps.iOS/
// Q. Where i can find full tutorial how to customize this popup?
// A. Soon we share some tutorials on our project github wiki
// <-----/ FAQ \----->

using System;
using System.Threading.Tasks;
using UIKit;
using Foundation;
using CoreGraphics;

namespace CPopupLibrary
{
    public class YourCustomizePopup : PopUpsObjects
    {
        #region PUSS | PopUps System Settings
        public async Task ShowPopUp()
        {
            await YourPopUpCode();
        }
        private protected async Task Init()
        {
            //You can set if you want to get animated popup by changing the true value!
            //Adding the PopUp Closing handler
            PopUpWillClose += PopWillClose;

            PopUp(true,//Here you can chenge animating!
                async delegate {
                    //Do stuff when the popup will be opened
                    //Or you can add here handling method
                    await OpenHandler();
                });
        }
        #endregion

        public YourCustomizePopup()
        {

        }

        private protected async Task OpenHandler()
        {
            //This code below will be started when the popup will be opened!
            //Do stuff!

        }
        private protected async void PopWillClose()
        {
            //This code below will be started when the PopUp will be Closed!
            //Do stuff!

        }

     

        private async Task YourPopUpCode()
        {
            #region Starting
            CGSize PopUpSize = new CGSize(PopUpWidth, PopUpHeight);
            CustomPopUpInit(PopUpSize, (nfloat) FrameRadius);
            #endregion

            // Here write your PopUp code and declare the objects

            UIButton btnClose = new UIButton(UIButtonType.System);
        nfloat btnHeight = 40;
            btnClose.SetTitle("Close", UIControlState.Normal);
            btnClose.Frame = new CGRect(0, this.Frame.Height - btnHeight, this.Frame.Width, btnHeight);
            btnClose.TouchUpInside += delegate {
                Close();
            };
            
            
            btnClose.TitleShadowOffset = new CGSize(0, 1);
            this.BackgroundColor = UIColor.White;
            btnClose.BackgroundColor = UIColor.White;
            btnClose.TintColor = UIColor.Black;
            btnClose.Font = UIFont.FromName("Futura", 30);

            this.AddSubview(btnClose);
            

            #region Initializing
            //IMPORTANT! DO NOT CHANGE THIS!
            await Init();
            #endregion
        }
    }
}
