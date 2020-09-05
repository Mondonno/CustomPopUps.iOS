using System;
using System.Threading.Tasks;

namespace CPopupLibrary
{
    public class PopUpsObjects : CustomPopUpViewController
    {
        //Give {get; set;} if you wan't to set popup settings in your code
        //Set your popup size!
        public double PopUpWidth { get; set; }
        public double PopUpHeight { get; set; }
        //Set your popup radius! (0 for any radius OR 6f for all rounded) 
        public double FrameRadius { get; set; }

        //Custom background RGB color (you can set it here, in the popup object, or in YourPopUpCode() method with this.BackgroundColor
        //SOON
        nfloat[] RGBColors = { 12,12,12 };

        public enum AniamtionType
        {
            Normal,
            Bounce
        }
        public enum Animated
        {
            Yes,
            No,
        }
        public enum PopActionType
        {
            Close,
            Show
        }
    }
}
