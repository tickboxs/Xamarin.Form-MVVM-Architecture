using System;
using Android.Content;
using Android.Views;
using Xamarin.Forms.Platform.Android;
using nibble.Controls;
using Android.Graphics;
using Android.Widget;
using Java.Interop;
using System.Collections.Generic;
using Android.Views.Animations;
using Android.Animation;
using nibble.Droid.Utilities;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Support.V4.Content;

namespace nibble.Droid.Controls
{
    public class CLMainTabBar: ViewGroup
    {
        private string[] _titles;

        private Button _leftButton;
        private Button _rightButton;
        private TextView _totalBalance;
        private TextView _balance;
        private View _topLine;

        Context _context;
        private Action<int> _action;

        private int _selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }

            set
            {
                // Tabs Must be 2
                System.Diagnostics.Debug.Assert(_selectedIndex == 0 || _selectedIndex == 1, "_selectedIndex can only be 0 or 1 due to UI design(only two tabs)");
                _selectedIndex = value;
                if (_selectedIndex == 0)
                {
                    var homeDrawable = ContextCompat.GetDrawable(_context, Resource.Drawable.home);
                    homeDrawable.SetColorFilter(new PorterDuffColorFilter(Color.Purple, PorterDuff.Mode.SrcAtop));
                    _leftButton.SetCompoundDrawablesWithIntrinsicBounds(null, homeDrawable, null, null);
                    _leftButton.SetTextColor(Color.Purple);

                    var profileDrawable = ContextCompat.GetDrawable(_context, Resource.Drawable.profile);
                    profileDrawable.SetColorFilter(new PorterDuffColorFilter(Color.LightGray, PorterDuff.Mode.SrcAtop));
                    _rightButton.SetCompoundDrawablesWithIntrinsicBounds(null, profileDrawable, null, null);
                    _rightButton.SetTextColor(Color.LightGray);

                }
                else
                {
                    var homeDrawable = ContextCompat.GetDrawable(_context, Resource.Drawable.home);
                    homeDrawable.SetColorFilter(new PorterDuffColorFilter(Color.LightGray, PorterDuff.Mode.SrcAtop));
                    _leftButton.SetCompoundDrawablesWithIntrinsicBounds(null, homeDrawable, null, null);
                    _leftButton.SetTextColor(Color.LightGray);

                    var profileDrawable = ContextCompat.GetDrawable(_context, Resource.Drawable.profile);
                    profileDrawable.SetColorFilter(new PorterDuffColorFilter(Color.Purple, PorterDuff.Mode.SrcAtop));
                    _rightButton.SetCompoundDrawablesWithIntrinsicBounds(null, profileDrawable, null, null);
                    _rightButton.SetTextColor(Color.Purple);
                }

            }
        }

        public CLMainTabBar(Context context,string[] titles,Action<int> action):base(context)
        {
            _context = context;
            _titles = titles;
            _action = action;

            // TabBar BackgroundColor
            SetBackgroundColor(Xamarin.Forms.Color.FromHex("#F7F8F9").ToAndroid());

            // Tabs Must be 2
            System.Diagnostics.Debug.Assert(titles.Length == 2,"in current app deisgn,titles must be 2.if you would like to add more tabs,please contact UI team.");

            // Home Button
            _leftButton = new Button(_context);
            _leftButton.Text = AppResources.Home;
            _leftButton.SetTextSize(Android.Util.ComplexUnitType.Dip, 8);
            _leftButton.Click += _leftButton_Click;
            
            _leftButton.SetBackgroundColor(Color.Transparent);
            _leftButton.SetOutlineAmbientShadowColor(Color.Transparent);
            _leftButton.SetOutlineSpotShadowColor(Color.Transparent);

            // Profile Button
            _rightButton = new Button(_context);
            _rightButton.Text = AppResources.Profile;
            _rightButton.SetTextSize(Android.Util.ComplexUnitType.Dip, 8);
            _rightButton.Click += _rightButton_Click;

            _rightButton.SetBackgroundColor(Color.Transparent);
            _rightButton.SetOutlineAmbientShadowColor(Color.Transparent);
            _rightButton.SetOutlineSpotShadowColor(Color.Transparent);

            SelectedIndex = 0;

            AddView(_leftButton);
            AddView(_rightButton);

            _totalBalance = new TextView(context);
            _totalBalance.TextSize = 14;
            _totalBalance.Gravity = GravityFlags.CenterHorizontal;
            _totalBalance.Text = AppResources.TotalBalance;

            _balance = new TextView(context);
            _balance.TextSize = 18;

            // Bold
            TextPaint paint = _balance.Paint;
            paint.FakeBoldText = true;
            _balance.Gravity = GravityFlags.CenterHorizontal;
            _balance.Text = "$12121";
            _balance.SetTextColor(Color.Blue);

            AddView(_totalBalance);
            AddView(_balance);

            // Top Line
            _topLine = new View(context);
            _topLine.SetBackgroundColor(Color.LightGray);

            AddView(_topLine);

        }

        private void _rightButton_Click(object sender, EventArgs e)
        {
            SelectedIndex = 1;
            if (_action != null)
            {
                _action(1);
            }
        }

        private void _leftButton_Click(object sender, EventArgs e)
        {
            SelectedIndex = 0;
            if (_action != null)
            {
                _action(0);
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            const int Button_Width = 60;
            const int Button_Padding = 1;
            const int Horizontal_Padding = 5;
            int Button_Height = b;

            _leftButton.Layout(DensityUtil.Dp2px(_context, Horizontal_Padding), DensityUtil.Dp2px(_context, Button_Padding), DensityUtil.Dp2px(_context,Button_Width) + DensityUtil.Dp2px(_context, Horizontal_Padding), Button_Height- DensityUtil.Dp2px(_context, Button_Padding));
            _rightButton.Layout(r - DensityUtil.Dp2px(_context,Button_Width) - DensityUtil.Dp2px(_context, Horizontal_Padding), DensityUtil.Dp2px(_context, Button_Padding), r - DensityUtil.Dp2px(_context, Horizontal_Padding), Button_Height- DensityUtil.Dp2px(_context, Button_Padding));

            _totalBalance.Layout(0, DensityUtil.Dp2px(_context,5), r, b);
            _balance.Layout(0, DensityUtil.Dp2px(_context, 25), r, b);

            _topLine.Layout(0, 0, r, DensityUtil.Dp2px(_context, 0.5f));
        }

        ~CLMainTabBar()
        {
            _leftButton.Click += _leftButton_Click;
            _rightButton.Click += _rightButton_Click;
        }
    }
}
