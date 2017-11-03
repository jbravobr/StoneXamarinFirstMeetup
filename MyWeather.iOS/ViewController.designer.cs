// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MyWeather.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CallAPIButton { get; set; }

        [Action ("CallAPIButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CallAPIButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (CallAPIButton != null) {
                CallAPIButton.Dispose ();
                CallAPIButton = null;
            }
        }
    }
}