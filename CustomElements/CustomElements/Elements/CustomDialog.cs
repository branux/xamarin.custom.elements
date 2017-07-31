﻿using System;
using Xamarin.Forms;

namespace CustomElements.Elements
{
    public class CustomDialog
    {
        private AbsoluteLayout _parent { get; set; }
        protected AbsoluteLayout _shadowBox { get; set; }

        public CustomDialog(AbsoluteLayout paramParent, Color paramShadowColor, Boolean paramCloseOnShadowClick = true)
        {
            _parent = paramParent;

            _shadowBox = new AbsoluteLayout();
            _shadowBox.HeightRequest = _parent.HeightRequest;
            _shadowBox.WidthRequest = _parent.WidthRequest;
            _shadowBox.BackgroundColor = paramShadowColor;
            AbsoluteLayout.SetLayoutFlags(_shadowBox, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(_shadowBox, new Rectangle(0, 0, _parent.WidthRequest, _parent.HeightRequest));
            _shadowBox.IsVisible = false;

            if (paramCloseOnShadowClick)
            {
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) =>
                {
                    ShadowBox_Tap(s);
                };
                _shadowBox.GestureRecognizers.Add(tapGestureRecognizer);
            }

            _parent.Children.Add(_shadowBox);

        }

        private void ShadowBox_Tap(object obj)
        {
            this.HideAndCleanAlert();
        }

        public void AddChildren(View paramChild)
        {
            //Para não fechar no clique do filho
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                return;
            };
            paramChild.GestureRecognizers.Add(tapGestureRecognizer);

            _shadowBox.Children.Add(paramChild);
        }

        public void ShowAlert(View paramChild)
        {
            AddChildren(paramChild);
            _shadowBox.IsVisible = true;
        }

        public void ShowAlert()
        {
            _shadowBox.IsVisible = true;
        }

        public void HideAndCleanAlert()
        {
            HideAlert();
            _shadowBox.Children.Clear();
        }

        public void HideAlert()
        {
            _shadowBox.IsVisible = false;
        }

        #region Padrões
        public Frame RequireFramePadrao()
        {
            Frame paramFrame = new Frame();
            paramFrame.OutlineColor = Color.Black;
            paramFrame.VerticalOptions = LayoutOptions.CenterAndExpand;
            paramFrame.HorizontalOptions = LayoutOptions.Center;
            paramFrame.BackgroundColor = Color.White;
            paramFrame.WidthRequest = (App.ScreenWidth * 0.8);

            AbsoluteLayout.SetLayoutFlags(paramFrame, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(paramFrame, new Rectangle(0.5f, 0.5f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            return paramFrame;
        }

        public ActivityIndicator RequireActivityIndicator()
        {
            ActivityIndicator paramFrame = new ActivityIndicator();
            paramFrame.IsVisible = true;
            paramFrame.IsRunning = true;
            paramFrame.WidthRequest = 53;
            paramFrame.HeightRequest = 53;

            AbsoluteLayout.SetLayoutFlags(paramFrame, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(paramFrame, new Rectangle(0.5f, 0.5f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            return paramFrame;
        }
        #endregion

        public void Destroy()
        {
            _parent.Children.Remove(_shadowBox);
        }
    }
}
