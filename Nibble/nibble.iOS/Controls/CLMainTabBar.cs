using System;
using UIKit;
using CoreGraphics;
using ObjCRuntime;
using Xamarin.Forms.Platform.iOS;
using System.Diagnostics;
using System.Collections.Generic;
using Masonry;

namespace nibble.iOS.Controls
{
    public class CLMainTabBar : UITabBar
    {
        public CLMainTabBar():base()
        {
            SetupBalanceLabel();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var tabBarButtons = new List<UIView>();
            foreach (UIView view in Subviews)
            {
                if (view.ToString().Contains("UITabBarButton"))
                {
                    tabBarButtons.Add(view);
                }
            }

            Debug.Assert(tabBarButtons.Count == 2, "in this App design,TabBarItems must be 2,if you would like more TabBarItems, please contact UI team");

            var leftButton = tabBarButtons[0];// Left Button
            var rightButton = tabBarButtons[1];// Right Button

            const float Height_Margin = 10;
            var Button_Width = Frame.Width / 5.0f;
            var Button_Height = Frame.Height - Height_Margin * 2;


            leftButton.Frame = new CGRect(0, 0, Button_Width, Button_Height);
            rightButton.Frame = new CGRect(Frame.Width - Button_Width, 0, Button_Width, Button_Height);

        }

        private void SetupBalanceLabel()
        {
            const float Height_Margin = 10;
            var totalBalanceLabel = new UILabel()
            {
                Text = AppResources.TotalBalance,
                Font = UIFont.SystemFontOfSize(12)
                
            };
            AddSubview(totalBalanceLabel);

            totalBalanceLabel.MakeConstraints(make => {
                make.Top.EqualTo(this.Top()).Offset(Height_Margin);
                make.CenterX.EqualTo(this.CenterX());
            });

            var numberLabel = new UILabel()
            {
                TextColor = UIColor.Blue,
                Font = UIFont.BoldSystemFontOfSize(18)
            };
            numberLabel.Text = "$1000";
            AddSubview(numberLabel);

            numberLabel.MakeConstraints(make => {
                make.Top.EqualTo(totalBalanceLabel.Bottom());
                make.CenterX.EqualTo(this.CenterX());
            });

        }

    }
}
